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
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Ain_Shams_Hospital.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly HospitalDbContext _auc;
        public RegistrationController(HospitalDbContext auc)
        {
            _auc = auc;
        }
        [HttpGet]
        public IActionResult Activation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Activation(actVM ch)
        {
            var CodeExist = _auc.Specializations.ToList().Any(z => z.Code == ch.Activation);

            if (CodeExist)
            {
                if (ch.Activation == "0000")
                {
                    return Redirect("/Registration/RegistrationPatient");
                }
                else
                {

                    TempData["Specialization_Id"] = _auc.Specializations
                        .Where(i => i.Code == ch.Activation)
                        .Select(c => c.Id)
                        .Single();

                   return Redirect("/Registration/RegistrationStaff");
                }
            }
            else
            {
                return Redirect("/Registration/Activation");
            }


        }
        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult Staff()
        {
            return View();
        }

        public IActionResult About()
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
        public IActionResult RegistrationPatient(RegistrationPatientVM obj)
        {
            Registration r = new Registration();
            r.Email = obj.Email;
            r.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);

            var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == r.Email);
            if (EmailExist)
            {
                //throw error
                ViewBag.EmailExistError = "You have already signed up";
                //go to error page
                return Redirect("/Registration/About");
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
                return Redirect("/Registration/Patient");
            }
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
            R.Password = BCrypt.Net.BCrypt.HashPassword(objc.Password);
            var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == R.Email);
            if (EmailExist)
            {
                //throw error
                ViewBag.EmailExistError = "You have already signed up";
                //go to error page
                return Redirect("/Registration/About");
            }

            else
            {
                _auc.Add(R);
                _auc.SaveChanges();
                Staff S = new Staff();
                S.Name = objc.Name;
                S.Phone = objc.Phone;
                S.Starting_Day = objc.Starting_Day;
                S.Registration_Id = R.Id;

                S.Specialization_Id = (int)TempData["Specialization_Id"];

                //recently added
                var code = _auc.Specializations
                           .Where(s => s.Id == S.Specialization_Id)
                           .Select(s => s.Code)
                           .Single();

                int _Index = (int)code[0] - 48; //the first number in the activation code

                _auc.Add(S);
                _auc.SaveChanges();

                //TempData["User_Reg_Id"] = S.Registration_Id;
                HttpContext.Session.SetInt32("User_Reg_Id", (int)S.Registration_Id);

                switch (_Index)
                {
                    case 0:
                    //go to patient

                    case 1:
                        return Redirect("/Doctor/Main");

                    case 2:
                    //go to manager

                    case 3:
                    //go to lap

                    case 4:
                    //go to finance

                    case 5:
                        return Redirect("/Front_desk/Roomreservation");

                    default:
                        return Redirect("/Registration/Staff");
                }

            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Loggin()
        {
            return View();
        }
        public IActionResult NotLog()
        {
            return View();
        }

        ///login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegistrationStaffVM objc)
        {
            var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == objc.Email);
            if (EmailExist)
            {
                var Data = _auc.Registrations.Where(f => f.Email == objc.Email).Select(s => new { s.Password, s.Id }).ToList();
                if (BCrypt.Net.BCrypt.Verify(objc.Password, Data[0].Password))
                {
                    var SID = _auc.Staff.Where(F => F.Registration_Id == Data[0].Id).Select(S => S.Specialization_Id).Single();
                    var code = _auc.Specializations
                            .Where(s => s.Id == SID)
                            .Select(s => s.Code)
                            .Single();

                    int _Index = (int)code[0] - 48;

                    //TempData["User_Reg_Id"] = Data[0].Id;
                    HttpContext.Session.SetInt32("User_Reg_Id", Data[0].Id);


                    switch (_Index)
                    {
                        case 0:
                        //go to patient

                        case 1:
                            return Redirect("/Doctor/Main");

                        case 2:
                        //go to manager

                        case 3:
                        //go to lap

                        case 4:
                        //go to finance


                        case 5:
                            return Redirect("/Front_desk/Roomreservation");

                        default:
                            return Redirect("/Registration/Staff");
                    }
                }
            }
            return Redirect("/Registration/NotLog");
        }
    }
}
