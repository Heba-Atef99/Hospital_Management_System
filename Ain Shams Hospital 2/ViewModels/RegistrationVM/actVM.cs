using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels
{
    public class actVM
    {
        [Required]
        [MinLength(4)]
        public string Activation { get; set; }
    }
}
