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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TicketrContext db;

        public HomeController(TicketrContext context)
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

        [HttpGet("")]
        public IActionResult Index()
        {
            if(isLoggedIn == true)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpGet("register")]
        public IActionResult Registration()
        {
            return View("Registration");
        }

        [HttpPost("registerAccount")]
        public IActionResult Register(User regUser)
        {
            if(ModelState.IsValid)
            {
                if(db.Users.Any(u => u.Email == regUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already taken");
                }

                if(regUser.AccessLevel != "12345678" && regUser.AccessLevel != "abcdefgh" && regUser.AccessLevel != "87654321")
                {
                    //"12345678" == Head Manager == all access
                    //"87654321" == General Employee == cannot add events
                    //"abcdefgh" == New Employee == Can ONLY access patron pages. 
                    ModelState.AddModelError("AccessLevel", "The employer code you typed was incorrect. Please confirm you wrote the write code");
                }
            }
            
            if(ModelState.IsValid == false)
            {
                return View("Registration");
            }

            if(regUser.AccessLevel == "12345678")
            {
                regUser.AccessLevel = "HeadAdmin";
            }
            else if (regUser.AccessLevel == "87654321")
            {
                regUser.AccessLevel = "GeneralAdmin";
            }
            else
            {
                regUser.AccessLevel = "NewEmployee";
            }

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            regUser.Password = hasher.HashPassword(regUser, regUser.Password);

            db.Users.Add(regUser);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost("loginAccount")]
        public IActionResult Login(LogUser logUser)
        {
            string errorMessage = "Email or Password was incorrect";
            
            if(ModelState.IsValid == false)
            {
                return View("Index");
            }
            
            User dbUser = db.Users.FirstOrDefault(u => u.Email == logUser.LoginEmail);
            if (dbUser == null)
            {
                ModelState.AddModelError("LoginEmail", errorMessage);
                return View("Index");
            }
            
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            PasswordVerificationResult pwCompareResult = hasher.VerifyHashedPassword(logUser, dbUser.Password, logUser.LoginPassword);
            if (pwCompareResult == 0)
            {
                ModelState.AddModelError("LoginEmail", errorMessage);
                return View("Index");
            }

            HttpContext.Session.SetInt32("UserId", dbUser.UserId);
            HttpContext.Session.SetString("FullName", dbUser.FullName());

            return RedirectToAction("Dashboard");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(!isLoggedIn)
            {
                return RedirectToAction("Index");
            }

            User curUser = db.Users.FirstOrDefault(u => u.UserId == (int)uid);
            ViewBag.CurrentUser = curUser;

            return View("Dashboard");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
