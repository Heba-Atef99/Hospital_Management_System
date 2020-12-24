using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    [Keyless]
    public class Facility_Reservation
    {
        public int? Hospital_Facility_Id { get; set; }
        [ForeignKey("Hospital_Facility_Id")]
        public virtual Hospital_Facility Hospital_Facility { get; set; }

        public string Start_Hour { get; set; }
        public string End_Hour { get; set; }
        public int? Staff_Id { get; set; }
        [ForeignKey("Staff_Id")]
        public virtual Staff Staff { get; set; }

        public int? Patient_Id { get; set; }
        [ForeignKey("Patient_Id")]
        public virtual Patient Patient { get; set; }

    }
}
