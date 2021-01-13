using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class roomVM
    {
        [Required]
        public String PatientName { get; set; }
        [Required]
        public String DoctorName { get; set; }
    }
}
