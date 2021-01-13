using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class SRoomReservationVM
    {
        public String SurgeryRoom { get; set; }
        [DataType(DataType.DateTime)]
        public string Start_Hour { get; set; }
        [DataType(DataType.DateTime)]
        public string End_Hour { get; set; }
    }
}
