using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ain_Shams_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ain_Shams_Hospital.ViewModels;
using Ain_Shams_Hospital.Data.Entities;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Http;

namespace Ain_Shams_Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDbContext _HDB;

        public HomeController(HospitalDbContext HDB)
        {
            _HDB = HDB;
        }

       /* private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("User_Reg_Id", 0);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Covid()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Donation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Donation(DonationsVM don)
        {
             
            Donation dona = new Donation();
            dona.Name = don.Name;
            dona.Email = don.Email;
            dona.Day = don.Day;
            dona.Phone_Number = don.PhoneNumber;
            _HDB.Add(dona);
            _HDB.SaveChanges();
            String visitor_name = dona.Name;
            ViewBag.visitorname = visitor_name;
            return RedirectToAction("saveDonation", "Home");
        }
        [HttpGet]
        public IActionResult saveDonation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult saveDonation(Donation d)
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
