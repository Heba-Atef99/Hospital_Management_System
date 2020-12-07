using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
	public class Staff
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Phone { get; set; }
		public string Starting_Day { get; set; }
		public int Specialization_Id { get; set; }
		public int Registration_Id { get; set; }
	}
}