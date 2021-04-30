using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ticketr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Ticketr.Controllers
{
    public class SeatController : Controller
    {
        private TicketrContext db;

        public SeatController(TicketrContext context)
        {
            db = context;
        }

        private int? uid
        {
            get
            {
                // //////////////////////////////////////////////////////////////////
                // //////////////////////////////////////////////////////////////////
                // //////////////////////////////////////////////////////////////////
                HttpContext.Session.SetInt32("UserId", 1); //DELETE AFTERWARDS!!!!
                // //////////////////////////////////////////////////////////////////
                // //////////////////////////////////////////////////////////////////
                // //////////////////////////////////////////////////////////////////
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        [HttpGet("create/seat")]
        public IActionResult CreateSeat()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            List<Seat> allSeats = db.Seats.OrderByDescending(s => s.SeatId).ToList();
            ViewBag.Seats = allSeats;
            return View("NewSeat");
        }

        [HttpPost("create/new/seat")]
        public IActionResult NewSeat(Seat newSeat)
        {
            Seat curSeat = db.Seats.FirstOrDefault(s => s.SeatNumber == newSeat.SeatNumber);
            if(curSeat != null)
            {
                return View("NewSeat");
            }
            db.Seats.Add(newSeat);
            db.SaveChanges();
            return RedirectToAction("CreateSeat");
        }

        [HttpGet("seat/select/{PatronId}/{SeriesId}")]
        public IActionResult SelectSeat(int PatronId, int SeriesId)
        {
            List<Seat> RemainingSeats = db.Seats
                .Include(ssp => ssp.PatronInSeries)
                .Where(ssp => !ssp.PatronInSeries.Any(id => id.SeriesId == SeriesId))
                .ToList();
            ViewBag.TheatreLayout = "/Images/SeatingChartCrop.png";
            ViewBag.PatronId = PatronId;
            ViewBag.SeriesId = SeriesId;
            ViewBag.RemainingSeats = RemainingSeats;
            return View("SelectSeat");
        }

        [HttpPost("seat/choose/{PatronId}/{SeriesId}")]
        public IActionResult ChooseSeat(int PatronId, int SeriesId, SeriesSeatPatronRel newSeriesSeatPatronRel)
        {
            SeriesSeatPatronRel PatSeatShow = new SeriesSeatPatronRel
            {
                SeriesId = SeriesId,
                PatronId = PatronId,
                SeatId = newSeriesSeatPatronRel.SeatId
            };

            db.SeriesSeatPatronRels.Add(PatSeatShow);
            db.SaveChanges();

            return RedirectToAction("PurchaseTicket", "Patron", new {PatronId = PatronId});
        }
    }
}