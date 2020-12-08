using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Data.Entities
{
	public class Patient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public Registration Registration_ { get; set; }
		public Transfer_Hospital Hospital_ { get; set; }
		public string Medical_Record { get; set; }
		//Statistics
		public int Health_Progress { get; set; }
	}
}
