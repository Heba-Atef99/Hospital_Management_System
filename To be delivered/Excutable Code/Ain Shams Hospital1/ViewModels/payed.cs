﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class payed
    {
        [Required]
        public string PatientName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public string Todaydate { get; set; }
        public List<int> isactive { get; set; }

    }
}
