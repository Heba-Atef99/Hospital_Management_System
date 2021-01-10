using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels 
{
    public class FollowupDoctor
    {
        [Required(ErrorMessage = "Please select")]
        public string DoctorSpecialization { get; set; }

        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public int Disabled { get; set; }
    }
}
