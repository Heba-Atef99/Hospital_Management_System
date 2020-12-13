using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.Models;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Ain_Shams_Hospital.ViewModels;

namespace Ain_Shams_Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDbContext _auc;
        public HomeController(HospitalDbContext auc)
        {
            _auc = auc;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult Staff()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegistrationPatient()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationPatient(RegistrationPatientVM obj)
        {
            Registration r = new Registration();
            r.Email = obj.Email;
            r.Password = obj.Password;
            /*
            var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == r.Email);
            if(EmailExist)
            {
                //throw error
                ViewBag.UserMessage = "You have already signed up";
            }

            else
            {
                _auc.Add(r);
                _auc.SaveChanges();
                Patient P = new Patient();
                P.Name = obj.Name;
                P.Phone = obj.Phone;
                P.Registration_Id = r.Id;

                _auc.Add(P);
                _auc.SaveChanges();
            }
            */

            _auc.Add(r);
            _auc.SaveChanges();
            Patient P = new Patient();
            P.Name = obj.Name;
            P.Phone = obj.Phone;
            P.Registration_Id = r.Id;

            _auc.Add(P);
            _auc.SaveChanges();

            return Redirect("/Home/Patient");

        }
        [HttpGet]
        public IActionResult RegistrationStaff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationStaff(RegistrationStaffVM objc)
        {
            Registration R = new Registration();
            R.Email = objc.Email;
            R.Password = objc.Password;
            _auc.Add(R);
            _auc.SaveChanges();
            Staff S = new Staff();
            S.Name = objc.Name;
            S.Phone = objc.Phone;
            S.Starting_Day = objc.Starting_Day;
            S.Registration_Id = R.Id;

            _auc.Add(S);
            _auc.SaveChanges();
            return Redirect("/Home/Staff");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        ///login
        login dbop = new login();
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        //that is for connection to sql server
         
        [HttpPost]
        
        public ActionResult verify([Bind] Account ad)
        {
            int res = dbop.LoginCheck(ad);
            if (res == 1)
            {
                TempData["msg"] = "You are welcome to Admin Section";
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
            }
            return View();
        }

    }
}
