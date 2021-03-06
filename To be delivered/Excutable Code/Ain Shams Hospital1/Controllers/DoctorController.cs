﻿using Ain_Shams_Hospital.Data;
using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels.DoctorVM;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Controllers
{
   
    [CheckXActionFilterAttribute]
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _auc;
        // private readonly IHospitalRepository _repository;
        public DoctorController(HospitalDbContext auc)
        {
            _auc = auc;
        }

        [HttpGet]
        public IActionResult PatientFollowUp()
        {
            // int patient_id =(int) TempData["p_id"];
            int Follow_up_Id = (int)HttpContext.Session.GetInt32("Follow_up_Id");
            int patient_id = (int)_auc.Follow_Ups.Where(d => d.Id == Follow_up_Id)
                                            .Select(d => d.Patient_Id)
                                            .Single();
            var result = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => new Patient { Name = I.Name, Phone = I.Phone, Medical_Record = I.Medical_Record, Health_Progress = I.Health_Progress })
                .ToList();

           var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                .ToList();
            var mail = regestration_id[0].Registration.Email;
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();
            //&& d => d.Staff_Id == Doctor_Id
            var status = _auc.Follow_Ups
                .Where(d => d.Id == Follow_up_Id)
                .Select(d => d.Status)
                .Single();
            //var status  
            ViewBag.data1 = result;
            ViewBag.data3 = mail;
            ViewBag.status = status;
            return View();
        }

        [HttpPost]
        public IActionResult PatientFollowUp(PatientFollowUpVM obj)
        {
            int Follow_up_Id = (int)HttpContext.Session.GetInt32("Follow_up_Id");
            int patient_id = (int)_auc.Follow_Ups.Where(d => d.Id == Follow_up_Id)
                                            .Select(d => d.Patient_Id)
                                            .Single();
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();
            Patient patient;
            Follow_Up follow_Up;
            follow_Up = _auc.Follow_Ups.Where(d => d.Id == Follow_up_Id).FirstOrDefault();
            patient = _auc.Patients.Where(i => i.Id == patient_id).FirstOrDefault();
            patient.Medical_Record = patient.Medical_Record + " " + obj.Medical_Record;
            if (obj.Health_Progress != 0)
                patient.Health_Progress = obj.Health_Progress;
            if (obj.Status!= null)
                follow_Up.Status = obj.Status;
            _auc.SaveChanges();
            ModelState.Clear();

            var result = _auc.Patients
                 .Where(O => O.Id == patient_id)
                 .Select(I => new Patient { Name = I.Name, Phone = I.Phone, Medical_Record = I.Medical_Record, Health_Progress = I.Health_Progress })
                 .ToList();


            var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                 .ToList();
            var mail = regestration_id[0].Registration.Email;
            var status = _auc.Follow_Ups
                .Where(d =>  d.Id == Follow_up_Id)
                .Select(d => d.Status)
                .Single();
            ViewBag.data1 = result;
            ViewBag.data3 = mail;
            ViewBag.status = status;
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
        public IActionResult Main(MainVM m, string sort, string search)
        {
            if (m.P_Id != 0)
            {
                HttpContext.Session.SetInt32("Follow_up_Id", m.P_Id);
                return Redirect("/Doctor/PatientFollowUp");
            }

            if (!string.IsNullOrEmpty(search))
            {
                TempData["SearchItem"] = m.Search_Item;

            }
            if (!string.IsNullOrEmpty(sort))
            {
                TempData["SortItem"] = m.Sort_Item;
                TempData["OrderItem"] = m.Order_Item;
            }

            return Redirect("/Doctor/Main");
        }

        [HttpGet]
        public IActionResult Main()
        {
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            if(Doctor_Reg_Id == 0) return Redirect("/Home/Index");

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
                   .Include(p => p.Transfer_Hospital)
                   .Where(p => p.Id == _P.Patient_Id)
                   .Single());
               

                follow_up.Add(_auc.Follow_Ups_History
                .Include(f => f.Follow_Up_Type)
                .Include(f => f.Follow_Up)
                .Where(f => f.Follow_Up_Id == _P.Id)
                .Single());
                
                patient_join_follow_up.Add(new Tuple<Patient, Follow_Up_History>(patient[i], follow_up[i]));
                ++i;
            }

            var searchString = TempData["SearchItem"]?.ToString();
            if (searchString != null)
            {
                ViewBag.follow_ups = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up.Where(s => s.Item1.Id.ToString().Contains(searchString) || s.Item1.Name.Contains(searchString)
                || s.Item2.Follow_Up_Type.Name.Contains(searchString))
                    .ToList();
                return View();
            }

            patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up.
                        OrderByDescending(s => s.Item2.Date).ToList();

            var sortString = TempData["SortItem"]?.ToString();
            if (sortString != null)
            {
                var orderString = TempData["OrderItem"] == null? "DSC": TempData["OrderItem"].ToString();
                switch ((sortString, orderString))
                {
                    case ("Date", "DSC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderByDescending(s => s.Item2.Date)
                            .ToList();
                        break;
                    case ("Date", "ASC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderBy(s => s.Item2.Date)
                            .ToList();
                        break;
                    case ("Status", "DSC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderByDescending(s => s.Item2.Follow_Up.Status)
                            .ToList();
                        break;
                    case ("Status", "ASC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderBy(s => s.Item2.Follow_Up.Status)
                            .ToList();
                        break;
                    case ("Follow_Up", "DSC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderByDescending(s => s.Item2.Follow_Up_Type.Name)
                            .ToList();
                        break;
                    case ("Follow_Up", "ASC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderBy(s => s.Item2.Follow_Up_Type.Name)
                            .ToList();
                        break;
                    case ("Transfered", "DSC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderByDescending(s => s.Item1.Hospital_Id)
                            .ToList();
                        break;
                    case ("Transfered", "ASC"):
                        patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                            .OrderBy(s => s.Item1.Hospital_Id)
                            .ToList();
                        break;
                }

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
            int Follow_up_Id = (int)HttpContext.Session.GetInt32("Follow_up_Id");
            int patient_id = (int)_auc.Follow_Ups.Where(d => d.Id == Follow_up_Id)
                                            .Select(d => d.Patient_Id)
                                            .Single();
            //var patient_id = 2;
            Patient patient;
            patient = _auc.Patients
                       .Where(i => i.Id == patient_id).FirstOrDefault();
            Follow_Up follow;
            follow = _auc.Follow_Ups.FirstOrDefault(s => s.Patient_Id == patient_id);
            follow.Status = ("Transfered");
            //r.Id = 1;

            //var HID = _auc.Transfer_Hospitals.Where(f => f.Name == obj.HospitalName).Select(s => s.Id).Single();
            patient.Hospital_Id = obj.HospitalId;
            _auc.SaveChanges();
            var Transfer_Hospitals = _auc.Transfer_Hospitals.ToList();
            ViewBag.Transfer_Hospitals = Transfer_Hospitals;

            //_auc.Add(r);

            return Redirect("/Doctor/Main");

            //return View();
        }
        [HttpGet]
        public IActionResult AnotherDepartment()
        {

            var OtherDep = _auc.Specializations.Where(j => j.Code.Substring(0, 1) == "1")
                .Select(s => new Specialization { Name = s.Name, Id = s.Id }).ToList();
            ViewBag.OtherDep = OtherDep;
            var OtherDoc = _auc.Staff.Select(n => new Staff { Name = n.Name, Specialization_Id = n.Specialization_Id, Id = n.Id }).ToList();
            ViewBag.OtherDoc = OtherDoc;
            var followUpTypes = _auc.Follow_Ups_Types.ToList();
            ViewBag.types = followUpTypes;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AnotherDepartment(TransferAnotherDepVM obj)
        {
            Follow_Up v = new Follow_Up();
            //var patient_id = 2;
            int Follow_up_Id = (int)HttpContext.Session.GetInt32("Follow_up_Id");
            int patient_id = (int)_auc.Follow_Ups.Where(d => d.Id == Follow_up_Id)
                                            .Select(d => d.Patient_Id)
                                            .Single();
            var m = Follow_up_Id;
            var entity = _auc.Follow_Ups.FirstOrDefault(s => s.Id == m);
            var followHistory = _auc.Follow_Ups_History.FirstOrDefault(n => n.Follow_Up_Id == m);
            if (entity != null)
            {
                entity.Staff_Id = obj.StaffId;
                entity.Status = "Pending";
                followHistory.Follow_Up_Type_Id = obj.FollowTypeId;
                followHistory.Date = null;
                _auc.Entry(entity).State = EntityState.Modified;
                _auc.Entry(followHistory).State = EntityState.Modified;
                _auc.SaveChanges();
            }
            var OtherDep = _auc.Specializations.Where(j => j.Code.Substring(0, 1) == "1")
                .Select(s => new Specialization { Name = s.Name, Id = s.Id }).ToList();
            ViewBag.OtherDep = OtherDep;
            var OtherDoc = _auc.Staff.Select(n => new Staff { Name = n.Name, Specialization_Id = n.Specialization_Id, Id = n.Id }).ToList();
            ViewBag.OtherDoc = OtherDoc;
            var followUpTypes = _auc.Follow_Ups_Types.ToList();
            ViewBag.types = followUpTypes;
            //return View();
            return Redirect("/Doctor/Main");
        }
        [HttpGet]
        public IActionResult Schedule()
        {
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();
            var followList = _auc.Follow_Ups.Where(s => s.Staff_Id == Doctor_Id)
                .Select(n =>n.Id).ToList();
            List<Follow_Up_History> listDates = new List<Follow_Up_History>();
            foreach(var p in followList)
            {
                listDates.Add(_auc.Follow_Ups_History
                    .Include(s=>s.Follow_Up_Type)
                    .Where(s => s.Follow_Up_Id == p)
                    //.Select(n=>new Follow_Up_History {Date=n.Date,Follow_Up_Type_Id=n.Follow_Up_Type_Id })
                    .Single());
            }
            listDates = listDates.OrderBy(s => s.Date).ToList();
            ViewBag.schedule = listDates;
            return View();
        }
        [HttpGet]
        public IActionResult Profile()
        {
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();
            var info = _auc.Staff.Where(o => o.Id == Doctor_Id)
                .Select(n => new Staff { Name = n.Name, Phone = n.Phone, Starting_Day = n.Starting_Day }).ToList();
            ViewBag.info = info;
            var y = _auc.Staff.Where(o => o.Id == Doctor_Id).Select(s => s.Specialization_Id).Single();
            var x = _auc.Specializations.Where(i => i.Id == y).Select(i => new Specialization { Name = i.Name }).ToList();
            ViewBag.specialization = x;
            // to cut the first name
            var name = _auc.Staff.Where(o => o.Id == Doctor_Id)
                .Select(n => n.Name).Single();
            int index = name.IndexOf(@" ");
            ViewBag.firstName = name.Substring(0, index);
            var email = _auc.Registrations.Where(i => i.Id == Doctor_Reg_Id).Select(i => i.Email).Single();
            ViewBag.email = email;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Profile(ProfileVM obj)
        {
            Staff v = new Staff();
            int Doctor_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();
            var entity = _auc.Staff.FirstOrDefault(s => s.Id == Doctor_Id);
            var emaildoctor = _auc.Registrations.FirstOrDefault(f => f.Id == Doctor_Reg_Id);
            if (entity != null)
            {
                entity.Name = obj.Name;
                entity.Phone = obj.Phone;
                entity.Starting_Day = obj.startDay;
                emaildoctor.Email = obj.email;
                _auc.Entry(entity).State = EntityState.Modified;
                _auc.Entry(emaildoctor).State = EntityState.Modified;
                _auc.SaveChanges();
            }
            //
            var info = _auc.Staff.Where(o => o.Id == Doctor_Id)
                .Select(n => new Staff { Name = n.Name, Phone = n.Phone, Starting_Day = n.Starting_Day }).ToList();
            ViewBag.info = info;
            var y = _auc.Staff.Where(o => o.Id == Doctor_Id).Select(s => s.Specialization_Id).Single();
            var x = _auc.Specializations.Where(i => i.Id == y).Select(i => new Specialization { Name = i.Name }).ToList();
            ViewBag.specialization = x;
            var email = _auc.Registrations.Where(i => i.Id == Doctor_Reg_Id).Select(i => i.Email).Single();
            ViewBag.email = email;
            return View();
        }
    }
}
