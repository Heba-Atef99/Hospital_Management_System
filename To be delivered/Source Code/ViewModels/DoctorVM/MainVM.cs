using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels.DoctorVM
{
    public class MainVM
    {
        public int P_Id { get; set; }
        public string Search_Item { get; set; }
        public string Sort_Item { get; set; }
        public string Order_Item { get; set; }
    }
}
