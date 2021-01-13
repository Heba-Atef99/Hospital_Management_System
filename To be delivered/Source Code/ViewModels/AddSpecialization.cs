using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels
{
    public class AddSpecialization
    {
        [Required]
        public string Specialization { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "This field must be 4 numbers")]
        public string Code { get; set; }
    }
}
