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
        public virtual Patient Patient { get; set; }
        public int Money { get; set; }
        public bool Payed { get; set; }
        public string Date { get; set; }
        public int? Follow_Up_Type_Id { get; set; }
        [ForeignKey("Follow_Up_Type_Id")]
        public virtual Follow_Up_Type Follow_Up_Type { get; set; }
        public bool Online { get; set; }


    }
}
