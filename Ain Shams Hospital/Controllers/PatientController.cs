using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult labSpecialist()
        {
            return View();
        }
        public IActionResult EyesDoctor()
        {
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
