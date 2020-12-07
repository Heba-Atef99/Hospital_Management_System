using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    [Keyless]
    public class Staff_Schedule
    {
        public Staff Staff_Id { get; set; }
        public string Working_Day { get; set; }

    }
}
