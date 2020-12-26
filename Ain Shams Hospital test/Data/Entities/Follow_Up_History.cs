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
        public Follow_Up Follow_Up_ { get; set; }
        public string Start_Hour { get; set; }
        public string End_Hour { get; set; }
        public Follow_Up_Type Follow_Up_Type_ { get; set; }

    }
}
