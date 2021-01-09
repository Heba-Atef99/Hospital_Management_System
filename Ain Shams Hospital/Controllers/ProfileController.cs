using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return View(_HDB.Registrations.Find(Patient_Reg_Id));
        }
    }
}
