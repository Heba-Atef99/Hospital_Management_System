using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_University.ViewModels
{
    public class DonationsVM
    {
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string  Name { get; set; }
        [Required]
        public string Day { get; set; }
        [EmailAddress ]
        public string Email { get; set; }
        [Key]
        public int Id { get; set; }
        [Phone]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
    }
}
