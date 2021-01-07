using Ain_Shams_Hospital.Data.Entities;
using AinShamsHospital.ViewModels;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.Controllers
{
    public class finance : Controller
    {
        private readonly HospitalDbContext _asu;
        public finance(HospitalDbContext asu)
        {
            _asu = asu;
        }
        [HttpGet]
        public IActionResult Billresult()
        {
         
            return View();
        }
        [HttpPost]
        public IActionResult Billresult(payed m)
        {
            ViewBag.select = m.isactive;
            Payment P = new Payment();
            P.Payed = m.isactive;
            _asu.Add(P);
            _asu.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Bill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Bill(payed m)
        {

            Payment P = new Payment();
            var NameExist = _asu.Patients.ToList().Any(u => u.Name == m.PatientName);

            if (NameExist)
            {
                var patientid = _asu.Patients
                .Where(i => i.Name == m.PatientName)
                .Select(m => m.Id)
                .Single();

                // TempData["patientbill"]


                var patientbill = _asu.Payments.Include(p => p.Patient).Include(f => f.Follow_Up_Type)
              .Where(i => (i.Patient_Id == patientid) && (i.Payed == false))
              .ToList();

          
                ViewBag.p_bill =  patientbill;
                int total = 0;
                foreach(var y in patientbill) 
                {
                    total = total+y.Money;
                }
                ViewBag.Total = total;
               
                return View();

               // return Redirect("/finance/Billresult");
            }

            else
            {
                ViewBag.NameDoesntExist = "Patient Doesn't Exist";
                return View();
            }
        }

    }
}
