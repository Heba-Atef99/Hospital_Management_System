using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int? Patient_Id { get; set; }
        [ForeignKey("Patient_Id")]
        public int Money { get; set; }
        public bool Payed { get; set; }

    }
}
