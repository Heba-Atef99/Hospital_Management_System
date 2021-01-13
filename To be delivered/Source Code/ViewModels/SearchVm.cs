using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class SearchVm
    {
        [Required]
        public String patientName {get;set;}
        [Required]
        public DateTime Today { get; set; }
    }
}
