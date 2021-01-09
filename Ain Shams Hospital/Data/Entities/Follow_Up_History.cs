using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
   
    public class Follow_Up_History
    {
     
        public int Id { get; set; }
        public int? Follow_Up_Id { get; set; }
        [ForeignKey("Follow_Up_Id")]
        public virtual Follow_Up Follow_Up { get; set; }
        public string Date { get; set; }
        public int? Follow_Up_Type_Id { get; set; }
        [ForeignKey("Follow_Up_Type_Id")]
        public virtual Follow_Up_Type Follow_Up_Type { get; set; }

    }
}
