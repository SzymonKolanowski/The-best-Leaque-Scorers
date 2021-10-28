using System;
using System.Collections.Generic;
using System.Text;

namespace The_Best_Leaque_Scorers
{
	class ScorersandLeaques
	{
		public List<Scorer> Scorers { get; set; }
		public List<Leaque> Leaques { get; set; }

		public ScorersandLeaques()
		{
			Scorers = new List<Scorer>();
			Leaques = new List<Leaque>();
		}
	}
}
