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
            string Date=HttpContext.Session.GetString("Today");
            foreach (var mn in m.isactive)
            {
                var payed = _asu.Payments.Where(f => f.Id == mn).Single();
                payed.Payed = true;
                payed.Date = Date;
                _asu.SaveChanges();
                ViewBag.d = "done";
            }
            return View();
           
        }
        [HttpGet]
        public IActionResult Stateview()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Stateview(mainVM m)
        {
            var ID = _asu.Follow_Ups_Types.Where(f => f.Name == m.Room_Id).Select(s => s.Id).Single();
            var h = _asu.Payments.Include(o=>o.Patient).Include(p => p.Follow_Up_Type)
                .Where(f => (f.Follow_Up_Type_Id == ID && f.Payed==true))
              .ToList();
            ViewBag.D = h;
            ViewBag.R = m.Room_Id;
            return View();
        }
        [HttpGet]
        public IActionResult State()
        {
            var Type = _asu.Follow_Ups_Types.ToList();
            ViewBag.type = Type;
           
            return View();
        }
        [HttpGet]
        public IActionResult Homepage()
        {
            var Type = _asu.Follow_Ups_Types.ToList();
            ViewBag.type = Type;

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
            ViewBag.name = m.PatientName;

             Payment P = new Payment();
            
             var NameExist = _asu.Patients.ToList().Any(u => u.Name == m.PatientName);
          
            //var NameExistReservation = _asu.Patients.ToList().Any(u => u.Name == m.PatientName);
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
           
                HttpContext.Session.SetString("Today", m.Todaydate);
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
