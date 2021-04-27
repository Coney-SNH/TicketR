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
using System.Text.RegularExpressions;

namespace Ticketr.Controllers
{
    public class EventController : Controller
    {
        private readonly ILogger<EventController> _logger;

        private TicketrContext db;

        public EventController(TicketrContext context)
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

        [HttpGet("event/create")]
        public IActionResult Create()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            User user = db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            if(user.AccessLevel != "HeadAdmin")
            {
                return RedirectToAction("Dashboard", "Home");
            }

            return View("New");
        }

        [HttpPost("event/create/new")]
        public IActionResult CreateEvent(Event newEvent)
        {
            Event checkEvent = db.Events.FirstOrDefault(e => e.EventCode == newEvent.EventCode);
            if(checkEvent != null)
            {
                ModelState.AddModelError("EventCode", "This event code already exists");
            }
            if(ModelState.ContainsKey("StartDate") == true)
            {
                ModelState["StartDate"].Errors.Clear();
            }
            if(ModelState.ContainsKey("EndDate") == true)
            {
                ModelState["EndDate"].Errors.Clear();
            }
            if(newEvent.StartDate <= DateTime.Now)
            {
                ModelState.AddModelError("StartDate", "Starting Date must be a future date");
            }
            if(newEvent.EndDate <= DateTime.Now)
            {
                ModelState.AddModelError("EndDate", "Ending Date must be a future date");
            }
            long start = long.Parse(newEvent.StartDate.ToString("yyyyMMddHHmmss"));
            long end = long.Parse(newEvent.EndDate.ToString("yyyyMMddHHmmss"));
            if(end - start < 0)
            {
                ModelState.AddModelError("StartDate", "The show can't end before it begins");
            }
            if(!ModelState.IsValid)
            {
                return View("New");
            }
            User curUser = db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            newEvent.UserId = curUser.UserId;

            db.Events.Add(newEvent);
            db.SaveChanges();

            return RedirectToAction("ViewAll");
        }

        [HttpGet("event/view/all")]
        public IActionResult ViewAll()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            List<Event> allEvents = db.Events.OrderBy(d => d.StartDate).ToList();
            // List<Event> allEvents = db.Events.Where(t => t.EndDate <= DateTime.Now).ToList();
            ViewBag.AllEvents = allEvents;

            return View("AllEvents");
        }

        [HttpGet("event/{EventId}/edit")]
        public IActionResult Edit(int EventId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Event curEvent = db.Events.FirstOrDefault(e => e.EventId == EventId);
            if(curEvent == null)
            {
                return RedirectToAction("Dashboard","Home");
            }

            return View("EditEvent", curEvent);
        }

        [HttpPost("event/{EventId}/update")]
        public IActionResult UpdateEvent(int EventId, Event editEvent)
        {
            Event curEvent = db.Events.FirstOrDefault(e => e.EventId == EventId);
            if(ModelState.ContainsKey("StartDate") == true)
            {
                ModelState["StartDate"].Errors.Clear();
            }
            if(ModelState.ContainsKey("EndDate") == true)
            {
                ModelState["EndDate"].Errors.Clear();
            }
            if(editEvent.StartDate <= DateTime.Now)
            {
                ModelState.AddModelError("StartDate", "Starting Date must be a future date");
            }
            if(editEvent.EndDate <= DateTime.Now)
            {
                ModelState.AddModelError("EndDate", "Ending Date must be a future date");
            }
            long start = long.Parse(editEvent.StartDate.ToString("yyyyMMddHHmmss"));
            long end = long.Parse(editEvent.EndDate.ToString("yyyyMMddHHmmss"));
            if(end - start < 0)
            {
                ModelState.AddModelError("StartDate", "The show can't end before it begins");
            }
            if(!ModelState.IsValid)
            {
                return View("Edit", editEvent);
            }

            curEvent.EventCode = editEvent.EventCode;
            curEvent.EventName = editEvent.EventName;
            curEvent.PriceMap = editEvent.PriceMap;
            curEvent.StartDate = editEvent.StartDate;
            curEvent.EndDate = editEvent.EndDate;
            curEvent.UpdatedAt = DateTime.Now;

            db.Events.Update(curEvent);
            db.SaveChanges();

            return RedirectToAction("Details", new{EventId = EventId});
        }

        [HttpGet("event/view/{EventId}")]
        public IActionResult Details(int EventId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Event curEvent = db.Events.FirstOrDefault(e => e.EventId == EventId);
            if(curEvent == null)
            {
                return RedirectToAction("Dashboard","Home");
            }

            return View("Details", curEvent);
        }
    }
}