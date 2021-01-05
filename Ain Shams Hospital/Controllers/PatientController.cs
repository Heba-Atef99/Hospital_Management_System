using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_University.ViewModels;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ain_Shams_Hospital.ViewModels;

namespace Ain_Shams_Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _HDB;

        public PatientController(HospitalDbContext HDB)
        {
            _HDB = HDB;
        }

        public IActionResult Home()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            ViewBag.patientname = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Name).SingleOrDefault();
            
            return View();
        }

        public IActionResult LabSpecialist()
        {

            List<Follow_Up_Type> s1 = new List<Follow_Up_Type>();
            s1 = (from s in _HDB.Follow_Ups_Types select s).ToList();
            s1.Insert(0, new Follow_Up_Type { Id = 0, Name = "--Select Your Test--" });
            ViewBag.massege = s1;
            return View();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LabSpecialist(labSpecialistVM bd)
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            Follow_Up fup = new Follow_Up();
            fup.Patient_Id = Patient_Id;
            fup.Status = "Pending";
            fup.Staff_Id = 7;
            _HDB.Add(fup);
            _HDB.SaveChanges();

            Follow_Up_History fuph = new Follow_Up_History();
            fuph.Date = bd.Date;
            fuph.Follow_Up_Type_Id = bd.Id;            ////Done
            fuph.Follow_Up_Id = fup.Id;
           
            _HDB.Add(fuph);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";
            return View();
        }
        public IActionResult SelectDoctor()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            ViewBag.patientname = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Name).SingleOrDefault();


            List<Specialization> s1 = new List<Specialization>();
            s1 = (from s in _HDB.Specializations select s).Where(n=>n.Id>=2 && n.Id<=12).ToList();
            s1.Insert(0, new Specialization { Id = 0, Name = "--select your doctor--"}) ;
            
            ViewBag.massege = s1;
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectDoctor(SelectDoctorVM sd)
        {
            HttpContext.Session.SetInt32("Doctor_Sp_Id", (int)sd.Id);
            return RedirectToAction("Doctor","Patient");
        }

        public IActionResult Doctor(Specialization obj)
        {

            int Doctor_sp_Id = (int)HttpContext.Session.GetInt32("Doctor_Sp_Id");
            
            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == Doctor_sp_Id).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--select your doctor--" });
            ViewBag.massege = s1;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Doctor(DoctorVM doc)
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();


            Follow_Up fup = new Follow_Up();
            fup.Patient_Id = Patient_Id;
            fup.Staff_Id = doc.Id;
            fup.Status = "Pending";

            _HDB.Add(fup);
            _HDB.SaveChanges();

            Follow_Up_History fuph = new Follow_Up_History();
            fuph.Date = doc.Date;
            fuph.Follow_Up_Type_Id = 2;
            fuph.Follow_Up_Id = fup.Id;

            _HDB.Add(fuph);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";

            return RedirectToAction("Payment", "Patient");
        }
 
        public IActionResult Surgeon()
        {

            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == 9).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--select your doctor--" });
            ViewBag.massege = s1;
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Surgeon(SurgeonVM bd)
        {

            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            Follow_Up fup = new Follow_Up();
            fup.Patient_Id = Patient_Id;
            fup.Staff_Id = bd.Id;
            fup.Status = "Pending";

            _HDB.Add(fup);
            _HDB.SaveChanges();

            Follow_Up_History fuph = new Follow_Up_History();
            fuph.Date = bd.Date;
            fuph.Follow_Up_Type_Id = 1;
            fuph.Follow_Up_Id = fup.Id;

            _HDB.Add(fuph);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
         
        public IActionResult FollowedDoctors()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();
            var id = _HDB.Follow_Ups.Where(o => o.Patient_Id == Patient_Id).Select(f => f.Staff_Id).ToList();
            foreach (var i in id)
            {

                List<Staff> s1 = new List<Staff>();
                s1 = (from s in _HDB.Staff select s).Where(o => o.Id == i).ToList();
                s1.Insert(0, new Staff { Id = 0, Name = "--show your doctor--" });
                ViewBag.massege2 = s1;
                View();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FollowedDoctors(FollowClass fc)
        {
            HttpContext.Session.SetInt32("Doctor_sel_Id", (int)fc.Id);
            return RedirectToAction("DoctorSchedules", "Patient");
        }

        public IActionResult DoctorSchedules()
        {
            int Doctor_sel_Id = (int)HttpContext.Session.GetInt32("Doctor_sel_Id");

            List<Staff_Schedule> s1 = new List<Staff_Schedule>();
            s1 = (from s in _HDB.Staff_Schedules select s).Where(f => f.Specialization_Id == Doctor_sel_Id).ToList();
            s1.Insert(0, new Staff_Schedule { Id = 0, Working_Day = "--show Doctor Schedules--" });
            ViewBag.masseg3 = s1;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoctorSchedules(DoctorSchedule ds)
        {
            return View();
        }
            public IActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Payment(PaymentVM p)
        {
            return View();
        }
    }
}
