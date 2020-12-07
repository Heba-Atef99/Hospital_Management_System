using System;

namespace Ain_Shams_Hospital.Data.Entities
{
	public class Staff
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Starting_Day { get; set; }
		public int Specialization_Id { get; set; }
		public int Registration_Id { get; set; }
	}
}