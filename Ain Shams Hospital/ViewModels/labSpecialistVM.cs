using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_University.ViewModels
{
    public class labSpecialistVM
    {
        [Required]
        public string DoctorName { get; set; }
        [Required]
        public string Test{ get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string Date { get; set; }
        public string MedicalRecord { get; set; }
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }

    }
}
