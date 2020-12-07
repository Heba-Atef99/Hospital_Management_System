using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    public class Follow_Up
    {
        public int Id { get; set; }
        public Staff Staff_Id { get; set; }
        public Patient Patient_Id { get; set; }
        public string Status { get; set; }
    }
}
