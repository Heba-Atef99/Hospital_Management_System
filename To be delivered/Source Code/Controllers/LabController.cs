﻿using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels.LabVM;
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
    [CheckXActionFilterAttribute]

    public class LabController : Controller
    {
        private readonly HospitalDbContext _auc;
        // private readonly IHospitalRepository _repository;
        public LabController(HospitalDbContext auc)
        {
            _auc = auc;
            //_repository = repository;
        }
        public IActionResult Index()
        {
            int SpecifyLab = (int)HttpContext.Session.GetInt32("SpecifyLab");
            switch (SpecifyLab)
            {
                case 1:
                case 2:
                //go to lab
                return Redirect("/Lab/LabMain");

                case 4:
                    //go to blood bank
                    return Redirect("/Lab/Bloodbank");


                default:
                    ViewBag.Error = "Oops, Something went wrong!";
                    return View();

            }
        }

        [HttpGet]
        public IActionResult BloodBank()
        {
            ViewData["Title"] = "Blood Bank";
            var result = _auc.Blood_Units.ToList();
            ViewBag.Blood_Units = result;
            return View();
        }

        [HttpPost]
        public IActionResult BloodBank(BloodBankVM bb)
        {
            if (bb.Add != null)
            {
                string[] ids = bb.Add.Split(",");
                var index = Int16.Parse(ids[1]) - 1;
                Blood_Unit bloodUnit = _auc.Blood_Units.Where(b => b.Id == Int16.Parse(ids[0])).FirstOrDefault();
                bloodUnit.Amount += bb.Amount[Int16.Parse(ids[1]) - 1];
                _auc.SaveChanges();
            }

            else if (bb.Delete != 0)
            {
                Blood_Unit bloodUnit = _auc.Blood_Units.Where(b => b.Id == bb.Delete).FirstOrDefault();
                _auc.Remove(bloodUnit);
                _auc.SaveChanges();
            }
            else if (bb.NewAdd != 0)
            {
                Blood_Unit bloodUnit = new Blood_Unit
                {
                    Type = bb.NewType,
                    Amount = bb.NewAmount
                };
                _auc.Add(bloodUnit);
                _auc.SaveChanges();
            }
            //return View();
            return Redirect("/Lab/BloodBank");
        }
        [HttpPost]
        public IActionResult LabMain(LabMainVM m, string sort, string search)
        {
            if (m.P_Id != 0)
            {
                HttpContext.Session.SetInt32("Follow_up_Id", m.P_Id);
                return Redirect("/Lab/LabPatient");
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


            return Redirect("/Lab/LabMain");
           
        }

        [HttpGet]
        public IActionResult LabMain()
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
                .Include(f => f.Follow_Up)
                .Where(f => f.Follow_Up_Id == _P.Id)
                .Single());

                patient_join_follow_up.Add(new Tuple<Patient, Follow_Up_History>(patient[i], follow_up[i]));
                ++i;
            }

            var searchString = TempData["SearchItem"]?.ToString();
            if (searchString != null)
            {
                ViewBag.follow_ups = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up
                    .Where(s => s.Item1.Id.ToString().Contains(searchString) ||
                    s.Item1.Name.Contains(searchString) ||
                    s.Item2.Follow_Up_Type.Name.Contains(searchString))
                    .ToList();
                return View();
            }

            patient_join_follow_up = (List<Tuple<Patient, Follow_Up_History>>)patient_join_follow_up.
                        OrderByDescending(s => s.Item2.Date).ToList();

            var sortString = TempData["SortItem"]?.ToString();
            if (sortString != null)
            {
                var orderString = TempData["OrderItem"] == null ? "DSC" : TempData["OrderItem"].ToString();
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
                }
            }
            ViewBag.follow_ups = patient_join_follow_up;

            return View();
        }
        [HttpGet]
        public IActionResult LabPatient()
        {
            // int patient_id =(int) TempData["p_id"];
            int Follow_up_Id = (int)HttpContext.Session.GetInt32("Follow_up_Id");
            int patient_id = (int)_auc.Follow_Ups.Where(d => d.Id == Follow_up_Id)
                                            .Select(d => d.Patient_Id)
                                            .Single();
            var result = _auc.Patients
                .Where(O => O.Id == patient_id)
                .Select(I => new Patient { Name = I.Name, Phone = I.Phone })
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
        public IActionResult LabPatient(LabMainVM obj)
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
            //TempData["p_id"] = patient_id;
            Patient patient;
            Follow_Up follow_Up;
            follow_Up = _auc.Follow_Ups.Where(d => d.Id == Follow_up_Id).FirstOrDefault();
            patient = _auc.Patients.Where(i => i.Id == patient_id).FirstOrDefault();
          
            if (obj.Status != "Pending")
                follow_Up.Status = obj.Status;
            _auc.SaveChanges();
            ModelState.Clear();


            var result = _auc.Patients
                 .Where(O => O.Id == patient_id)
                 .Select(I => new Patient { Name = I.Name, Phone = I.Phone })
                 .ToList();


            var regestration_id = _auc.Patients.Include(o => o.Registration)
                .Where(O => O.Id == patient_id)
                 .ToList();
            var mail = regestration_id[0].Registration.Email;
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

    }
}
