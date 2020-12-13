using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Controllers
{
    public class AccountController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
