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
using Ain_Shams_Hospital.ViewModels;

namespace Ain_Shams_Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly HospitalDbContext _auc;
        public HomeController(HospitalDbContext auc)
        {
            _auc = auc;
        }



        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult Staff()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RegistrationPatient()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationPatient(RegistrationPatientVM obj)
        {
            Registration r = new Registration();
            r.Email = obj.Email;
            r.Password = obj.Password;
            _auc.Add(r);
            _auc.SaveChanges();
            Patient P = new Patient();
            P.Name = obj.Name;
            P.Phone = obj.Phone;
            P.Registration_Id = r.Id;

            _auc.Add(P);
            _auc.SaveChanges();
            return Redirect("/Home/Ptient");
        }
        [HttpGet]
        public IActionResult RegistrationStaff()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrationStaff(RegistrationStaffVM objc)
        {
            Registration R = new Registration();
            R.Email = objc.Email;
            R.Password = objc.Password;
            _auc.Add(R);
            _auc.SaveChanges();
            Staff S = new Staff();
            S.Name = objc.Name;
            S.Phone = objc.Phone;
            S.Starting_Day = objc.Starting_Day;

            _auc.Add(S);
            _auc.SaveChanges();
            return Redirect("/Home/Staff");
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
