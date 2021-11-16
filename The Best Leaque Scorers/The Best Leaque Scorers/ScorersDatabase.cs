using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace The_Best_Leaque_Scorers
{
	class ScorersDatabase
	{
		ScorersandLeaques scorersandLeaques = new ScorersandLeaques();
		private const string databasePath = "D://Szymon//Git//The-best-Leaque-Scorers//The Best Leaque Scorers//The Best Leaque Scorers//Scorers.json";

		public ScorersDatabase()
		{
			string json = string.Empty;
			try
			{
				json = File.ReadAllText(databasePath);
			}
			catch { }
			scorersandLeaques = JsonConvert.DeserializeObject<ScorersandLeaques>(json) ?? new ScorersandLeaques();
		}

		public IEnumerable<Scorer> ScorersList()
		{
			return scorersandLeaques.Scorers;
		}


		public void AddScorers(Scorer scorer)
		{
			scorer.ID = scorersandLeaques.Scorers.Select(s => s.ID).DefaultIfEmpty().Max() + 1;
			scorersandLeaques.Scorers.Add(scorer);
		}

		public void AddLeaques(Leaque leaque)
		{
			leaque.ID = scorersandLeaques.Leaques.Select(l => l.ID).DefaultIfEmpty().Max() + 1;
			scorersandLeaques.Leaques.Add(leaque);
		}

		public void AddGoal(Goal goal)
		{
			goal.Id = scorersandLeaques.Goals.Select(g => g.Id).DefaultIfEmpty().Max() + 1 ;
			scorersandLeaques.Goals.Add(goal);
		}

		public void SaveScorers()
		{
			var json = JsonConvert.SerializeObject(scorersandLeaques, Formatting.Indented);
			if (File.Exists(databasePath))
			{
				File.Delete(databasePath);
			}
			File.WriteAllText(databasePath, json);
		}

		public void RemoveScorers(int id)
		{
			scorersandLeaques.Scorers.RemoveAll(r => id == r.ID);
		}

		public void RemoveLeaques(int id)
		{
			scorersandLeaques.Leaques.RemoveAll(r => id == r.ID);
		}

		public void RemoveGoals(int id)
		{
			scorersandLeaques.Goals.RemoveAll(g => id == g.Id);
		}

		public Scorer GetScorerById(int id)
		{
			return scorersandLeaques.Scorers.FirstOrDefault(a => id == a.ID);
		}

		public Leaque GetLeaqueById(int id)
		{
			return scorersandLeaques.Leaques.FirstOrDefault(a => id == a.ID);
		}

		public Goal GetGoalById(int id)
		{
			return scorersandLeaques.Goals.FirstOrDefault(a => id == a.Id);
		}

		public IEnumerable<string> GetScorersNames(IEnumerable<int> idScorers)
		{
			if (idScorers == null)
			{
				return Enumerable.Empty<string>();
			}
			return scorersandLeaques.Scorers.Where(s => idScorers.Any(id => id == s.ID)).
				Select(s => s.NameandSurname);
		}

		//public IEnumerable<string> GetLeaquesNames(IEnumerable<int> idLeaque)
		//{
		//	if (idLeaque == null)
		//	{
		//		return Enumerable.Empty<string>();
		//	}
		//	return scorersandLeaques.Leaques.Where(l => idLeaque.Any(id => id == l.ID)).
		//		Select(l => l.Nation);
		//}

		//public IEnumerable<string> GetGoalNames(IEnumerable<int> idGoal)
		//{
		//	//if (idGoal == null)
		//	//{
		//	//	return Enumerable.Empty<int>();
		//	//}
		//	return scorersandLeaques.Goals.Where(g => idGoal.Any(id => id == g.Id)).
		//		Select(g => g.NumberOfGoal);

		//}

		//public void AddNextGoals(Goal goal, int goals)
		//{
		//	goal.Id[goals] = 
		//}
	}
}
