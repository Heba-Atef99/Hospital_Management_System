using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
