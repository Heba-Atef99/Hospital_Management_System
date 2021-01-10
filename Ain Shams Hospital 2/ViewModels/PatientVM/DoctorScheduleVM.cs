using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_University.ViewModels
{
    public class DoctorScheduleVM
    {
        public string DoctorName { get; set; }
        public int Disabled { get; set; }
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
       
    }
}
