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
using Microsoft.EntityFrameworkCore;
using AinShamsHospital.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Ain_Shams_Hospital.Controllers
{
    [CheckXActionFilterAttribute]
    public class Manager : Controller
    {

        private readonly HospitalDbContext _auc;
        public Manager(HospitalDbContext auc)
        {
            _auc = auc;
        }
        [HttpGet]
        public IActionResult ManagerHome()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManagerHome(ManagerSrch m)
        {

            var NameExist = _auc.Staff.ToList().Any(u => u.Name == m.Name);

            if (NameExist)
            {
                TempData["member"] = _auc.Staff
                .Where(i => i.Name == m.Name)
                .Select(m => m.Name)
                .Single();
                TempData["member1"] = _auc.Staff
              .Where(i => i.Name == m.Name)
              .Select(s => s.Phone)
              .Single();
                TempData["member2"] = _auc.Staff
              .Where(i => i.Name == m.Name)
              .Select(s => s.Starting_Day)
              .Single();
                var x = _auc.Staff.Where(i => i.Name == m.Name).Select(s => s.Specialization_Id).Single();
                TempData["member3"] = _auc.Specializations
           .Where(i => i.Id == x)
           .Select(s => s.Name)
           .Single();
                var regestration_id = _auc.Staff.
            Where(i => i.Name == m.Name)
             .Select(I => I.Registration_Id)
             .Single();
                TempData[" mail"] = _auc.Registrations
                    .Where(O => O.Id == regestration_id)
                     .Select(I => I.Email)
                     .Single();
                ViewBag.DD1 = TempData["member"];
                ViewBag.DD2 = TempData["member1"];
                ViewBag.DD3 = TempData["member2"];
                ViewBag.DD4 = TempData["member3"];
                ViewBag.DD5 = TempData[" mail"];
                return View();

                // return Redirect("/Manager/exist");
            }

            else
            {
                ViewBag.NameDoesntExist = "Staff Member Doesn't Exist";
                return View();
                //return Redirect("/Manager/NotExist");
            }
        }
        public IActionResult NotExist()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Stateview()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Stateview(mainVM m)
        {
            var ID = _auc.Follow_Ups_Types.Where(f => f.Name == m.Room_Id).Select(s => s.Id).Single();
            String from = HttpContext.Session.GetString("FIRST");
            String to = HttpContext.Session.GetString("LAST");

            var h = _auc.Payments.Include(o => o.Patient).Include(p => p.Follow_Up_Type)
                .Where(f => (f.Follow_Up_Type_Id == ID && f.Payed == true))
              .ToList();
            DateTime start = DateTime.Parse(from);
            DateTime end = DateTime.Parse(to);
            List<Payment> payment = new List<Payment>();
            // if (from!=null && to != null)
            //{
            var total = 0;
            foreach (var V in h)
            {

                DateTime date = DateTime.Parse(V.Date);

                if (date >= start && date <= end)
                {
                    total = total + V.Money;
                    payment.Add(V);
                }

            }


            ViewBag.R = m.Room_Id;
            ViewBag.t = total;
            // ViewBag.D = h;
            ViewBag.list = payment;
            return View();


        }
        public IActionResult Stateview1()
        {
            String from = HttpContext.Session.GetString("FIRST");
            String to = HttpContext.Session.GetString("LAST");
            var h = _auc.Payments.Include(o => o.Patient).Include(p => p.Follow_Up_Type)
               .Where(f => f.Payed == true).ToList();
            DateTime start = DateTime.Parse(from);
            DateTime end = DateTime.Parse(to);
            List<Payment> payment1 = new List<Payment>();
            var total = 0;
            foreach (var V in h)
            {

                DateTime date = DateTime.Parse(V.Date);

                if (date >= start && date <= end)
                {
                    total = total + V.Money;

                    payment1.Add(V);
                }

            }
            // ViewBag.R = m.Room_Id;
            ViewBag.t = total;
            // ViewBag.D = h;
            ViewBag.list1 = payment1;

            return View();
        }
        [HttpGet]
        public IActionResult State()
        {
            var Type = _auc.Follow_Ups_Types.ToList();
            ViewBag.type = Type;

            return View();
        }
        [HttpPost]
        public IActionResult State(FinanceInterval obj)
        {
            var Type = _auc.Follow_Ups_Types.ToList();
            ViewBag.type = Type;
            HttpContext.Session.SetString("FIRST", obj.From);
            HttpContext.Session.SetString("LAST", obj.To);

            return View();
        }
        [HttpGet]
        public IActionResult Deletemanager()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deletemanager(deletvm vm)
        {
            var NameExist = _auc.Staff.ToList().Any(u => u.Name == vm.StaffName);
            if (NameExist)
            {
                var StaffName = _auc.Staff.Where(f => f.Name == vm.StaffName)
                   .Select(s => s.Id).Single();
                var regestrationId = _auc.Staff.Where(f => f.Name == vm.StaffName)
                   .Select(s => s.Registration_Id).Single();
                var followupid = _auc.Follow_Ups.Where(f => f.Staff_Id == StaffName)
                   .Select(s => s.Id).ToList();
                foreach (var x in followupid)
                {
                    var followuphistory = _auc.Follow_Ups_History.Where(f => f.Follow_Up_Id == x)
                   .Select(s => s.Id).Single();
                    var model2 = _auc.Follow_Ups_History.Find(followuphistory);
                    _auc.Remove(model2);

                    var model3 = _auc.Follow_Ups.Find(x);
                    _auc.Remove(model3);
                }
                var model1 = _auc.Registrations.Find(regestrationId);
                var model = _auc.Staff.Find(StaffName);
                _auc.Remove(model);
                _auc.Remove(model1);
                _auc.SaveChanges();
                ViewBag.UserMessage4 = "Staff member is deleted successfully";
                return View();
            }
            else
            {
                ViewBag.UserMessage5 = "This staff member doesn't exist";
                return View();
            }


        }
        [HttpGet]
        public IActionResult DeleteSpecialization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteSpecialization(AddSpecialization vm)
        {
            var NameExist = _auc.Specializations.ToList().Any(u => u.Name == vm.Specialization);
            if (NameExist)
            {
                
                var SpecializationName = _auc.Specializations.Where(f => f.Name == vm.Specialization)
                   .Select(s => s.Id).Single();
               
                var model = _auc.Specializations.Find(SpecializationName);
                _auc.Remove(model);
              
                _auc.SaveChanges();
                ViewBag.Success = "Specialization code is deleted successfully";
                return View();
            }
            else
            {
                ViewBag.fail = "This Specialization doesn't exist";
                return View();
            }


        }
        [HttpGet]
        public IActionResult Deleteprice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Deleteprice(AddPrice vm)
        {
            var NameExist = _auc.Follow_Ups_Types.ToList().Any(u => u.Name == vm.ServiceName);
            if (NameExist)
            {

                var serviceName = _auc.Follow_Ups_Types.Where(f => f.Name == vm.ServiceName)
                   .Select(s => s.Id).Single();

                var model = _auc.Follow_Ups_Types.Find(serviceName);
                _auc.Remove(model);

                _auc.SaveChanges();
                ViewBag.Success = "This service is deleted successfully";
                return View();
            }
            else
            {
                ViewBag.fail = "This Service doesn't exist";
                return View();
            }


        }
        public IActionResult ViewPrices()
        {
            var s = _auc.Follow_Ups_Types.Select(s => new Follow_Up_Type { Name = s.Name, Price = s.Price }).ToList();

            ViewBag.C1 = s;

            return View();
        }

        [HttpGet]
        public IActionResult ManagerEdit()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult ManagerEdit(ManagerEdit obj)
        {
            var names = _auc.Follow_Ups_Types.ToList();
            ViewBag.editname = names;
            Follow_Up_Type v = new Follow_Up_Type();
            v.Name = obj.Name;
            v.Price = obj.Price;
            var NameExist = _auc.Follow_Ups_Types.ToList().Any(u => u.Name == v.Name);
            if (NameExist)
            {
                var m = _auc.Follow_Ups_Types.Where(i => i.Name == obj.Name).Select(c => c.Id).Single();
                //code from internet
               
                var entityItem = _auc.Follow_Ups_Types.FirstOrDefault(s => s.Id == m);
                if (entityItem != null)
                {
                    
                    entityItem.Price = v.Price;

                    _auc.Entry(entityItem).State = EntityState.Modified;
                    _auc.SaveChanges();
                    
                }
                ViewBag.Success = "The price is edited successfully.";
                return View();
            }
            else {
                ViewBag.Fail = "This name doesn't exist.";
                return View();
            }
        }
        
        public IActionResult ViewSpecializations()
        {
            var s = _auc.Specializations.Select(s => new Specialization { Name = s.Name, Code = s.Code }).ToList();

            ViewBag.C1 = s;
            return View();
        }
        public IActionResult ViewHospital()
        {
            var s = _auc.Transfer_Hospitals.Select(s => new Transfer_Hospital { Name = s.Name }).ToList();

            ViewBag.C1 = s;
            return View();
        }
        [HttpGet]
        public IActionResult AddHospital()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddHospital(AddHospital obj)
        {
            Transfer_Hospital b = new Transfer_Hospital();

            b.Name = obj.Hospital;

            var NameExist = _auc.Transfer_Hospitals.ToList().Any(u => u.Name == b.Name);

            if (NameExist)
            {
                ViewBag.Fail = "This Hospital already exists.";
                return View();
            }

            else
            {
                var name = b.Name;

                _auc.Add(b);
                _auc.SaveChanges();
                ViewBag.Success = "Hospital is added successfully";

                return View();
            }
        }
        [HttpGet]
        public IActionResult AddPrice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPrice(AddPrice obj)
        {
            Follow_Up_Type b = new Follow_Up_Type();
            
            b.Name = obj.ServiceName;
          
            var NameExist = _auc.Follow_Ups_Types.ToList().Any(u => u.Name == b.Name);
           
            if (NameExist)
            {
                ViewBag.Fail = "This service already exists.";
                return View();
            }
           
            else
            {

                b.Price = obj.ServicePrice;
            
                    _auc.Add(b);
                    _auc.SaveChanges();
                    ViewBag.Success = "Service is added successfully";

                return View();
            }
        }
            [HttpGet]
        public IActionResult AddSpecialization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialization(AddSpecialization obj)
        {
            Specialization b = new Specialization();
            b.Name = obj.Specialization;
            b.Code = obj.Code;
            var NameExist = _auc.Specializations.ToList().Any(u => u.Name == b.Name);
            var CodeExist = _auc.Specializations.ToList().Any(u => u.Code == b.Code);
            if (CodeExist)
            {
                ViewBag.Fail = "This code is already taken.";
                return View();
            }
            else if (NameExist)
            {
                ViewBag.Fail2 = "This specialization already exists.";
                return View();
            }
            else
            {
                var code = b.Code;
                int _Index = (int)code[0] - 48;
                if (_Index == 1)
                {
                    _auc.Add(b);
                    _auc.SaveChanges();
                    ViewBag.Success = "Specialization is added successfully";
                    
                }
                else
                {
                    ViewBag.Fail3 = "Your code must start with 1";
                }
                return View();
            }
            
        }
        public IActionResult Home()
        {
            return View();
        }

        /*public IActionResult Exist()
        {
            ViewBag.DD1 = TempData["member"];
            ViewBag.DD2 = TempData["member1"];
            ViewBag.DD3 = TempData["member2"];
            ViewBag.DD4 = TempData["member3"];
            ViewBag.DD5 = TempData[" mail"];
           
            return View();
        }
        */
        //[HttpGet]
        //public IActionResult Activation()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Activation(actVM ch)
        //{
        //    var CodeExist = _auc.Specializations.ToList().Any(z => z.Code == ch.Activation);

        //    if (CodeExist)
        //    {
        //        if (ch.Activation == "0000")
        //        {
        //            return Redirect("/Registration/RegistrationPatient");
        //        }
        //        else
        //        {

        //            TempData["Specialization_Id"] = _auc.Specializations
        //                .Where(i => i.Code == ch.Activation)
        //                .Select(c => c.Id)
        //                .Single();

        //           return Redirect("/Registration/RegistrationStaff");
        //        }
        //    }
        //    else
        //    {
        //        return Redirect("/Registration/Activation");
        //    }


        //}
        //public IActionResult Patient()
        //{
        //    return View();
        //}
        //public IActionResult Staff()
        //{
        //    return View();
        //}

        //public IActionResult About()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult RegistrationPatient()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult RegistrationPatient(RegistrationPatientVM obj)
        //{
        //    Registration r = new Registration();
        //    r.Email = obj.Email;
        //    r.Password = BCrypt.Net.BCrypt.HashPassword(obj.Password);

        //    var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == r.Email);
        //    if (EmailExist)
        //    {
        //        //throw error
        //        ViewBag.EmailExistError = "You have already signed up";
        //        //go to error page
        //        return Redirect("/Registration/About");
        //    }

        //    else
        //    {
        //        _auc.Add(r);
        //        _auc.SaveChanges();
        //        Patient P = new Patient();
        //        P.Name = obj.Name;
        //        P.Phone = obj.Phone;
        //        P.Registration_Id = r.Id;

        //        _auc.Add(P);
        //        _auc.SaveChanges();
        //        return Redirect("/Registration/Patient");
        //    }
        //}

        //[HttpGet]
        //public IActionResult RegistrationStaff()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RegistrationStaff(RegistrationStaffVM objc)
        //{
        //    Registration R = new Registration();
        //    R.Email = objc.Email;
        //    R.Password = BCrypt.Net.BCrypt.HashPassword(objc.Password);
        //    var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == R.Email);
        //    if (EmailExist)
        //    {
        //        //throw error
        //        ViewBag.EmailExistError = "You have already signed up";
        //        //go to error page
        //        return Redirect("/Registration/About");
        //    }

        //    else
        //    {
        //        _auc.Add(R);
        //        _auc.SaveChanges();
        //        Staff S = new Staff();
        //        S.Name = objc.Name;
        //        S.Phone = objc.Phone;
        //        S.Starting_Day = objc.Starting_Day;
        //        S.Registration_Id = R.Id;

        //        S.Specialization_Id = (int)TempData["Specialization_Id"];

        //        //recently added
        //        var code = _auc.Specializations
        //                   .Where(s => s.Id == S.Specialization_Id)
        //                   .Select(s => s.Code)
        //                   .Single();

        //        int _Index = (int)code[0] - 48; //the first number in the activation code

        //        _auc.Add(S);
        //        _auc.SaveChanges();

        //        TempData["User_Reg_Id"] = S.Registration_Id;

        //        switch (_Index)
        //        {
        //            case 0:
        //            //go to patient

        //            case 1:
        //                return Redirect("/Doctor/Home");

        //            case 2:
        //            //go to manager

        //            case 3:
        //            //go to lap

        //            case 4:
        //            //go to finance

        //            case 5:
        //                return Redirect("/Front_desk/Roomreservation");

        //            default:
        //                return Redirect("/Registration/Staff");
        //        }

        //    }
        //}


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        //public IActionResult Loggin()
        //{
        //    return View();
        //}
        //public IActionResult NotLog()
        //{
        //    return View();
        //}

        /////login
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(RegistrationStaffVM objc)
        //{
        //    var EmailExist = _auc.Registrations.ToList().Any(u => u.Email == objc.Email);
        //    if (EmailExist)
        //    {
        //        var Data = _auc.Registrations.Where(f => f.Email == objc.Email).Select(s => new { s.Password, s.Id }).ToList();
        //        if (BCrypt.Net.BCrypt.Verify(objc.Password, Data[0].Password))
        //        {
        //            var SID = _auc.Staff.Where(F => F.Registration_Id == Data[0].Id).Select(S => S.Specialization_Id).Single();
        //            var code = _auc.Specializations
        //                    .Where(s => s.Id == SID)
        //                    .Select(s => s.Code)
        //                    .Single();

        //            int _Index = (int)code[0] - 48;

        //            TempData["User_Reg_Id"] = Data[0].Id;

        //            switch (_Index)
        //            {
        //                case 0:
        //                //go to patient

        //                case 1:
        //                    return Redirect("/Doctor/Home");

        //                case 2:
        //                //go to manager

        //                case 3:
        //                //go to lap

        //                case 4:
        //                //go to finance


        //                case 5:
        //                    return Redirect("/Front_desk/Event");

        //                default:
        //                    return Redirect("/Registration/Staff");
        //            }
        //        }
        //    }
        //    return Redirect("/Registration/NotLog");
        //}
    }
}