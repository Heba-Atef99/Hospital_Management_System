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

namespace Ain_Shams_Hospital.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _HDB;

        public PatientController(HospitalDbContext HDB)
        {
            _HDB = HDB;
        }

        public IActionResult Home()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            ViewBag.patientname = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Name).SingleOrDefault();

            return View();
        }

        public IActionResult LabSpecialist()
        {

            List<Follow_Up_Type> s1 = new List<Follow_Up_Type>();
            s1 = (from s in _HDB.Follow_Ups_Types select s).ToList();
            s1.Insert(0, new Follow_Up_Type { Id = 0, Name = "--Select Your Test--" });
            ViewBag.massege = s1;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LabSpecialist(labSpecialistVM bd)
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            Follow_Up fup = new Follow_Up();
            fup.Patient_Id = Patient_Id;
            fup.Status = "Pending";
            fup.Staff_Id = 13;
            _HDB.Add(fup);
            _HDB.SaveChanges();

            Follow_Up_History fuph = new Follow_Up_History();
            fuph.Date = bd.Date + "T" + bd.Hour;
            fuph.Follow_Up_Type_Id = bd.Id;            ////Done
            fuph.Follow_Up_Id = fup.Id;

            _HDB.Add(fuph);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";
            HttpContext.Session.SetInt32("choose_test", (int)bd.Id);
            bool ofon = _HDB.Payments.Where(o => o.Patient_Id == Patient_Id).Select(i => i.Online).FirstOrDefault();
            if (ofon) 
            {
                return RedirectToAction("Payment", "Patient");

            }
            return RedirectToAction("offlinepay", "Patient");
        }
        public IActionResult SelectDoctor()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            ViewBag.patientname = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Name).SingleOrDefault();


            List<Specialization> s1 = new List<Specialization>();
            s1 = (from s in _HDB.Specializations select s).Where(n => n.Id >= 2 && n.Id <= 12).ToList();
            s1.Insert(0, new Specialization { Id = 0, Name = "--select your doctor--" });

            ViewBag.massege = s1;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SelectDoctor(SelectDoctorVM sd)
        {
            HttpContext.Session.SetInt32("Doctor_Sp_Id", (int)sd.Id);
            return RedirectToAction("Doctor", "Patient");
        }

        public IActionResult Doctor(Specialization obj)
        {

            int Doctor_sp_Id = (int)HttpContext.Session.GetInt32("Doctor_Sp_Id");

            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == Doctor_sp_Id).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--select your doctor--" });
            ViewBag.massege = s1;
           // HttpContext.Session.SetInt32("choose_test", (int)obj.Id);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Doctor(DoctorVM doc)
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();


            Follow_Up fup = new Follow_Up();
            fup.Patient_Id = Patient_Id;
            fup.Staff_Id = doc.Id;
            fup.Status = "Pending";

            _HDB.Add(fup);
            _HDB.SaveChanges();

            Follow_Up_History fuph = new Follow_Up_History();
            fuph.Date = doc.Date+"T"+doc.Hour;
            fuph.Follow_Up_Type_Id = 2;
            fuph.Follow_Up_Id = fup.Id;

            _HDB.Add(fuph);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";
            HttpContext.Session.SetInt32("choose_test", 2);

            bool ofon = _HDB.Payments.Where(o => o.Patient_Id == Patient_Id).Select(i => i.Online).FirstOrDefault();
            if (ofon)
            {
                return RedirectToAction("Payment", "Patient");

            }
            return RedirectToAction("offlinepay", "Patient");


        }

        public IActionResult Surgeon()
        {

            List<Staff> s1 = new List<Staff>();
            s1 = (from s in _HDB.Staff select s).Where(f => f.Specialization_Id == 9).ToList();
            s1.Insert(0, new Staff { Id = 0, Name = "--select your doctor--" });
            ViewBag.massege = s1;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Surgeon(SurgeonVM bd)
        {

            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            Follow_Up fup = new Follow_Up();
            fup.Patient_Id = Patient_Id;
            fup.Staff_Id = bd.Id;
            fup.Status = "Pending";

            _HDB.Add(fup);
            _HDB.SaveChanges();

            Follow_Up_History fuph = new Follow_Up_History();
            fuph.Date = bd.Date + "T" + bd.Hour;
            fuph.Follow_Up_Type_Id = 1;
            fuph.Follow_Up_Id = fup.Id;

            _HDB.Add(fuph);
            _HDB.SaveChanges();
            ViewBag.message = "Your Time has been recorded";
            HttpContext.Session.SetInt32("choose_test", 1);
            bool ofon = _HDB.Payments.Where(o => o.Patient_Id == Patient_Id).Select(i => i.Online).FirstOrDefault();
            if (ofon)
            {
                return RedirectToAction("Payment", "Patient");

            }
            return RedirectToAction("offlinepay", "Patient");
        }
        public IActionResult services()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Services(servicesVM s)
        {
            return RedirectToAction("Payment", "Patient");

        }
        public IActionResult FollowedDoctors()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            var ids = _HDB.Follow_Ups.Where(o => o.Patient_Id == Patient_Id).Select(s => s.Staff_Id).ToList();
            /*var x = _HDB.Follow_Ups_History.Where(f => f.Date == "").ToList();*/
            /*var id_folup = _HDB.Follow_Ups.Where(o => o.Patient_Id == Patient_Id).Select(s => s.Id).FirstOrDefault();*/
            var fuph_id = _HDB.Follow_Ups_History.Where(i => i.Date == "").Select(a => a.Id).FirstOrDefault();
            var id_folup = _HDB.Follow_Ups_History.Where(y => y.Date == "" && y.Id == fuph_id).Select(a => a.Follow_Up_Id).SingleOrDefault();
            var Dat = _HDB.Follow_Ups_History.Where(i => i.Follow_Up_Id== id_folup).Select(a => a.Date).FirstOrDefault();
            
            if (Dat == "")
            {
                HttpContext.Session.SetInt32("Followup_Id", (int)id_folup);
                HttpContext.Session.SetInt32("Fuph_Id", fuph_id);
                return RedirectToAction("DateEdit", "Patient");
            }
            else
            {
                List<Staff> s1 = new List<Staff>();
                s1.Insert(0, new Staff { Id = 0, Name = "--show your doctor--" });
                foreach (var i in ids)
                {
                    /*s1 = (from s in _HDB.Staff select s).Where(o => o.Id == i).ToList();*/
                    s1.Add(_HDB.Staff.Where(o => o.Id == i).SingleOrDefault());
                }
                ViewBag.massege2 = s1.Distinct();
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FollowedDoctors(FollowedDoctorsVM fc)
        {
            HttpContext.Session.SetInt32("sel_Id", (int)fc.Id);
            return RedirectToAction("DoctorSchedules", "Patient");
        }
        public IActionResult DateEdit()//for patient transfer
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DateEdit(DateEditePTVM pt)
        {
            int fup_Id = (int)HttpContext.Session.GetInt32("Followup_Id");
            int fuph_Id = (int)HttpContext.Session.GetInt32("Fuph_Id");
            Follow_Up_History fh = new Follow_Up_History { Follow_Up_Id=fup_Id, Date=pt.DateEdite+"T"+pt.Hour,Id=fuph_Id};
            /*fh.Date = pt.DateEdite;*/
            _HDB.Follow_Ups_History.Update(fh);
            _HDB.SaveChanges();
            return View();
        }
        public IActionResult DoctorSchedules()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            ViewBag.patientname = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Name).SingleOrDefault();
            int selId = (int)HttpContext.Session.GetInt32("sel_Id");
            var dr = _HDB.Staff.Where(s => s.Id == selId).Select(d => d.Name).SingleOrDefault();
            ViewBag.dr = dr;
            var sp_Id = _HDB.Staff.Where(e => e.Id == selId).Select(y => y.Specialization_Id).SingleOrDefault();
            var Working_Day = _HDB.Staff_Schedules.Where(s => s.Specialization_Id == sp_Id).Select(r=>r.Working_Day).SingleOrDefault();
            List<string> list1 = new List<string>();
            //random
            if (sp_Id == 10 || sp_Id == 12 || sp_Id == 14)
            {
                list1.Add("Sunday");
                list1.Add("Monday");
                list1.Add("Wednesday");
                list1.Add("Thursday");
            }
            else
            {
                list1.Add("Sunday");
                list1.Add("Monday");
                list1.Add("Tuesday");
                list1.Add("Thursday"); 
            }
            ViewBag.listdays = list1;
            ViewBag.workingday = Working_Day;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DoctorSchedules(DoctorScheduleVM ds)
        {
            return View();
        }

        [HttpGet]
        public IActionResult offlinepay()
        {
            return View();
        }
        [HttpPost]
        public IActionResult offlinepay(offlinepay po)
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            int test_Id = (int)HttpContext.Session.GetInt32("choose_test");
            int pay = _HDB.Follow_Ups_Types.Where(i => i.Id == test_Id).Select(l => l.Price).SingleOrDefault();
            ViewBag.massage = pay;

            string dat = _HDB.Follow_Ups_History.Where(o => o.Follow_Up_Type_Id == test_Id).Select(i => i.Date).FirstOrDefault();


            Payment pa = new Payment();
            pa.Patient_Id = Patient_Id;
            pa.Online = false;
            pa.Money = pay;
            pa.Follow_Up_Type_Id = test_Id;
            pa.Date = dat;
            _HDB.Add(pa);
            _HDB.SaveChanges();


            return View();
        }
        [HttpGet]
        public IActionResult Payment()
        {
            int Patient_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Patient_Id = _HDB.Patients.Where(f => f.Registration_Id == Patient_Reg_Id).Select(h => h.Id).SingleOrDefault();

            int test_Id = (int)HttpContext.Session.GetInt32("choose_test");
            int pay = _HDB.Follow_Ups_Types.Where(i => i.Id == test_Id).Select(l => l.Price).SingleOrDefault();
            ViewBag.massage = pay;

            string dat = _HDB.Follow_Ups_History.Where(o => o.Follow_Up_Type_Id == test_Id).Select(i => i.Date).FirstOrDefault();


            Payment pa = new Payment();
            pa.Patient_Id = Patient_Id;
            pa.Online = true;
            pa.Money = pay;
            pa.Follow_Up_Type_Id = test_Id;
            pa.Date = dat;
            if (pa.Money == pay)
            {
                pa.Payed = true;
            }
            else
            {
                pa.Payed = false;
            }
            _HDB.Add(pa);
            _HDB.SaveChanges();


            return View();
        }
        [HttpPost]
        public IActionResult Payment(PaymentVM p)
        {
            return RedirectToAction("savepay", "Patient") ;
        }
        public ActionResult savepay()
        {
            return View();
        }
         
    }
}
