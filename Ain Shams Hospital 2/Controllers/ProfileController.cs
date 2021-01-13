using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_University.ViewModels;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

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
            int patient_Id = _HDB.Patients.Where(e => e.Registration_Id == Patient_Reg_Id).Select(a=>a.Id).SingleOrDefault();
            return View(_HDB.Patients.Find(patient_Id));
        }
        public IActionResult UpdatePicture(PictureVM obj)
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int patient_Id = _HDB.Patients.Where(e => e.Registration_Id == Patient_Reg_Id).Select(a => a.Id).SingleOrDefault();
            if (patient_Id == 0)
            {
                return RedirectToAction("Login", "Registration");
            }
            var file = obj.Picture;
            Patient u = _HDB.Patients.Find(patient_Id);
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string id_and_extension = patient_Id + extension;
                string imgUrl = "~/Profile Images/" + id_and_extension;
                u.Image = imgUrl;
                _HDB.Entry(u).State = EntityState.Modified;
                _HDB.SaveChanges();

                var path = Server.MapPath("~/Profile Images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if ((System.IO.File.Exists(path + id_and_extension)))
                {
                    System.IO.File.Delete(path + id_and_extension);
                }
                file.SaveAs((path + id_and_extension));

            }
            return RedirectToAction("UserProfile"); 
        }
    }
}
