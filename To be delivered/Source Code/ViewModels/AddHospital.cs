﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AinShamsHospital.ViewModels
{
    public class AddHospital
    {
        [Required]
        public string Hospital{ get; set; }
    }
}
