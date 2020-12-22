using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication10.ViewModels
{
    public class RoomReservationVM
    {
        [Required]
        public String PatientName { get; set; }
        [Required]
        public String DoctorName { get; set; }
        [Required]
        public String Room { get; set; }
        [DataType(DataType.DateTime)]
        public string From  { get; set; }
        [DataType(DataType.DateTime)]
        public string To { get; set; }
        public String SurgeryRoom { get; set; }
        [DataType(DataType.DateTime)]
        public string Start_Hour { get; set; }
        [DataType(DataType.DateTime)]
        public string End_Hour { get; set; }

    }
}
