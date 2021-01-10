using Ain_Shams_Hospital.Data.Entities;
using Ain_Shams_Hospital.ViewModels;
using AinShamsHospital.ViewModels;
using HospitalManagementSystem.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        public IActionResult Homepage()
        {
            int Staff_Reg_Id = (int)HttpContext.Session.GetInt32("User_Reg_Id");
            string Staff_Name = _asu.Staff.Where(f => f.Registration_Id == Staff_Reg_Id).Select(h => h.Name).SingleOrDefault();
            ViewBag.User = Staff_Name;
            return View();
        }
       
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(delete vm,checkVM ch)
        {
            Facility_Reservation FR = new Facility_Reservation();
            var PatientName = _asu.Patients.Where(f => f.Name == vm.PatientName)
               .Select(s => s.Id).Single();
            //var RoomID = _asu.Facility_Reservations.Where(f => f.Patient_Id == PatientName)
            //.OrderByDescending(d=>d);
            var h = _asu.Facility_Reservations.Where(f => f.Patient_Id == PatientName)
                .Select(s=>new Facility_Reservation{ Id=s.Id ,Staff_Id=s.Staff_Id})
                .OrderByDescending(s=>s.Id)
             .FirstOrDefault();
            String ROOMName = HttpContext.Session.GetString("Roomname");
            String start = HttpContext.Session.GetString("START");
            String end = HttpContext.Session.GetString("END");
            var HID = _asu.Hospital_Facilities.Where(f => f.Type == ROOMName).Select(s => s.Id).Single();
            FR.Start_Hour = start;  //ob.From;
            FR.End_Hour = end;
            FR.Hospital_Facility_Id = HID;
            //FR.Hospital_Facility_Id =no ;
            FR.Patient_Id = PatientName;
            FR.Staff_Id = h.Staff_Id;
            _asu.Add(FR);
            _asu.SaveChanges();
            int x = h.Id;
            var model = _asu.Facility_Reservations.Find(x);
            _asu.Remove(model);
            _asu.SaveChanges();
            ViewBag.UserMessage3 = "Patient is transferred successfully";

            return View();
        }
        [HttpGet]
        public IActionResult Event()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Event(mainVM m)
        {
            Facility_Reservation FR = new Facility_Reservation();
            Hospital_Facility H = new Hospital_Facility();
            var ID = _asu.Hospital_Facilities.Where(f => f.Type == m.Room_Id).Select(s => s.Id).Single();
            var h = _asu.Facility_Reservations.Include(p=>p.Patient).Where(f => f.Hospital_Facility_Id ==ID )
                .OrderByDescending(s => s.End_Hour).ToList();

            ViewBag.Roomnumber = m.Room_Id;
            ViewBag.D1 = h;
           
   

            return View();
        }
      
        [HttpGet]

        public IActionResult main2()
        {
            
            var SurgeryNameRexist = _asu.Hospital_Facilities
                .Where(f => f.Type.Substring(0, 7) == "Surgery")
                .Select(s => new Hospital_Facility { Type = s.Type })
                .ToList();
            ViewBag.h1 = SurgeryNameRexist;
          
            return View();
        }
        [HttpGet]
        public IActionResult Cancel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cancel(delete vm)
        {
            var NameExist = _asu.Patients.ToList().Any(u => u.Name == vm.PatientName);
         
            if (NameExist)
            {
                var patientId = _asu.Patients.Where(f => f.Name == vm.PatientName)
                   .Select(s => s.Id).Single();
                var nameIdexist = _asu.Facility_Reservations.ToList().Any(u => u.Patient_Id == patientId);
                if (nameIdexist)
                {
                    var faciltyreservationId = _asu.Facility_Reservations.Where(f => f.Patient_Id == patientId)
                      .OrderByDescending(s => s.Id)
                      .Select(s => s.Id).FirstOrDefault();
                    var surgeryId = _asu.Follow_Ups_Types.Where(f => f.Name == "Surgery").Select(s => s.Id).Single();
                    var surgeryfollowuptypeId = _asu.Payments
                        .Where(f => (f.Follow_Up_Type_Id == surgeryId)&&(f.Patient_Id==patientId))
                        .OrderByDescending(o => o.Id)
                        .Select(s => s.Id).FirstOrDefault();
                    var model3 = _asu.Payments.Find(surgeryfollowuptypeId);

                    var model1 = _asu.Facility_Reservations.Find(faciltyreservationId);
                    _asu.Remove(model1);
                    _asu.Remove(model3);
                    _asu.SaveChanges();

                    var FaciltyreservationId = _asu.Facility_Reservations.Where(f => f.Patient_Id == patientId)
                        .OrderByDescending(s => s.Id)
                      .Select(s => s.Id).FirstOrDefault();
                    var RoompriceId = _asu.Follow_Ups_Types.Where(f => f.Name == "Room").Select(s => s.Id).Single();
                    var followuptypeId = _asu.Payments
                        .Where(f => (f.Follow_Up_Type_Id == RoompriceId) && (f.Patient_Id == patientId))
                        .OrderByDescending(o => o.Id)
                        .Select(s => s.Id).FirstOrDefault();
                    var model2 = _asu.Payments.Find(followuptypeId);
                    var model = _asu.Facility_Reservations.Find(FaciltyreservationId);
                    _asu.Remove(model);
                    _asu.Remove(model2);
                    _asu.SaveChanges();


                    ViewBag.UserMessage4 = "Reservation is cancelled successfully";
                    return View();
                }
                else {
                    ViewBag.UserMessage5 = "This patient doesn't have a reservation";
                     return View()  ;
                     }
              
            }
            else
            {
                ViewBag.UserMessage5 = "This patient isn't in our hospital ";
                return View();
            }


        }
        [HttpGet]
       
        public IActionResult main()
        {
            var NameRexist = _asu.Hospital_Facilities
                .Where(f => f.Type.Substring(0,4)=="Room")
                .Select(s=>new Hospital_Facility { Type = s.Type })
                . ToList();
            var SurgeryNameRexist = _asu.Hospital_Facilities
                .Where(f => f.Type.Substring(0, 7) == "Surgery")
                .Select(s => new Hospital_Facility { Type = s.Type })
                .ToList();
            ViewBag.h1 = SurgeryNameRexist;
            ViewBag.h = NameRexist;
            return View();
        }
        [HttpGet]
        public IActionResult checkavalabilty()
        {
            String SURGERYROOMName = HttpContext.Session.GetString("SRoomname");
            String surgerystart = HttpContext.Session.GetString("STARTSurgery");
            String surgeryend = HttpContext.Session.GetString("ENDSurgery");

            return View();
        }
        [HttpPost]
            public IActionResult checkavalabilty(checkVM ch)
        {
            String SURGERYROOMName = HttpContext.Session.GetString("SRoomname");
            ViewBag.surgeryroom = SURGERYROOMName;
            var NameRexist = _asu.Hospital_Facilities.Where(f => f.Type.Substring(0, 4) == "Room")
                   .Select(s => new Hospital_Facility { Type = s.Type })
                   .ToList();
            var NameSurgeryRexist = _asu.Hospital_Facilities.Where(f => f.Type.Substring(0, 6) == "Surgery")
                  .Select(s => new Hospital_Facility { Type = s.Type })
                  .ToList();

            int y=0; //flag 
            
            foreach (var x in NameRexist)
            {


                var HID = _asu.Hospital_Facilities.Where(f => f.Type == x.Type).Select(s => s.Id).Single();
                var availableroom = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == HID)
                    .Select(s => new { date = s.End_Hour, date1 = s.Start_Hour }).ToList();
                //if(availableroom ==)
                foreach (var V in availableroom)
                {
                    DateTime parse1 = DateTime.Parse(ch.From);
                    DateTime parse2 = DateTime.Parse(ch.To);
                    DateTime parse3 = DateTime.Parse(V.date);
                    DateTime parse4 = DateTime.Parse(V.date1);
                    if ((parse1 > parse3) || (parse2 < parse4))
                    {
                        y=1;
                       
                    }
                    else 
                    {
                        y=2;
                        break;
                        
                    }
                }
                if (y==1 ||y==0) 
                {
                    // TempData["roomname"] = _asu.Hospital_Facilities.Where(f => f.Id == HID).Select(s => s.Type).Single();
                    var roomname = _asu.Hospital_Facilities.Where(f => f.Id == HID).Select(s => s.Type).Single();
                
                    ViewBag.Roomname = roomname;
                  
                    HttpContext.Session.SetString("Roomname",roomname );
                    HttpContext.Session.SetString("START", ch.From);
                    HttpContext.Session.SetString("END", ch.To);

                    return View();
                }
                y = 0;
            }
           
                ViewBag.UserMessage = "This room is not available";
                return View();
        }

        public IActionResult Roomavailabilty()
        {
             
            return View();
        }
    
        [HttpGet]
        public IActionResult Roomreservation()
        {
            String ROOMName= HttpContext.Session.GetString("Roomname");
            String start=HttpContext.Session.GetString("START");
           String end= HttpContext.Session.GetString("END");
            String SURGERYROOMName = HttpContext.Session.GetString("SRoomname");
            String surgerystart = HttpContext.Session.GetString("STARTSurgery");
            String surgeryend=HttpContext.Session.GetString("ENDSurgery");
            //var ROOMNAME = TempData["roomname"];

            //TempData["ROOMNAME"] = TempData["roomname"].ToString();
            // TempData[" HID"] = _asu.Hospital_Facilities.Where(f => f.Type ==( TempData["roomname"].ToString()) ).Select(s => s.Id).Single();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Roomreservation(roomVM ob , checkVM ch)
        {
            String ROOMName = HttpContext.Session.GetString("Roomname");
            String start = HttpContext.Session.GetString("START");
          String end= HttpContext.Session.GetString("END");
            String SURGERYROOMName = HttpContext.Session.GetString("SRoomname");
            String surgerystart = HttpContext.Session.GetString("STARTSurgery");
            String surgeryend = HttpContext.Session.GetString("ENDSurgery");
            Facility_Reservation FR = new Facility_Reservation();
            Facility_Reservation F = new Facility_Reservation();
            Payment P = new Payment();
            Payment P1 = new Payment();
            var NamePexist = _asu.Patients.ToList().Any(f => f.Name == ob.PatientName);
            var NameSexist = _asu.Staff.ToList().Any(F => F.Name == ob.DoctorName);
            
            var surgeryprice = _asu.Follow_Ups_Types.Where(f => f.Name == "Surgery").Select(s => s.Price).Single();
            var roomprice = _asu.Follow_Ups_Types.Where(f => f.Name == "Room").Select(s => s.Price).Single();
            var RoompriceId = _asu.Follow_Ups_Types.Where(f => f.Name == "Room").Select(s => s.Id).Single();
            var surgeryId = _asu.Follow_Ups_Types.Where(f => f.Name == "Surgery").Select(s => s.Id).Single();
            DateTime parse1 = DateTime.Parse(start);
            DateTime parse2 = DateTime.Parse(end);
            var Duration = parse2 - parse1;
            int days = Duration.Days+1;
            int Totalroomprice = days * roomprice;

            var HID = _asu.Hospital_Facilities.Where(f => f.Type == ROOMName).Select(s => s.Id).Single();
            
            if (NamePexist)
            {
                TempData["Patient_Id"] = _asu.Patients.Where(f => f.Name == ob.PatientName).Select(s => s.Id).Single();
                if (NameSexist)
                {
                    //string start = TempData["Start"].ToString();
                    //string end = TempData["end"].ToString();
                    //int no = (int)TempData["HID"];
                    TempData["Staff_Id"] = _asu.Staff.Where(f => f.Name == ob.DoctorName).Select(s => s.Id).Single();
                    if (SURGERYROOMName == null) {
                        FR.Start_Hour = start;  //ob.From;
                        FR.End_Hour = end;
                        FR.Hospital_Facility_Id = HID;
                        //FR.Hospital_Facility_Id =no ;
                        FR.Patient_Id = (int)TempData["Patient_Id"];
                        FR.Staff_Id = (int)TempData["Staff_Id"];
                        _asu.Add(FR);
                        P1.Patient_Id = (int)TempData["Patient_Id"];
                        P1.Money = Totalroomprice;
                        P1.Follow_Up_Type_Id = RoompriceId;
                        _asu.Add(P1);
                       _asu.SaveChanges();
                        ViewBag.UserMessage2 = "Done";
                        return View();
                    }
                    else {
                        var SHID = _asu.Hospital_Facilities.Where(f => f.Type == SURGERYROOMName).Select(s => s.Id).Single();
                        F.Start_Hour = surgerystart;  //ob.From;
                        F.End_Hour = surgeryend;
                        F.Hospital_Facility_Id = SHID;
                        //FR.Hospital_Facility_Id =no ;
                        F.Patient_Id = (int)TempData["Patient_Id"];
                        F.Staff_Id = (int)TempData["Staff_Id"];
                        _asu.Add(F);
                        FR.Start_Hour = start;  //ob.From;
                        FR.End_Hour = end;
                        FR.Hospital_Facility_Id = HID;
                        //FR.Hospital_Facility_Id =no ;
                        FR.Patient_Id = (int)TempData["Patient_Id"];
                        FR.Staff_Id = (int)TempData["Staff_Id"];

                        _asu.Add(FR);
                       
                        P.Patient_Id = (int)TempData["Patient_Id"];
                        P.Money = surgeryprice;
                        P.Follow_Up_Type_Id = surgeryId;
                        _asu.Add(P);
                        P1.Patient_Id = (int)TempData["Patient_Id"];
                        P1.Money = Totalroomprice;
                        P1.Follow_Up_Type_Id = RoompriceId;
                        _asu.Add(P1);
                        _asu.SaveChanges();
                        ViewBag.UserMessage2 = "Done";
                        return View();
                    }
                   
                }
                else
                {
                    ViewBag.UserMessage1 = "This doctor is not in our hospital";
                    return View();
                }
            }
            else
            {
                return Redirect("/Front_desk/PatientMESSAGE");
            }
            
        }
        public IActionResult RoomInfo()
        {
            return View();
        }
        public IActionResult Check()
        {
            return View();
        }
        /* public IActionResult Roomreservation(RoomReservationVM ob)
         {
             Hospital_Facility H = new Hospital_Facility();
             Facility_Reservation FR = new Facility_Reservation();
             //Patient p = new Patient();
             //var x = H.Available;

             var NamePexist = _asu.Patients.ToList().Any(f => f.Name == ob.PatientName);
             TempData["Staff_Id"] = _asu.Staff.Where(f => f.Name == ob.DoctorName).Select(s => s.Id).Single();
             var NameSexist = _asu.Staff.ToList().Any(F => F.Name == ob.DoctorName);
             var Availabilty = _asu.Hospital_Facilities.Where(f => f.Type == ob.Room).Select(s => s.Available).Single();
             var HID = _asu.Hospital_Facilities.Where(f => f.Type == ob.Room).Select(s => s.Id).Single();
             var availableroom = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == HID)
                 .Select(s => new { date = s.End_Hour, date1 = s.Start_Hour }).ToList();
             bool av; //flag

             var ROOMNAME = TempData["roomname"];
             if (availableroom == null)
             {
                 if (NamePexist)
                 {
                     TempData["Patient_Id"] = _asu.Patients.Where(f => f.Name == ob.PatientName).Select(s => s.Id).Single();
                     if (NameSexist)
                     {
                         TempData["Staff_Id"] = _asu.Staff.Where(f => f.Name == ob.DoctorName).Select(s => s.Id).Single();
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
                     if ((parse1 > parse3) || (parse2 < parse4))
                     {
                         av = true;
                     }
                     else
                     {
                         av = false;
                         ViewBag.UserMessage = "This room is Not available";
                         return View();
                         //return Redirect("/Front_desk/Roomavailabilty");
                     }
                 }
                 if (av = true)
                 {
                     if (NamePexist)
                     {
                         TempData["Patient_Id"] = _asu.Patients.Where(f => f.Name == ob.PatientName).Select(s => s.Id).Single();
                         if (NameSexist)
                         {
                             TempData["Staff_Id"] = _asu.Staff.Where(f => f.Name == ob.DoctorName).Select(s => s.Id).Single();
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

         }*/
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
            var Nameexist = _asu.Patients.ToList().Any(f => f.Name == ob.patientName);
            if (Nameexist)
            {
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
                                              .Select(s => new { dates = s.Start_Hour, dateE = s.End_Hour, name = s.Id })
                                              .OrderByDescending(w => w.dateE).FirstOrDefault();
                    //.ToList();
                    //foreach (var V in Endavailable)
                    //{
                    DateTime parse3 = DateTime.Parse(Endavailable.dates);
                    DateTime parse4 = DateTime.Parse(Endavailable.dateE);
                    //int i = V.name;
                    if ((parse3 <= ob.Today && ob.Today <= parse4))
                    {
                        var roomnumber = _asu.Facility_Reservations
                        .Where(F => F.Id == Endavailable.name)
                        .Select(s => s.Hospital_Facility_Id).Single();
                        TempData["room"] = _asu.Hospital_Facilities.Where(t => t.Id == roomnumber)
                            .Select(S => S.Type).Single();
                        return Redirect("/Front_desk/Searchresult");
                    }
                    else
                    {
                        return Redirect("/Front_desk/NotAvailable");
                    }
                    //}
                }
                return Redirect("/Front_desk/NotAvailable");
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
            var NameSurgeryRexist = _asu.Hospital_Facilities.Where(f => f.Type.Substring(0, 7) == "Surgery")
          .Select(s => new Hospital_Facility { Type = s.Type })
          .ToList();

            int f = 0;
            foreach (var x in NameSurgeryRexist)
            {
                var SHID = _asu.Hospital_Facilities.Where(f => f.Type == x.Type).Select(s => s.Id).Single();
                var Savailableroom = _asu.Facility_Reservations.Where(f => f.Hospital_Facility_Id == SHID)
                   .Select(s => new { date = s.End_Hour, date1 = s.Start_Hour }).ToList();
                foreach (var V in Savailableroom)
                {
                    DateTime parse1 = DateTime.Parse(ob.Start_Hour);
                    DateTime parse2 = DateTime.Parse(ob.End_Hour);
                    DateTime parse3 = DateTime.Parse(V.date);
                    DateTime parse4 = DateTime.Parse(V.date1);
                    if ((parse1 > parse3) || (parse2 < parse4))
                    {
                        f = 1;
                    }
                    else
                    {
                        f = 2;
                        break;

                    }

                }
                if (f == 1 || f == 0)
                {
                    var Sroomname = _asu.Hospital_Facilities.Where(f => f.Id == SHID).Select(s => s.Type).Single();
                    // ViewBag.SurgaryRoomname = Sroomname;
                    HttpContext.Session.SetString("SRoomname", Sroomname);
                    HttpContext.Session.SetString("STARTSurgery", ob.Start_Hour);
                    HttpContext.Session.SetString("ENDSurgery", ob.End_Hour);
                    return Redirect("/Front_desk/checkavalabilty");
                    /* F.Start_Hour = ob.Start_Hour;
                     F.End_Hour = ob.End_Hour;
                     F.Hospital_Facility_Id = SHID;
                     _asu.Add(F);
                     _asu.SaveChanges();
                     return Redirect("/Front_desk/done");*/
                }
                f = 0;
            }
            //}
            ViewBag.UserMessage1 = "this Surgary room is not available";
            return View();
        }
    }
    /* if (ob.SurgeryRoom == "No Surgery")
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
}*/
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





