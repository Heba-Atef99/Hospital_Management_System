using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels 
{
    public class DoctorSchedule///for Doctor schedule
    {
       
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Disabled { get; set; }
    }
}
