using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels.DoctorVM
{
    public class PatientFollowUpVM
    {
        

        public string Medical_Record { get; set; }
        public int Health_Progress { get; set; }
        public string Status { get; set; }
    }
}
