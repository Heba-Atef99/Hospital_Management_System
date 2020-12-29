using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.Models;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Ain_Shams_Hospital.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Ain_Shams_Hospital.Controllers
{
    public class PatientController : Controller
    {

        private readonly HospitalDbContext _auc;
        public PatientController (HospitalDbContext auc)
        {
            _auc = auc;
        }

        public IActionResult labSpecialist()
        {
            return View();
        }
        public IActionResult EyesDoctor(RegistrationStaffVM objc)
        {
            Staff name = new Staff();
            var EmailExist = _auc.Staff.ToList().Any(u => u.Specialization_Id ==12);
            if (EmailExist)
            {
                List<Staff> s1 = new List<Staff>();
                s1 = (from s in _auc.Staff select s).ToList();
                s1.Insert(0, new Staff { Id = 0, Name = "--selsct your doctor--" });
                ViewBag.massege = s1;
                return View();

            }
            return View();
        }
        public IActionResult  BabyDoctor()
        {
            return View();
        }
        public IActionResult Surgeon()
        {
            return View();
        }
    }
}
