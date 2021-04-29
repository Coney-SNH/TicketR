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
        // private readonly ILogger<EventController> _logger;

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
                // HttpContext.Session.SetInt32("UserId", 1); //DELETE AFTERWARDS!!!!
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

            // string[] AllSeats = {"A1","A2","A3","A4","A5","A6","A7","A8","A9","A10","A11","B1","B2","B3","B4","B5","B6","B7","B8","B9","B10","B11","C1","C2","C3","C4","C5","C6","C7","C8","C9","C10","C11","D1","D2","D3","D4","D5","D6","D7","D8","D9","D10","D11","E1","E2","E3","E4","E5","E6","E7","E8","E9","E10","E11"};
            // string[] GoldSection = {"A4","A5","A6","A7","A8","B4","B5","B6","B7","B8","C5","C6","C7"};
            // string[] SectionA = {"A2","A3","A9","A10","B2","B3","B9","B10","C2","C3","C4","C8","C9","C10","D3","D4","D5","D6","D7","D8","D9","E4","E5","E6","E7","E8"};
            // string[] SectionB = {"A1","A11","B1","B11","C1","C11","D1","D2","D10","D11","E1","E2","E3","E9","E10","E11"};

            // newSeries.AvailableSeats = AllSeats;


            db.Series.Add(newSeries);
            db.SaveChanges();

            return RedirectToAction("Details", "Event", new{EventId = newSeries.EventId});
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
            Series curSeries = db.Series.Include(e => e.Event).Include(p=> p.PatronsWatched).ThenInclude(p => p.Patron).FirstOrDefault(s => s.SeriesId == SeriesId);
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
                return View("EditSeries", curSeries);
            }
            if(ModelState.ContainsKey("SeriesDate")== true)
            {
                ModelState["SeriesDate"].Errors.Clear();
            }
            if(editSeries.SeriesDate < checkEvent.StartDate)
            {
                ModelState.AddModelError("SeriesDate", "The series must happen on the day of or after the event beginning");
                return View("EditSeries", curSeries);
            }
            if(editSeries.SeriesDate > checkEvent.EndDate)
            {
                ModelState.AddModelError("SeriesDate", "The series must happen on the day of or before the event ended");
                return View("EditSeries", curSeries);
            }
            if(!ModelState.IsValid)
            {
                return View("EditSeries", curSeries);
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

        [HttpGet("series/search/")]
        public IActionResult SearchSeries(string SearchTerm)
        {
            List<Series> matchSeries = db.Series.Include(e => e.Event).Where(e => e.SeriesName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            ViewBag.SearchTerm = SearchTerm;
            return View("SeriesSearchResults", matchSeries);
        }
    }
}