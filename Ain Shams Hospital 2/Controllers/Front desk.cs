using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels;
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
            var PID = _asu.Patients.Where(f => f.Name == ob.PatientName).Select(s => s.Id).Single();
            var NamePexist = _asu.Patients.ToList().Any(f => f.Name == ob.PatientName);
            var SID = _asu.Staff.Where(f => f.Name == ob.DoctorName).Select(s => s.Id).Single();
            var NameSexist = _asu.Staff.ToList().Any(F => F.Name == ob.DoctorName);
            var Availabilty = _asu.Hospital_Facilities.Where(f => f.Type == ob.Room).Select(s => s.Available).Single();
            var HID = _asu.Hospital_Facilities.Where(f => f.Type == ob.Room).Select(s => s.Id).Single();
            var availableroom = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == HID).Select(s => new { date = s.End_Hour, date1 = s.Start_Hour }).ToList();
            bool av ;


            if (availableroom == null)
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


    
    

