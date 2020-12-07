using System;

namespace Ain_Shams_Hospital.Data.Entities
{
	public class Patient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public int Registration_Id { get; set; }
		public int Hospital_Id { get; set; }
		public string Medical_Record { get; set; }
		//Statistics
		public int Health_Progress { get; set; }
	}
}
