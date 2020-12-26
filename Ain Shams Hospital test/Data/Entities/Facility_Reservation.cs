using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    [Keyless]
    public class Facility_Reservation
    {
        public Hospital_Facility Hospital_Facility_ { get; set; }
        public string Start_Hour { get; set; }
        public string End_Hour { get; set; }
        public Staff Staff_ { get; set; }
        public Patient Patient_ { get; set; }
    }
}
