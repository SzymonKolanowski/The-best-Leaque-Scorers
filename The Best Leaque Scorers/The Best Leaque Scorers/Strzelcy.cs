using System;
using System.Collections.Generic;
using System.Text;

namespace The_Best_Leaque_Scorers
{
	public class Scorer
	{
		public int ID { get; set; }
		public string NameandSurname { get; set; }
		public int YearofBirth { get; set; }
		public string Nation { get; set; }
	}

	public class Leaque
	{
		public int ID { get; set; }
		public string Nation { get; set; }				
	}

	public class Goal
	{
		public List <int> ScorerId { get; set; }
		public List <int> LeaqueId { get; set; }
		public List <int> NumberOfGoal { get; set; }
	}


}
