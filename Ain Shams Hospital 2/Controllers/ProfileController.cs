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
using Microsoft.EntityFrameworkCore;

namespace Ain_Shams_University.Controllers
{
    public class ProfileController : Controller
    {
        private readonly HospitalDbContext _HDB;

        public ProfileController(HospitalDbContext HDB)
        {
            _HDB = HDB;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult UserProfile()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int patiant_Id = _HDB.Patients.Where(o => o.Registration_Id == Patient_Reg_Id).Select(i => i.Id).SingleOrDefault();
            return View(_HDB.Patients.Find(patiant_Id));
        }

        public IActionResult Edit(int id =0)
        {
            Patient pa = _HDB.Patients.Find(id);
            if (pa == null)
            {
                return NotFound();
            }
            
            return View(pa);
        }
        [HttpPost]
        public IActionResult Edit(Patient pa)
        {
            if (ModelState.IsValid)
            {
                _HDB.Entry(pa).State = EntityState.Modified;
                _HDB.SaveChanges();
                return RedirectToAction("UserProfile");
            }
            return View(pa);
        }
    }
}
