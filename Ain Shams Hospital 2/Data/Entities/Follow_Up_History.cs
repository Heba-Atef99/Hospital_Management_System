using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
    [Keyless]
    public class Follow_Up_History
    {
        public int? Follow_Up_Id { get; set; }
        [ForeignKey("Follow_Up_Id")]
        public virtual Follow_Up Follow_Up { get; set; }
        public string Start_Hour { get; set; }
        public string End_Hour { get; set; }
        public int? Follow_Up_Type_Id { get; set; }
        [ForeignKey("Follow_Up_Type_Id")]
        public virtual Follow_Up_Type Follow_Up_Type { get; set; }

    }
}
