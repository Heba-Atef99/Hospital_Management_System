using Ain_Shams_Hospital.Data;
using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels.DoctorVM;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Controllers
{
    /*public static class SessionExtensions
    {
        public static T GetComplexData<T>(this ISession session, string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }*/

    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _auc;
        // private readonly IHospitalRepository _repository;
        public DoctorController(HospitalDbContext auc)
        {
            _auc = auc;
            //_repository = repository;
        }


        [HttpGet]
        public IActionResult PatientFollowUp()
        {
            // int patient_id =(int) TempData["p_id"];
            int patient_id = (int)HttpContext.Session.GetInt32("Patient_Id");
            var result = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => new Patient { Name = I.Name, Phone = I.Phone, Medical_Record = I.Medical_Record })
                .ToList();

            var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                .ToList();
            var mail = regestration_id[0].Registration.Email;

            ViewBag.data1 = result;
            ViewBag.data3 = mail;

            return View();
        }

        [HttpPost]
        public IActionResult PatientFollowUp(PatientFollowUpVM obj)
        {
            int patient_id = (int)HttpContext.Session.GetInt32("Patient_Id");
            Patient patient;
            patient = _auc.Patients.Where(i => i.Id == patient_id).FirstOrDefault();
            patient.Medical_Record = patient.Medical_Record + " " + obj.Medical_Record;
            ViewBag.UserMessage = "edit send";
            _auc.SaveChanges();
            ModelState.Clear();

            var result = _auc.Patients
                 .Where(O => O.Id == patient_id)
                 .Select(I => new Patient { Name = I.Name, Phone = I.Phone, Medical_Record = I.Medical_Record })
                 .ToList();

            var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                 .ToList();
            var mail = regestration_id[0].Registration.Email;
            ViewBag.data1 = result;
            ViewBag.data3 = mail;
            return View();
        }
        public IActionResult Transfer()
        {
            
            return View();
        }
        [HttpGet]
        public IActionResult Emergency()
        {
            var result = _auc.Blood_Units
                .Select(I => new Blood_Unit { Type = I.Type, Amount = I.Amount})
                .ToList();
            ViewBag.Blood_Units = result;
            var facility = _auc.Hospital_Facilities
                .Where(i => i.Type.Substring(0, 13) == "Emergency bed")
                .Select(n => new Hospital_Facility { Type = n.Type, Available = n.Available,
                    Start_Working_Hour =n.Start_Working_Hour, End_Working_Hour=n.End_Working_Hour   })
                .ToList();
            ViewBag.Hospital_Facility = facility;
            return View();
        }

        [HttpPost]
        public IActionResult Main(MainVM m)
        {
            if (m.P_Id != 0)
            {
                HttpContext.Session.SetInt32("Patient_Id", m.P_Id);
                return Redirect("/Doctor/PatientFollowUp");
            }

            //HttpContext.Session.SetString("SearchItem", m.Search_Item);

            TempData["SearchItem"] = m.Search_Item;

            /*
            List<Tuple<Patient, Follow_Up_History>> MainView = HttpContext.Session.GetComplexData<List<Tuple<Patient, Follow_Up_History>>>("MainViewList");
            var searchString = m.Search_Item;
            if (searchString == null)
            {
                ViewBag.follow_ups = MainView;
                return View();
            }

            ViewBag.follow_ups = (List<Tuple<Patient, Follow_Up_History>>)MainView.Where(s => s.Item1.Id.ToString().Contains(searchString) || s.Item1.Name.Contains(searchString) 
            || s.Item2.Follow_Up_Type.Name.Contains(searchString))
                .ToList();
            this.ModelState.Clear();
            m.Search_Item = null;*/
            return Redirect("/Doctor/Main");
            //return View();
        }

        [HttpGet]
        public IActionResult Main()
        {
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();

            var Patients_FollowUps = _auc.Follow_Ups
                .Where(d => d.Staff_Id == Doctor_Id)
                .Select(p => new { p.Patient_Id, p.Id })
                .ToList();

            List<Patient> patient = new List<Patient>();
            List<Follow_Up_History> follow_up = new List<Follow_Up_History>();
            var patient_join_follow_up = new List<Tuple<Patient, Follow_Up_History>>();
            int i = 0;
            foreach (var _P in Patients_FollowUps)
            {
                patient.Add(_auc.Patients
                    .Where(p => p.Id == _P.Patient_Id)
                    .Single());

                follow_up.Add(_auc.Follow_Ups_History
                .Include(f => f.Follow_Up_Type)
                .Where(f => f.Follow_Up_Id == _P.Id)
                .Single());

                patient_join_follow_up.Add(new Tuple<Patient, Follow_Up_History>(patient[i], follow_up[i]));
                ++i;
            }

            //HttpContext.Session.SetComplexData("MainViewList", patient_join_follow_up);

            var searchString = TempData["SearchItem"] == null ? null : TempData["SearchItem"].ToString();
            if (searchString != null)
            {
                ViewBag.follow_ups = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up.Where(s => s.Item1.Id.ToString().Contains(searchString) || s.Item1.Name.Contains(searchString)
                || s.Item2.Follow_Up_Type.Name.Contains(searchString))
                    .ToList();
                return View();
            }
            ViewBag.follow_ups = patient_join_follow_up;

            return View();
        }
        [HttpGet]
        public IActionResult AnotherHospital()
        {
            var Transfer_Hospitals = _auc.Transfer_Hospitals.ToList();
            ViewBag.Transfer_Hospitals = Transfer_Hospitals;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AnotherHospital(TransferAnotherHospitalVM obj)
        {
            //Patient r = new Patient();
            int patient_id = (int)HttpContext.Session.GetInt32("Patient_Id");
            //var patient_id = 1;
            Patient patient;
            patient = _auc.Patients
                       .Where(i => i.Id == patient_id).FirstOrDefault();
            //r.Id = 1;

            //var HID = _auc.Transfer_Hospitals.Where(f => f.Name == obj.HospitalName).Select(s => s.Id).Single();
            patient.Hospital_Id = obj.HospitalId;
            _auc.SaveChanges();
            var Transfer_Hospitals = _auc.Transfer_Hospitals.ToList();
            ViewBag.Transfer_Hospitals = Transfer_Hospitals;

            //_auc.Add(r);


            return View();
        }
        [HttpGet]
        public IActionResult AnotherDepartment()
        {

            var OtherDep = _auc.Specializations.Where(j => j.Code.Substring(0, 1) == "1")
                .Select(s => new Specialization { Name = s.Name, Id = s.Id }).ToList();
            ViewBag.OtherDep = OtherDep;
            var OtherDoc = _auc.Staff.Select(n => new Staff { Name = n.Name, Specialization_Id = n.Specialization_Id, Id = n.Id }).ToList();
            ViewBag.OtherDoc = OtherDoc;
            return View();
        }
    }
}
