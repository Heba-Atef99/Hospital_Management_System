﻿using Ain_Shams_Hospital.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels 
{
    public class FollowClass
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select")]
        public string DoctorsName { get; set; }
        public int Name { get; set; }
    }
}