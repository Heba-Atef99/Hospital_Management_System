using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public Patient Patient_Id { get; set; }

        public int Money { get; set; }
        public bool payed { get; set; }

    }
}
