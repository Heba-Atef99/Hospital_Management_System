using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ain_Shams_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ain_Shams_Hospital.ViewModels;
using Ain_Shams_University.ViewModels;
using Ain_Shams_Hospital.Data.Entities;
using HospitalManagementSystem.Data;
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
        [ValidateAntiForgeryToken]
        public IActionResult Donation(DonationsVM don)
        {
            Donation dona = new Donation();
            dona.Name = don.Name;
            dona.Email = don.Email;
            dona.Day = don.Day;
            dona.Phone_Number = don.PhoneNumber;
            _HDB.Add(dona);
            _HDB.SaveChanges();

            return RedirectToAction("save","Home");
        }
        public IActionResult save()
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
