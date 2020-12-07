using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    public class Hospital_Facility
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Boolean Available { get; set; }
        public string Start_Working_Hour { get; set; }
        public string End_Working_Hour { get; set; }
    }
}
