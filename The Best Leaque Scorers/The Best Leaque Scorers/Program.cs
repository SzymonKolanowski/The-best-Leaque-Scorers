using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace The_Best_Leaque_Scorers
{
	class Program
	{
		private static ScorersDatabase database = new ScorersDatabase();
		static void Main(string[] args)
		{
			string command = string.Empty;
			do
			{
				Console.WriteLine("If you want add scorer write 'AddScorer'");
				Console.WriteLine("If you want remove scorer write 'RemoveScorers'");
				Console.WriteLine("If you want see list of scorer write 'ScorersList'");
				Console.WriteLine("If you want see only one scorer write 'ShowScorer'");
				Console.WriteLine("If you want add leaque to scorer list write 'AddLeaquetoScorer'");
				Console.WriteLine("If you want remove leaque from scorer list write 'RemoveLeaqueFromScorerList'");
				Console.WriteLine("If you want add leaque write 'AddLeaque'");
				Console.WriteLine("If you want remove leaque write 'RemoveLeaques'");
				Console.WriteLine("If you want see only one leque write 'ShowLeaque'");
				Console.WriteLine("If you want add scorer to leaque list write 'AddScorertoLeaque'");
				Console.WriteLine("If you want remove scorer from leaque list write'RemoveScorerFromLeaqueList'");

				command = Console.ReadLine();

				switch (command)
				{

					case "AddScorer":
						AddScorer();
						break;
					case "RemoveScorers":
						RemoveScorers();
						break;
					case "ScorerList":
						ScorersList();
						break;
					case "ShowScorer":
						ShowScorer();
						break;
					case "AddLeaquetoScorer":
						AddLeaquetoScorer();
						break;
					//case "RemoveLeaqueFromScorerList":
					//	RemoveLeaqueFromScorerList();
					//break;
					case "AddLeaque":
						AddLeaques();
						break;
					case "RemoveLeaques":
						RemoveLeaques();
						break;
					case "ShowLeaque":
						ShowLeaque();
						break;
					//case "AddScorertoLeaque":
					//	AddScorertoLeaque();
					//	break;
					//case "RemoveScorerFromLeaqueList":
					//	RemoveScorerFromLeaqueList();
					//	break;

				}
			} while (command != "Exit");

			Console.WriteLine("Exiting program");
			database.SaveScorers();
		}

		private static void WriteJson(object obj)
		{
			var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
			Console.WriteLine(json);
		}

		private static int GetIntParameter()
		{
			var idInput = Console.ReadLine();
			var id = int.TryParse(idInput, out var parsedID)
				? parsedID
				: 0;
			return id;
		}

		private static void AddScorer()
		{
			Console.WriteLine(" Name and Surname:");
			var nameandsurname = Console.ReadLine();

			Console.WriteLine("Nation");
			var nation = Console.ReadLine();

			Console.WriteLine("YearofBirth");
			var yearofbirth = GetIntParameter();

			var scorer = new Scorer
			{
				NameandSurname = nameandsurname,
				Nation = nation,
				YearofBirth = yearofbirth
			};

			database.AddScorers(scorer);
		}

		private static void RemoveScorers()
		{
			Console.WriteLine("Write id of Scorer to deleted");
			var id = GetIntParameter();
			database.RemoveScorers(id);
		}

		private static void ScorersList()
		{
			var scorers = database.ScorersList();
			WriteJson(scorers);
		}

		private static void ShowScorer()
		{
			Console.WriteLine("Choose scorer which you want to see");

			var idscorer = GetIntParameter();

			Scorer scorer = database.GetScorerById(idscorer);

			//Goal goal = 

			var leaques = database.GetLeaquesNames(scorer.LeaqueId);

			var scorerViewModel = new
			{
				scorer.ID,
				scorer.NameandSurname,
				scorer.Nation,
				scorer.YearofBirth,
				LeaqueNames = leaques
			};

			WriteJson(scorerViewModel);
		}

		private static void AddLeaques()
		{
			Console.WriteLine("Nation:");
			var nation = Console.ReadLine();

			var leaque = new Leaque
			{
				Nation = nation
			};

			database.AddLeaques(leaque);
		}

		private static void RemoveLeaques()
		{
			Console.WriteLine("Write the id of Leaque to deleted");

			var idleaque = GetIntParameter();

			database.RemoveLeaques(idleaque);
		}

		private static void ShowLeaque()
		{
			Console.WriteLine("Choose leaque which you want to see");

			var idleaque = GetIntParameter();

			Leaque leaque = database.GetLeaqueById(idleaque);

			//var scorer = database.GetScorersNames(leaque.ScorersIds);

			var leaqueViewModel = new
			{
				leaque.ID,
				leaque.Nation,
				//ScorersNames = scorer
			};
			WriteJson(leaqueViewModel);
		}

		private static void AddLeaquetoScorer()
		{
			Console.WriteLine("choose id of scorer");
			var idScorer = GetIntParameter();

			Console.WriteLine("choose id of leaque");
			var idLeaque = GetIntParameter();

			Console.WriteLine("Goals in this Leaque");
			var goals = GetIntParameter();

			var scorer = database.GetScorerById(idScorer);
			scorer.LeaqueId ??= new List<int>();
			scorer.LeaqueId.Add(idLeaque);

			scorer.NumberOfGoals ??= new List<int>();
			scorer.NumberOfGoals.Add(goals);
		}

		//private static void AddScorertoLeaque()
		//{
		//	Console.WriteLine("choose id of leaque");
		//	var idLeaque = GetIntParameter();

		//	Console.WriteLine("Choose id of scorer");
		//	var idScorer = GetIntParameter();

		//	Console.WriteLine("Goals in this Leaque");
		//	var goals = GetIntParameter();

		//	var leaque = database.GetLeaqueById(idLeaque);
		//	leaque.ScorersIds ??= new List<int>();
		//	leaque.ScorersIds.Add(idScorer);
		//}

		//private static void RemoveLeaqueFromScorerList()
		//{
		//	Console.WriteLine("Choose id of scorer");
		//	var idScorer = GetIntParameter();

		//	Console.WriteLine("choose id of Leaque from scorer list");
		//	var idLeaque = GetIntParameter();

		//	var scorer = database.GetScorerById(idScorer);
		//	scorer.LeaqueIds.Remove(idLeaque);
		//}

		//private static void RemoveScorerFromLeaqueList()
		//{
		//	Console.WriteLine("Choose id of leaque");
		//	var idLeaque = GetIntParameter();

		//	Console.WriteLine("choose id of Scorer from Leaque List");
		//	var idScorer = GetIntParameter();

		//	var leaque = database.GetLeaqueById(idLeaque);
		//	leaque.ScorersIds.Remove(idScorer);
		//}
	}
}
