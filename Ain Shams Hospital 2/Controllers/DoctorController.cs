using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ain_Shams_Hospital.Data.Entities;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ain_Shams_Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext _auc;
        public DoctorController(HospitalDbContext auc)
        {
            _auc = auc;
        }


        public IActionResult Home()
        {
            int Doctor_Reg_Id = (int) TempData["User_Reg_Id"];
            int Doctor_Id = _auc.Staff
                .Where(d => d.Registration_Id == Doctor_Reg_Id)
                .Select(d => d.Id)
                .Single();

            var Patients_FollowUps = _auc.Follow_Ups
                .Where(d => d.Staff_Id == Doctor_Id)
                .Select(p => new { p.Patient_Id , p.Id})
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
                patient.Add( _auc.Patients
                    .Where(p => p.Id == _P.Patient_Id)
                    .Single());

                follow_up.Add( _auc.Follow_Ups_History
                .Include(f => f.Follow_Up_Type)
                .Where(f => f.Follow_Up_Id == _P.Id)
                .Single() );

                patient_join_follow_up.Add(new Tuple<Patient, Follow_Up_History>(patient[i], follow_up[i]));
                ++i;
            }

            ViewBag.follow_ups = patient_join_follow_up;
            return View();
        }
    }
}
