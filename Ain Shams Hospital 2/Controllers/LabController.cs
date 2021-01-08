using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels.LabVM;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ain_Shams_Hospital.Controllers
{
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
                    //return Redirect("/Doctor/Main");

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
            if(bb.Add != 0)
            {
                Blood_Unit bloodUnit = _auc.Blood_Units.Where(b => b.Id == bb.Add).FirstOrDefault();
                bloodUnit.Amount += bb.Amount;
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
    }
}
