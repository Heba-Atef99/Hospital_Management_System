using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    public class Follow_Up
    {
        public int Id { get; set; }
        public Staff Staff_ { get; set; }
        public Patient Patient_ { get; set; }
        public string Status { get; set; }
    }
}
