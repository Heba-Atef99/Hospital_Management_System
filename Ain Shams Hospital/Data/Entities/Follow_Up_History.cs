using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    [Keyless]
    public class Follow_Up_History
    {
        public Follow_Up Follow_Up_Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public Follow_Up_Type Type { get; set; }
    }
}
