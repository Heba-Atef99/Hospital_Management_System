using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_University.ViewModels;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _HDB;

        public PatientController(HospitalDbContext HDB)
        {
            _HDB = HDB;
        }

        public IActionResult labSpecialist()
        {

            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == 22).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--selsct your doctor--" });
            ViewBag.massege = s1;
            return View();
            return View();
        }
        public IActionResult EyesDoctor(Specialization obj)
        {
           
                List<Staff> s1 = new List<Staff>();
                s1 = (from s in _HDB.Staff select s).Where(f=>f.Specialization_Id==12).ToList();
                s1.Insert(0, new Staff { Id = 0, Name = "--selsct your doctor--" });
                ViewBag.massege = s1;
                return View();
       }
        public IActionResult  BabyDoctor()
        {

            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == 10).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--selsct your doctor--" });
            ViewBag.massege = s1;
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BabyDoctor(BabyDoctorVM bd)
        {
            Follow_Up_History fup = new Follow_Up_History();
            fup.Date = bd.Date;
            fup.Follow_Up_Type_Id = 2;

            _HDB.Add(fup);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";
            return View();
        }
        public IActionResult Surgeon()
        {

            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == 9).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--selsct your doctor--" });
            ViewBag.massege = s1;
            return View();
            return View();
        }
    }
}
