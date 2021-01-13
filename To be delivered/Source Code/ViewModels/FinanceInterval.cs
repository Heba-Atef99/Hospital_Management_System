using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class FinanceInterval
    {
      
        [Required]
        [DataType(DataType.DateTime)]
        public string From { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string To { get; set; }
       
    }
}
