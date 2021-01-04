using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels
{
    public class RegistrationStaffVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Starting_Day { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MinLength(4)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        

    }
}


