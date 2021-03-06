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
    public class PatronController : Controller
    {
        // private readonly ILogger<PatronController> _logger;

        private TicketrContext db;

        public PatronController(TicketrContext context)
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
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/create")]
        public IActionResult CreatePatron()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            return View("NewPatron");
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("patron/create/new")]
        public IActionResult CreateNewPatron(Patron newPatron)
        {
            Patron checkPatron = db.Patrons.FirstOrDefault(p => p.FirstName == newPatron.FirstName && p.LastName == newPatron.LastName && p.PhoneNumber == newPatron.PhoneNumber && p.Address == newPatron.Address && p.DateOfBirth == newPatron.DateOfBirth);
            if(checkPatron != null)
            {
                ModelState.AddModelError("FirstName", "This patron is already in our database.");
            }
            if(ModelState.ContainsKey("DateOfBirth") == true)
            {
                ModelState["DateOfBirth"].Errors.Clear();
            }
            if(newPatron.DateOfBirth >= DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth must be a past date");
            }
            if(!ModelState.IsValid)
            {
                return View("NewPatron");
            }

            if(newPatron.Email == null)
            {
                newPatron.Email = "None Given";
            }
            if(newPatron.FaxNumber == null)
            {
                newPatron.FaxNumber = "None Given";
            }
            if(newPatron.Website == null)
            {
                newPatron.Website = "None Given";
            }
            if(newPatron.SubscriptionModule == null)
            {
                newPatron.SubscriptionModule = "No Subscription";
            }

            User curUser = db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            newPatron.UserId = curUser.UserId;

            db.Patrons.Add(newPatron);
            db.SaveChanges();
            return RedirectToAction("PatronDetails", new {PatronId = newPatron.PatronId});
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/view/all")]
        public IActionResult ViewAllPatrons()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            List<Patron> allPatrons = db.Patrons.OrderBy(i => i.PatronId).ToList();
            ViewBag.AllPatrons = allPatrons;

            return View("AllPatrons");
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/view/{PatronId}")]
        public IActionResult PatronDetails(int PatronId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            Patron curPatron = db.Patrons
                .Include(s => s.SeriesSeen)
                    .ThenInclude(ser => ser.Series)
                .Include(d => d.DonationsMade)
                .Include(t => t.TicketsPurchased)
                    .ThenInclude(s => s.Series)
                .FirstOrDefault(p => p.PatronId == PatronId);

            if(curPatron == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            long dob = long.Parse(curPatron.DateOfBirth.ToString("yyyyMMdd"));
            long today = long.Parse(DateTime.Now.ToString("yyyyMMdd"));

            long age = today - dob;

            if(age < 180000)
            {
                ViewBag.PatronAge = age/10000;
                ViewBag.PatronStatus = "Youth";
            }
            else if(age > 650000)
            {
                ViewBag.PatronAge = age/10000;
                ViewBag.PatronStatus = "Senior";
            }
            else
            {
                ViewBag.PatronAge = age/10000;
                ViewBag.PatronStatus = "General Adult";
            }
            List<PatronSeriesRel> AllPatronSeries = db.PatronSeriesRels
                .Include(p => p.Patron)
                .Include(s => s.Series)
                    .ThenInclude(e => e.Event)
                .Where(pi => pi.PatronId == PatronId)
                .OrderBy(st => st.Series.CombinedTime)
                .ToList();
            ViewBag.AllPatronSeries = AllPatronSeries;

            decimal PatronTotalTickets = 0;
            foreach (var item in AllPatronSeries)
            {
                PatronTotalTickets += item.Series.TicketPrice;
            }
            ViewBag.PatronTotals = PatronTotalTickets;

            decimal totalDonations = 0;
            foreach(var item in curPatron.DonationsMade)
            {
                totalDonations += item.DonationAmount;
            }

            ViewBag.PatronDonations = totalDonations;

            List<SeriesSeatPatronRel> allSSPs = db.SeriesSeatPatronRels
                .Include(s => s.Series)
                    .ThenInclude(ps => ps.PatronsWatched)
                .Include(s => s.Series)
                    .ThenInclude(se => se.Event)
                .Include(p => p.Patron)
                .Include(s => s.Seat)
                .Where(p => p.PatronId == PatronId)
                .OrderBy(s => s.Series.CombinedTime)
                .ToList();

            ViewBag.AllSSPs = allSSPs;

            return View("PatronDetails", curPatron);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/{PatronId}/edit")]
        public IActionResult EditPatron(int PatronId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            if(curPatron == null)
            {
                return RedirectToAction("Dashboard","Home");
            }
            return View ("EditPatron", curPatron);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("patron/{PatronId}/update")]
        public IActionResult UpdatePatron(int PatronId, Patron editPatron)
        {
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            if(curPatron == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            if(ModelState.ContainsKey("DateOfBirth") == true)
            {
                ModelState["DateOfBirth"].Errors.Clear();
            }
            if(editPatron.DateOfBirth >= DateTime.Now)
            {
                ModelState.AddModelError("DateOfBirth", "Date of birth must be a past date");
            }
            if(!ModelState.IsValid)
            {
                return View("NewPatron");
            }

            curPatron.FirstName = editPatron.FirstName;
            curPatron.LastName = editPatron.LastName;
            curPatron.Address = editPatron.Address;
            curPatron.PhoneNumber = editPatron.PhoneNumber;
            curPatron.PhoneNumberType = editPatron.PhoneNumberType;
            curPatron.Email = editPatron.Email;
            curPatron.DateOfBirth = editPatron.DateOfBirth;
            curPatron.FaxNumber = editPatron.FaxNumber;
            curPatron.Website = editPatron.Website;
            curPatron.SubscriptionModule = editPatron.SubscriptionModule;
            curPatron.IsMilitary = editPatron.IsMilitary;
            curPatron.IsStudent = editPatron.IsStudent;
            curPatron.UpdatedAt = DateTime.Now;

            db.Patrons.Update(curPatron);
            db.SaveChanges();

            return RedirectToAction("PatronDetails", new {PatronId = PatronId});
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/{PatronId}/PurchaseTicket")]
        public IActionResult PurchaseTicket(int PatronId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            if(curPatron == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            List<Series> allSeries = db.Series
                .Include(e => e.Event)
                .Where(s => s.SeriesDate >= DateTime.Now)
                .Where(r => r.TicketsAvailable > 0)
                .OrderBy(t => t.CombinedTime)
                .ToList();
            ViewBag.AllSeries = allSeries;

            List<PatronSeriesRel> upcomingPatronSeries = db.PatronSeriesRels
                .Include(p => p.Patron)
                .Include(s => s.Series)
                    .ThenInclude(e => e.Event)
                .Where(pi => pi.PatronId == PatronId)
                .Where(st => st.Series.SeriesDate >= DateTime.Now)
                .OrderBy(st => st.Series.CombinedTime)
                .ToList();

            List<SeriesSeatPatronRel> upcomingSSPs = db.SeriesSeatPatronRels
                .Include(p => p.Patron)
                .Include(s => s.Series)
                    .ThenInclude(se => se.Event)
                .Include(s => s.Seat)
                .Where(pi => pi.PatronId == PatronId)
                .OrderBy(st => st.Series.CombinedTime)
                .ToList();

                
            ViewBag.UpcomingSSPs = upcomingSSPs;
            ViewBag.UpcomingPatronSeries = upcomingPatronSeries;

            return View("PurchaseTickets", curPatron);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("patron/{PatronId}/{SeriesId}/purchase")]
        public IActionResult PurchaseSeriesTicket(int PatronId, int SeriesId)
        {
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            Series curSeries = db.Series.FirstOrDefault(s => s.SeriesId == SeriesId);

            PatronSeriesRel newPatronSeriesRel = new PatronSeriesRel
            {
                PatronId = curPatron.PatronId,
                SeriesId = curSeries.SeriesId
            };

            decimal curDiscount = 0;
            if(curPatron.IsMilitary == true)
            {
                curDiscount += 5;
                curSeries.NetSales -= 5;
            }
            if(curPatron.IsStudent == true)
            {
                curDiscount += 5;
                curSeries.NetSales -= 5;
            }
            long dob = long.Parse(curPatron.DateOfBirth.ToString("yyyyMMdd"));
            long today = long.Parse(DateTime.Now.ToString("yyyyMMdd"));
            long age = today - dob;
            if(age < 180000)
            {
                curDiscount += 10;
                curSeries.NetSales += 10;
            }
            else if(age > 650000)
            {
                curDiscount += 5;
                curSeries.NetSales += 5;
            }

            curSeries.TicketsAvailable -= 1;
            curSeries.TicketsSold += 1;
            curSeries.BasePrice += curSeries.TicketPrice;
            curSeries.TotalDiscounts += curDiscount;
            curSeries.NetSales += curSeries.TicketPrice;

            db.PatronSeriesRels.Add(newPatronSeriesRel);
            db.Update(curSeries);
            db.SaveChanges();

            return RedirectToAction("SelectSeat", "Seat", new {PatronId = PatronId, SeriesId = SeriesId});
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("patron/{PatronId}/{SeriesId}/refund")]
        public IActionResult RefundTicket(int PatronId, int SeriesId)
        {
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            Series curSeries = db.Series.FirstOrDefault(s => s.SeriesId == SeriesId);
            PatronSeriesRel curPSR = db.PatronSeriesRels.FirstOrDefault(id => id.PatronId == PatronId && id.SeriesId == SeriesId);
            SeriesSeatPatronRel curSSPR = db.SeriesSeatPatronRels.FirstOrDefault(id => id.PatronId == PatronId && id.SeriesId == SeriesId);
            if(curPSR == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            decimal curDiscount = 0;
            if(curPatron.IsMilitary == true)
            {
                curDiscount += 5;
                curSeries.NetSales += 5;
            }
            if(curPatron.IsStudent == true)
            {
                curDiscount += 5;
                curSeries.NetSales += 5;
            }
            long dob = long.Parse(curPatron.DateOfBirth.ToString("yyyyMMdd"));
            long today = long.Parse(DateTime.Now.ToString("yyyyMMdd"));
            long age = today - dob;
            if(age < 180000)
            {
                curDiscount += 10;
                curSeries.NetSales -= 10;
            }
            else if(age > 650000)
            {
                curDiscount += 5;
                curSeries.NetSales -= 5;
            }

            curSeries.BasePrice -= curSeries.TicketPrice;
            curSeries.NetSales -= curSeries.TicketPrice;
            curSeries.TotalDiscounts -= curDiscount;
            curSeries.TicketsAvailable += 1;
            curSeries.TicketsSold -= 1;
            db.Series.Update(curSeries);
            db.PatronSeriesRels.Remove(curPSR);
            db.SeriesSeatPatronRels.Remove(curSSPR);
            db.SaveChanges();
            return RedirectToAction("PatronDetails", new {PatronId= PatronId});

        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/{PatronId}/donationPage")]
        public IActionResult DonationPage(int PatronId)
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            if(curPatron == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }

            return View("PatronDonation", curPatron);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpPost("patron/{PatronId}/makeDonation")]
        public IActionResult MakeDonation(int PatronId, Donation newDonation)
        {
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            if(curPatron == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            if(ModelState.IsValid == false)
            {
                return View("PatronDonation", curPatron);
            }

            newDonation.PatronId = curPatron.PatronId;
            db.Donations.Add(newDonation);
            db.SaveChanges();

            return RedirectToAction("PatronDetails", new {PatronId = PatronId});
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/print-ticket/{PatronId}/{SeriesId}")]
        public IActionResult PrintTicket(int PatronId, int SeriesId)
        {
            PatronSeriesRel curPatronSeriesRel = db.PatronSeriesRels
                .Include(p => p.Patron)
                .Include(s => s.Series)
                    .ThenInclude(se => se.Event)
                .FirstOrDefault(i => i.PatronId == PatronId && i.SeriesId == SeriesId);
            
            List<PatronSeriesRel> curPatronSeriesRels = db.PatronSeriesRels
                .Include(p => p.Patron)
                .Include(s => s.Series)
                    .ThenInclude(se => se.Event)
                .Where(i => i.PatronId == PatronId && i.SeriesId == SeriesId)
                .ToList();

            if(curPatronSeriesRel == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            ViewBag.TicketImage = "/wwwroot/img/green-texture.jpg";

            List<SeriesSeatPatronRel> curSeats = db.SeriesSeatPatronRels.Include(s => s.Seat).Include(p => p.Patron).Include(ser => ser.Series).Where(s => s.PatronId == PatronId && s.SeriesId == SeriesId).ToList();
            SeriesSeatPatronRel curSeat = db.SeriesSeatPatronRels.Include(s => s.Seat).FirstOrDefault(s => s.PatronId == PatronId && s.SeriesId == SeriesId);
            ViewBag.curSeat = curSeat;
            return View("PrintTicket", curPatronSeriesRel);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/test-print-ticket/{PatronId}/{SeriesId}")]
        public IActionResult PrintTicket2(int PatronId, int SeriesId)
        {
            List<SeriesSeatPatronRel> allPatronSeriesTickets = db.SeriesSeatPatronRels
            .Include(s => s.Series)
                .ThenInclude(e => e.Event)
            .Include(p=> p.Patron)
            .Include(s => s.Seat)
            .Where(s => s.SeriesId == SeriesId && s.PatronId == PatronId)
            .ToList();
            if(allPatronSeriesTickets == null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            Patron curPatron = db.Patrons.FirstOrDefault(p => p.PatronId == PatronId);
            ViewBag.curPatron = curPatron;

            return View("PrintTicket2", allPatronSeriesTickets);
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        [HttpGet("patron/search/")]
        public IActionResult SearchPatrons(string SearchTerm)
        {
            List<Patron> matchPatron = db.Patrons.Where(p => p.FirstName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) || p.LastName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) || p.Address.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) || p.PhoneNumber.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) || p.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            ViewBag.SearchTerm = SearchTerm;
            return View("PatronSearchResults", matchPatron);
        }
    }
}