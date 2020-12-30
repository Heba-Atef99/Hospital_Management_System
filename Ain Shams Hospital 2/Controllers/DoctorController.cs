using Ain_Shams_Hospital.Data;
using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels.DoctorVM;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Controllers
{
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
            //TempData["p_id"] = patient_id;
            Patient patient;
            patient = _auc.Patients.Where(i => i.Id == patient_id).FirstOrDefault();
            patient.Medical_Record = patient.Medical_Record + " " + obj.Medical_Record;
            ViewBag.UserMessage = "edit send";
            //_auc.Add(patient);
            _auc.SaveChanges();
            ModelState.Clear();

            //List<Patient> result = new List<Patient>;

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

        [HttpPost]
        public IActionResult Main(MainVM m)
        {
            HttpContext.Session.SetInt32("Patient_Id", m.P_Id);
            return Redirect("/Doctor/PatientFollowUp");
        }

        [HttpGet]
        public IActionResult Main()
        {
            //HttpContext.Session.SetInt32("Patient_Id", m.P_Id);
            //int Doctor_Reg_Id = (int)TempData["User_Reg_Id"];
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

            ViewBag.follow_ups = patient_join_follow_up;
            return View();
        }

    }
}
