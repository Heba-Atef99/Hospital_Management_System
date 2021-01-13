using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class AddPrice
    {
        [Required]
        public string ServiceName { get; set; }
        [Required]
        public int ServicePrice { get; set; }
    }
}
