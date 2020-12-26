using Ain_Shams_Hospital.Data;
using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels.DoctorVM;
using HospitalManagementSystem.Data;
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
        public IActionResult PatientFollowUp( MainVM m)
        {
            int patient_id = m.P_Id;
            //int patient_id = 1;
            //var Patient = _auc.Patients.Where(i => i.Id == patient_id);
            //var Patient_Name = Patient.Select(i => i.Name).Single();
            /* var result = _auc.Patients
                 .Where(O => O.Id == patient_id)
                 .Select(I =>new {I.Name,I.Phone,I.Medical_Record })
                 .ToList();*/

            /*var two = _auc.Patients
                .Where(O => O.Id == 1)
                .Select(I => I.Phone)
                .Single();*/
            /*var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                 .ToList();*/
            // regestration_id[0].Registration.Email.Single();
            // var mail = regestration_id[0].Registration.Email;
            /*var Medical_Record = _auc.Patients
                  .Where(O => O.Id == patient_id)
                  .Select(I => I.Medical_Record)
                  .Single();*/
            var result = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => I.Name)
                .Single();

            var two = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => I.Phone)
                .Single();
            var regestration_id = _auc.Patients
                .Where(O => O.Id == patient_id)
                 .Select(I => I.Registration_Id)
                 .Single();
            var mail = _auc.Registrations
                .Where(O => O.Id == regestration_id)
                 .Select(I => I.Email)
                 .Single();
            var Medical_Record = _auc.Patients
                  .Where(O => O.Id == patient_id)
                  .Select(I => I.Medical_Record)
                  .Single();
            ViewBag.data1 = result;
            ViewBag.data2 = two;
            ViewBag.data3 = mail;
            ViewBag.data4 = Medical_Record;
           
             
            
            
            /*var result = _auc.Patients
                 .Where(O => O.Id == patient_id)
                 .Select(I => new {I.Name,I.Phone})
                 .ToList();
            ViewBag.data1 = result;*/

            return View();
            
        }
        [HttpPost]
        public IActionResult PatientFollowUp(PatientFollowUpVM obj, MainVM m)
        {
            int patient_id = m.P_Id;
            //int patient_id = 1;
            Patient patient ;
            patient = _auc.Patients
                       .Where(i => i.Id == patient_id).FirstOrDefault();
            patient.Medical_Record = patient.Medical_Record + " " + obj.Medical_Record;
            ViewBag.UserMessage = "edit send";
            //_auc.Add(patient);
            _auc.SaveChanges();
            ModelState.Clear();


            /*var result = _auc.Patients
                 .Where(O => O.Id == patient_id)
                 .Select(I => new { I.Name, I.Phone, I.Medical_Record })
                 .ToList();

            /*var two = _auc.Patients
                .Where(O => O.Id == 1)
                .Select(I => I.Phone)
                .Single();
            var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                 .ToList();
            // regestration_id[0].Registration.Email.Single();
            var mail = regestration_id[0].Registration.Email;
            /*var Medical_Record = _auc.Patients
                  .Where(O => O.Id == patient_id)
                  .Select(I => I.Medical_Record)
                  .Single();
            ViewBag.data1 = result;

            ViewBag.data3 = mail;*/
            var result = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => I.Name)
                .Single();

            var two = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => I.Phone)
                .Single();
            var regestration_id = _auc.Patients
                .Where(O => O.Id == patient_id)
                 .Select(I => I.Registration_Id)
                 .Single();
            var mail = _auc.Registrations
                .Where(O => O.Id == regestration_id)
                 .Select(I => I.Email)
                 .Single();
            var Medical_Record = _auc.Patients
                  .Where(O => O.Id == patient_id)
                  .Select(I => I.Medical_Record)
                  .Single();
            ViewBag.data1 = result;
            ViewBag.data2 = two;
            ViewBag.data3 = mail;
            ViewBag.data4 = Medical_Record;

            return View();

        }
        public IActionResult Transfer()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Main()
        {
            int Doctor_Reg_Id = (int)TempData["User_Reg_Id"];
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();

            var Patients_FollowUps = _auc.Follow_Ups
                .Where(d => d.Staff_Id == Doctor_Id)
                .Select(p => new { p.Patient_Id, p.Id })
                .ToList();

            /*var Details = _auc.Follow_Ups_History
                .Include(f => f.Follow_Up_Type)
                .ToList();
            */
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
