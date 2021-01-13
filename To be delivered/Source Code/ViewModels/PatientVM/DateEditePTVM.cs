using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_University.ViewModels
{
    public class DateEditePTVM
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public string DateEdite { get; set; }
        public string Hour { get; set; }
    }
}
