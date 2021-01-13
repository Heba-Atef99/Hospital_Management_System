using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    public class Follow_Up
    {
        public int Id { get; set; }
        public int? Staff_Id { get; set; }
        [ForeignKey("Staff_Id")]
        public virtual Staff Staff { get; set; }

        public int? Patient_Id { get; set; }
        [ForeignKey("Patient_Id")]
        public virtual Patient Patient { get; set; }
        public string Status { get; set; }
    }
}
