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
    public class SeriesController : Controller
    {
        private readonly ILogger<EventController> _logger;

        private TicketrContext db;

        public SeriesController(TicketrContext context)
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

        [HttpGet("series/create")]
        public IActionResult CreateSeries()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            User user = db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            if(user.AccessLevel != "HeadAdmin" && user.AccessLevel != "GeneralAdmin")
            {
                return RedirectToAction("Dashboard", "Home");
            }
            List<Event> upcomingEvents = db.Events.Where(t => t.StartDate >= DateTime.Now).OrderBy(t => t.StartDate).ToList();
            ViewBag.UpcomingEvents = upcomingEvents;

            return View("NewSeries");
        }

        [HttpPost("series/create/new")]
        public IActionResult CreateNewSeries(Series newSeries)
        {
            List<Event> upcomingEvents = db.Events.Where(t => t.StartDate >= DateTime.Now).OrderBy(t => t.StartDate).ToList();
            ViewBag.UpcomingEvents = upcomingEvents;
            
            Series checkSeries = db.Series.FirstOrDefault(s => s.SeriesDate == newSeries.SeriesDate && s.SeriesTime == newSeries.SeriesTime && s.SeriesName == newSeries.SeriesName);
            if(checkSeries != null)
            {
                ModelState.AddModelError("RelatedEventCode", "This series already exists");
                return View("NewSeries");
            }
            Event checkEvent = db.Events.FirstOrDefault(e => e.EventCode == newSeries.RelatedEventCode);
            if(checkEvent == null)
            {
                ModelState.AddModelError("RelatedEventCode", "The code you typed does not exist");
                return View("NewSeries");
            }
            if(ModelState.ContainsKey("SeriesDate")== true)
            {
                ModelState["SeriesDate"].Errors.Clear();
            }
            if(newSeries.SeriesDate < checkEvent.StartDate)
            {
                ModelState.AddModelError("SeriesDate", "The series must happen on the day of or after the event beginning");
                return View("NewSeries");
            }
            if(newSeries.SeriesDate > checkEvent.EndDate)
            {
                ModelState.AddModelError("SeriesDate", "The series must happen on the day of or before the event ended");
                return View("NewSeries");
            }
            if(!ModelState.IsValid)
            {
                return View("NewSeries");
            }
            User curUser = db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            newSeries.UserId = curUser.UserId;
            newSeries.EventId = checkEvent.EventId;
            newSeries.CombinedTime = new DateTime
            (
                newSeries.SeriesDate.Year,
                newSeries.SeriesDate.Month,
                newSeries.SeriesDate.Day,
                newSeries.SeriesTime.Hour,
                newSeries.SeriesTime.Minute,
                newSeries.SeriesTime.Second
            );

            db.Series.Add(newSeries);
            db.SaveChanges();

            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet("series/view/all")]
        public IActionResult ViewAllSeries()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            List<Series> allSeries = db.Series.Include(e => e.Event).OrderBy(t => t.CombinedTime).ToList();
            ViewBag.AllSeries = allSeries;

            return View("AllSeries");
        }

        [HttpGet("series/view/{SeriesId}")]
        public IActionResult SeriesDetails(int SeriesId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Series curSeries = db.Series.Include(e => e.Event).FirstOrDefault(s => s.SeriesId == SeriesId);
            if(curSeries == null)
            {
                return RedirectToAction("Dashboard","Home");
            }

            return View("SeriesDetails", curSeries);
        }

        [HttpGet("series/{SeriesId}/edit")]
        public IActionResult EditSeries(int SeriesId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Series curSeries = db.Series.Include(e => e.Event).FirstOrDefault(s => s.SeriesId == SeriesId);
            if(curSeries == null)
            {
                return RedirectToAction("Dashboard","Home");
            }

            List<Event> upcomingEvents = db.Events.Where(t => t.StartDate >= DateTime.Now).OrderBy(t => t.StartDate).ToList();
            ViewBag.UpcomingEvents = upcomingEvents;

            return View("EditSeries", curSeries);
        }

        [HttpPost("series/{SeriesId}/update")]
        public IActionResult UpdateSeries(int SeriesId, Series editSeries)
        {
            List<Event> upcomingEvents = db.Events.Where(t => t.StartDate >= DateTime.Now).OrderBy(t => t.StartDate).ToList();
            ViewBag.UpcomingEvents = upcomingEvents;
            
            Series curSeries = db.Series.FirstOrDefault(s => s.SeriesId == SeriesId);
            if(curSeries == null)
            {
                return RedirectToAction("ViewAllSeries");
            }
            Event checkEvent = db.Events.FirstOrDefault(e => e.EventCode == editSeries.RelatedEventCode);
            if(checkEvent == null)
            {
                ModelState.AddModelError("RelatedEventCode", "The code you typed does not exist");
                return View("EditSeries");
            }
            if(ModelState.ContainsKey("SeriesDate")== true)
            {
                ModelState["SeriesDate"].Errors.Clear();
            }
            if(editSeries.SeriesDate < checkEvent.StartDate)
            {
                ModelState.AddModelError("SeriesDate", "The series must happen on the day of or after the event beginning");
                return View("EditSeries");
            }
            if(editSeries.SeriesDate > checkEvent.EndDate)
            {
                ModelState.AddModelError("SeriesDate", "The series must happen on the day of or before the event ended");
                return View("EditSeries");
            }
            if(!ModelState.IsValid)
            {
                return View("EditSeries");
            }
            
            editSeries.CombinedTime = new DateTime
            (
                editSeries.SeriesDate.Year,
                editSeries.SeriesDate.Month,
                editSeries.SeriesDate.Day,
                editSeries.SeriesTime.Hour,
                editSeries.SeriesTime.Minute,
                editSeries.SeriesTime.Second
            );

            curSeries.SeriesName = editSeries.SeriesName;
            curSeries.SeriesDate = editSeries.SeriesDate;
            curSeries.SeriesTime = editSeries.SeriesTime;
            curSeries.CombinedTime = editSeries.CombinedTime;
            curSeries.SeriesVenue = editSeries.SeriesVenue;
            curSeries.TicketPrice = editSeries.TicketPrice;
            curSeries.TicketsAvailable = editSeries.TicketsAvailable;


            db.Series.Update(curSeries);
            db.SaveChanges();

            return RedirectToAction("SeriesDetails", new {SeriesId = SeriesId});
        }

        [HttpPost("series/{SeriesId}/delete")]
        public IActionResult DeleteSeries(int SeriesId)
        {
            Series curSeries = db.Series.FirstOrDefault(s => s.SeriesId == SeriesId);
            if(curSeries == null)
            {
                return RedirectToAction("ViewAllSeries");
            }

            db.Series.Remove(curSeries);
            db.SaveChanges();
            return RedirectToAction("ViewAllSeries");
        }
    }
}