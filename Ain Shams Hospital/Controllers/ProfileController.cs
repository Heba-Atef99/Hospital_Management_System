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
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Ain_Shams_University.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly HospitalDbContext _HDB;
        private readonly IWebHostEnvironment WebHostEnvironment;
        public ProfileController(ILogger<ProfileController> logger, HospitalDbContext HDB
            ,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _HDB = HDB;
            webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var items = _HDB.Patients.ToList();
            return View();
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(PatientVM vm)
        {

            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();
            string nam = _HDB.Patients.Where(i => i.Id == Patient_Id).Select(u => u.Name).SingleOrDefault();
            string stringFileName = UploadFile(vm);
            var patient = new Patient
            {
                Id = Patient_Id,
                Name=nam,
                Phone= "01022299894",
                Registration_Id=12,
                Image = stringFileName,

            };
          
            _HDB.Patients.Update(patient);
            _HDB.SaveChanges();
            return RedirectToAction("Index");
        }

        private string UploadFile(PatientVM vm)
        {
            string fileName = null;
            if (vm.Image != null)
              {
                string uploadDir = "Profile Images";
                fileName = Guid.NewGuid().ToString() + "-" + vm.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    vm.Image.CopyTo(fileStream);
                }
            }
            return fileName;
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
