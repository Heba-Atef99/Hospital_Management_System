using Ain_Shams_Hospital.Controllers;
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
    [CheckXActionFilterAttribute]
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
        
        public IActionResult Statechart()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Stateview(mainVM m)
        {
            var ID = _asu.Follow_Ups_Types.Where(f => f.Name == m.Room_Id).Select(s => s.Id).Single();
            String from = HttpContext.Session.GetString("FIRST");
            String to = HttpContext.Session.GetString("LAST");
            if (from != null && to != null)
            {
                var h = _asu.Payments.Include(o => o.Patient).Include(p => p.Follow_Up_Type)
                .Where(f => (f.Follow_Up_Type_Id == ID && f.Payed == true))
              .ToList();
                DateTime start = DateTime.Parse(from);
                DateTime end = DateTime.Parse(to);
                List<Payment> payment = new List<Payment>();

                var total = 0;
                foreach (var V in h)
                {

                    DateTime date = DateTime.Parse(V.Date);

                    if (date >= start && date <= end)
                    {
                        total = total + V.Money;
                        payment.Add(V);
                    }

                }


                ViewBag.R = m.Room_Id;
                ViewBag.t = total;
                // ViewBag.D = h;
                ViewBag.list = payment;
                return View();
            }
            else
            {

                return Redirect("/Manager/Error");
            }


        }
        public IActionResult Stateview1()
        {
            String from = HttpContext.Session.GetString("FIRST");
            String to = HttpContext.Session.GetString("LAST");
            if (from != null && to != null)
            {
                var h = _asu.Payments.Include(o => o.Patient).Include(p => p.Follow_Up_Type)
                   .Where(f => f.Payed == true).ToList();
                DateTime start = DateTime.Parse(from);
                DateTime end = DateTime.Parse(to);
                List<Payment> payment1 = new List<Payment>();
                var total = 0;
                foreach (var V in h)
                {

                    DateTime date = DateTime.Parse(V.Date);

                    if (date >= start && date <= end)
                    {
                        total = total + V.Money;

                        payment1.Add(V);
                    }

                }
                // ViewBag.R = m.Room_Id;
                ViewBag.t = total;
                // ViewBag.D = h;
                ViewBag.list1 = payment1;

                return View();
            }
            else
            {

                return Redirect("/Manager/Error");
            }
        }
        public IActionResult Error()
        {
            ViewBag.fail = "You have to enter the dates From and To first";
            return View();
        }

        /*public IActionResult Stateview1()
        {
            String from = HttpContext.Session.GetString("FIRST");
            String to = HttpContext.Session.GetString("LAST");
            var h = _asu.Payments.Include(o => o.Patient).Include(p => p.Follow_Up_Type)
               .Where(f => f.Payed == true).ToList();
            DateTime start = DateTime.Parse(from);
            DateTime end = DateTime.Parse(to);
            List<Payment> payment1 = new List<Payment>();
            var total = 0;
            foreach (var V in h)
            {

                DateTime date = DateTime.Parse(V.Date);

                if (date >= start && date <= end)
                {
                    total = total + V.Money;

                    payment1.Add(V);
                }

            }
           // ViewBag.R = m.Room_Id;
            ViewBag.t = total;
            // ViewBag.D = h;
            ViewBag.list1 = payment1;
         
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
            String from = HttpContext.Session.GetString("FIRST");
            String to = HttpContext.Session.GetString("LAST");

            var h = _asu.Payments.Include(o=>o.Patient).Include(p => p.Follow_Up_Type)
                .Where(f => (f.Follow_Up_Type_Id == ID && f.Payed==true))
              .ToList();
           DateTime start = DateTime.Parse(from);
            DateTime end = DateTime.Parse(to);
            List<Payment> payment = new List<Payment>();
            // if (from!=null && to != null)
            //{
            var total = 0;
            foreach (var V in h)
            {
 
                DateTime date = DateTime.Parse(V.Date);
                
                if (date >= start && date <= end)
                {
                    total = total + V.Money;
                    payment.Add(V);
                }
                
            }

            
            ViewBag.R = m.Room_Id;
            ViewBag.t = total;
            // ViewBag.D = h;
            ViewBag.list = payment;
            return View();
        
            
        }*/
        [HttpGet]
        public IActionResult State()
        {
            var Type = _asu.Follow_Ups_Types.ToList();
            ViewBag.type = Type;
           
            return View();
        }
        [HttpPost]
        public IActionResult State(FinanceInterval obj)
        {
            var Type = _asu.Follow_Ups_Types.ToList();
            ViewBag.type = Type;
            HttpContext.Session.SetString("FIRST", obj.From);
            HttpContext.Session.SetString("LAST", obj.To);

            return View();
        }
        [HttpGet]
        public IActionResult Homepage()
        {
            //var Type = _asu.Follow_Ups_Types.ToList();
            //ViewBag.type = Type;
            int Staff_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            string Staff_Name = _asu.Staff.Where(f => f.Registration_Id == Staff_Reg_Id).Select(h => h.Name).SingleOrDefault();
            ViewBag.User = Staff_Name;
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
