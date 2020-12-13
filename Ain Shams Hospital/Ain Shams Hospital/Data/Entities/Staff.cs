using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
	public class Staff
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Starting_Day { get; set; }
		public Specialization Specialization_ { get; set; }
		public int? Registration_Id { get; set; }
		[ForeignKey("Registration_Id")]
		public virtual Registration Registration { get; set; }
		
	}
}