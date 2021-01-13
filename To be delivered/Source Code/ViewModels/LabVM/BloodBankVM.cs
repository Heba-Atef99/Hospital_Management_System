using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.ViewModels.LabVM
{
    public class BloodBankVM
    {
        public List<int> Amount { get; set; }
        public string Add { get; set; }
        public int Delete { get; set; }
        public string NewType { get; set; }
        public int NewAmount { get; set; }
        public int NewAdd { get; set; }

    }
}
