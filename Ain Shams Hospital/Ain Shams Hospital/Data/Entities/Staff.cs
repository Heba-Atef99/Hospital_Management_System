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
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Starting_Day { get; set; }
		public Specialization Specialization_ { get; set; }
		public Registration Registration_ { get; set; }
	}
}