using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    
    public class Staff_Schedule
    {
        public int Id { get; set; }
        public int? Specialization_Id { get; set; }
        [ForeignKey("Specialization_Id")]
        public virtual Specialization Specialization { get; set; }
        public string Working_Day { get; set; }

    }
}
