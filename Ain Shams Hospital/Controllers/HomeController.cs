using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.Models;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace Ain_Shams_Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDbContext _auc;
        public HomeController(HospitalDbContext auc)
        {
            _auc = auc;
        }

      
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Registration user)
        {
            _auc.Add(user);
            _auc.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Patient()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Patient(Patient pat)
        {
            _auc.Add(pat);
            _auc.SaveChanges();
            return View();
        }
        [HttpGet]
        public IActionResult Staff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Staff(Staff doc)
        {
            _auc.Add(doc);
            _auc.SaveChanges();
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        ///login
        SqlConnection con = new SqlConnection();
        SqlCommand co = new SqlCommand();
        SqlDataReader dr;
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        //that is for connection to sql server
        void connectionSting()
        {
            con.ConnectionString = "data soutce =(localdb)ProjectsV13 ; database=HospitalDb; integrated securty =SSPI;";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult verify(Account acc)
        {
            connectionSting();
            con.Open();
            co.Connection = con;
            co.CommandText = "select * form Registrations where Email='"+acc.Email+"' and Password='"+acc.Password+"' ";
            dr = co.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View();
            }
            else
            {
                con.Close();
                return View("error");
            }
            
        }

    }
}
