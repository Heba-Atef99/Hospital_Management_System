using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels;
using AinShamsHospital.ViewModels;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication10.ViewModels;

namespace Ain_Shams_Hospital.Controllers
{
    public class Front_deskController : Controller
    {
        private readonly HospitalDbContext _asu;
        public Front_deskController(HospitalDbContext asu)
        {
            _asu = asu;
        }
        public IActionResult Done()
        {
            return View();
        }
        public IActionResult message()
        {
            return View();
        }
        public IActionResult Patientmessage()
        {
            return View();
        }
        public IActionResult Event()
        {
            Facility_Reservation FR = new Facility_Reservation();
            Hospital_Facility H = new Hospital_Facility();
            var h = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id ==5 ).Select(s =>  s.End_Hour);
            var h1 = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == 5).Select(s => s.Start_Hour);
            ViewBag.D1 =h;
            ViewBag.D2 = h1;
            return View();
        }
        IList<Hospital_Facility> roomtype = new List<Hospital_Facility>();
        public IActionResult Roomavailabilty()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Roomreservation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Roomreservation(RoomReservationVM ob)
        {
            Hospital_Facility H = new Hospital_Facility();
            Facility_Reservation FR = new Facility_Reservation();
            //Patient p = new Patient();
            //var x = H.Available;
           TempData["Patient_Id"] = _asu.Patients.Where(f => f.Name == ob.PatientName).Select(s => s.Id).Single();
            var NamePexist = _asu.Patients.ToList().Any(f => f.Name == ob.PatientName);
            TempData["Staff_Id"] = _asu.Staff.Where(f => f.Name == ob.DoctorName).Select(s => s.Id).Single();
            var NameSexist = _asu.Staff.ToList().Any(F => F.Name == ob.DoctorName);
            var Availabilty = _asu.Hospital_Facilities.Where(f => f.Type == ob.Room).Select(s => s.Available).Single();
            var HID = _asu.Hospital_Facilities.Where(f => f.Type == ob.Room).Select(s => s.Id).Single();
            var availableroom = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == HID)
                .Select(s => new { date = s.End_Hour, date1 = s.Start_Hour }).ToList();
            bool av;

            if (availableroom == null)
            {
                if (NamePexist)
                {
                    if (NameSexist)
                    {
                        FR.Start_Hour = ob.From;
                        FR.End_Hour = ob.To;
                        FR.Hospital_Facility_Id = HID;
                        FR.Patient_Id = (int)TempData["Patient_Id"];
                        FR.Staff_Id = (int)TempData["Staff_Id"];
                        _asu.Add(FR);
                        _asu.SaveChanges();

                        return Redirect("/Front_desk/SRoomreservation");
                    }
                    else
                    {
                        return Redirect("/Front_desk/MESSAGE");
                    }
                }
                else
                {
                    return Redirect("/Front_desk/PatientMESSAGE");
                }
            }
            else
            {

                foreach (var V in availableroom)
                {
                    DateTime parse1 = DateTime.Parse(ob.From);
                    DateTime parse2 = DateTime.Parse(ob.To);
                    DateTime parse3 = DateTime.Parse(V.date);
                    DateTime parse4 = DateTime.Parse(V.date1);
                    if ((parse1 > parse3) || (parse2 < parse3))
                    {
                        av = true;
                    }
                    else
                    {
                        av = false;
                        return Redirect("/Front_desk/Roomavailabilty");
                    }
                }
                if (av = true)
                {
                    if (NamePexist)
                    {
                        if (NameSexist)
                        {
                            FR.Start_Hour = ob.From;
                            FR.End_Hour = ob.To;
                            FR.Hospital_Facility_Id = HID;
                            FR.Patient_Id = (int)TempData["Patient_Id"];
                            FR.Staff_Id = (int)TempData["Staff_Id"];
                            _asu.Add(FR);
                            _asu.SaveChanges();

                            return Redirect("/Front_desk/SRoomreservation");
                        }
                        else
                        {
                            return Redirect("/Front_desk/MESSAGE");
                        }
                    }
                    else
                    {
                        return Redirect("/Front_desk/PatientMESSAGE");
                    }
                }
                else
                {
                    return Redirect("/Front_desk/Roomavailabilty");
                }
            }

        }
        public IActionResult NotAvailable()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Search(SearchVm ob)
        {
            Facility_Reservation FR = new Facility_Reservation();
            var ID = _asu.Patients.Where(f => f.Name == ob.patientName).Select(s => s.Id).Single();
            var NamePexist = _asu.Facility_Reservations.ToList().Any(f => f.Patient_Id == ID);
            if (NamePexist)
            {
               
                /*
                                var Startavailable = _asu.Facility_Reservations.Where(f => f.Patient_Id == ID)
                                    .Select(s => s.Start_Hour).Single();
                                var Endavailable = _asu.Facility_Reservations.Where(f => f.Patient_Id == ID)
                                  .Select(s => s.End_Hour).Single();
               
                var Endavailable = _asu.Facility_Reservations.Where(f => f.Patient_Id == ID)
                                .Select(s =>new { s.End_Hour ,s.Start_Hour}).ToList();
                DateTime parse1 = DateTime.Parse(Startavailable);
                DateTime parse2 = DateTime.Parse(Endavailable);
 */
                var Endavailable = _asu.Facility_Reservations.Where(f => f.Patient_Id == ID)
                                          .Select(s => new { dates = s.Start_Hour, dateE = s.End_Hour,name=s.Id }).ToList();
                foreach (var V in Endavailable)
                {
                    DateTime parse3 = DateTime.Parse(V.dates);
                    DateTime parse4 = DateTime.Parse(V.dateE);
                    int i = V.name;
                    if ((ob.Today <= parse3))
                    {
                        var roomnumber = _asu.Facility_Reservations
                        .Where(F => F.Id==i )
                        .Select(s => s.Hospital_Facility_Id).Single();
                        TempData["room"] = _asu.Hospital_Facilities.Where(t => t.Id == roomnumber)
                            .Select(S => S.Type).Single();
                        return Redirect("/Front_desk/Searchresult");
                    }
                    else {
                        return Redirect("/Front_desk/NotAvailable");
                    }
                }
            }
            return Redirect("/Front_desk/NotAvailable");
        }
        public IActionResult SearchResult()
        {
            ViewBag.D = TempData["Endavailable"];
            ViewBag.DD = TempData["room"];
            return View();
        }
        [HttpGet]
        public IActionResult SRoomreservation()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SRoomreservation(SRoomReservationVM ob)
        {
            if (ob.SurgeryRoom == "No Surgery")
            {
                return Redirect("/Front_desk/done");
            }
            else
            {
                Facility_Reservation F = new Facility_Reservation();
                var SHID = _asu.Hospital_Facilities.Where(f => f.Type == ob.SurgeryRoom).Select(s => s.Id).Single();
                var Savailableroom = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == SHID)
                    .Select(s => new { date = s.End_Hour, date1 = s.Start_Hour }).ToList();
                bool av;
                F.Patient_Id = (int)TempData["Patient_Id"];
                F.Staff_Id = (int)TempData["Staff_Id"];
                if (Savailableroom == null)
                {
                    F.Start_Hour = ob.Start_Hour;
                    F.End_Hour = ob.End_Hour;
                    F.Hospital_Facility_Id = SHID;

                    _asu.Add(F);
                    _asu.SaveChanges();

                    return Redirect("/Front_desk/done");
                }
                else
                {

                    foreach (var V in Savailableroom)
                    {
                        DateTime parse1 = DateTime.Parse(ob.Start_Hour);
                        DateTime parse2 = DateTime.Parse(ob.End_Hour);
                        DateTime parse3 = DateTime.Parse(V.date);
                        DateTime parse4 = DateTime.Parse(V.date1);
                        if ((parse1 > parse3) || (parse2 < parse3))
                        {
                            av = true;
                        }
                        else
                        {
                            av = false;
                            return Redirect("/Front_desk/Roomavailabilty");
                        }

                    }
                    if (av = true)
                    {
                        F.Start_Hour = ob.Start_Hour;
                        F.End_Hour = ob.End_Hour;
                        F.Hospital_Facility_Id = SHID;
                        _asu.Add(F);
                        _asu.SaveChanges();
                        return Redirect("/Front_desk/done");
                    }
                }
            }
                return View();
        }
    }
}


/*
else
{
    DateTime parse3 = DateTime.Parse(startavailableroom);

    DateTime parse1 = DateTime.Parse(ob.From);
    DateTime parse2 = DateTime.Parse(ob.To);
    if ((parse1 > parse3) || (parse2 < parse3))
    //if (Availabilty == true)
    {
        if (NamePexist)
        {
            if (NameSexist)
            {
                FR.Start_Hour = ob.From;
                FR.End_Hour = ob.To;
                FR.Hospital_Facility_Id = HID;
                FR.Patient_Id = PID;
                FR.Staff_Id = SID;
                _asu.Add(FR);
                _asu.SaveChanges();

                return Redirect("/Front_desk/done");
            }
            else
            {
                return Redirect("/Front_desk/MESSAGE");
            }
        }
        else
        {
            return Redirect("/Front_desk/PatientMESSAGE");
        }
    }
    else
    {
        return Redirect("/Front_desk/Roomavailabilty");
    }
}
*/





