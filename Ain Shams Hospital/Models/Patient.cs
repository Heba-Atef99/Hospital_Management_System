using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ain_Shams_Hospital.Models
{
	public class Patient
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Phone { get; set; }
		public int Registration_Id { get; set; }
		public int Hospital_Id { get; set; }
		public string Medical_Record { get; set; }
		//Statistics
		public int Health_Progress { get; set; }
	}
}
