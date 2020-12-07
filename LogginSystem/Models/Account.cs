using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogginSystem.Models
{
    public class Account
    {
        [Display(Name ="Email ID")]
        [Required (AllowEmptyStrings =false , ErrorMessage ="Email ID required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remmeber me")]
        public bool remmeberme { get; set; }
    }
}