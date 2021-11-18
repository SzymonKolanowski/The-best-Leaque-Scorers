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
				Console.WriteLine("If you want add goal to scorer and leaque list write 'AddGoal'");
				Console.WriteLine("If you want add goal Id to Scorer list write 'AddGoalToScorer'");
				Console.WriteLine("If you want remove goal from scorer and leaque list write 'RemoveGoals'");
				Console.WriteLine("If you want add leaque write 'AddLeaque'");
				Console.WriteLine("If you want remove leaque write 'RemoveLeaques'");
				Console.WriteLine("If you want see only one leque write 'ShowLeaque'");
				Console.WriteLine("if you want add goal Id to Leaque list write 'AddGoaltoLeaque'");
				Console.WriteLine("if you want remove goal Id from scorer list write 'RemoveGoalIdFromScorerList'");
				Console.WriteLine("if you want remove goal Id from leaque list write 'RemoveGoalIdFromLeaqueList'");
				Console.WriteLine("if you want see only one goal id write 'ShowGoalId'");
				
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
					case "AddGoal":
						AddGoal();
						break;
					case "RemoveGoals":
						RemoveGoals();
						break;
					case "AddGoalToScorer":
						AddGoalToScorer();
						break;
					case "AddLeaque":
						AddLeaques();
						break;
					case "RemoveLeaques":
						RemoveLeaques();
						break;
					case "ShowLeaque":
						ShowLeaque();
						break;
					case "AddGoalToLeaque":
						AddGoalToLeaque();
						break;
					case "RemoveGoalIdFromScorerList":
						RemoveGoalIdFromScorerList();
						break;
					case "RemoveGoalIdFromLeaqueList":
						RemoveGoalIdFromLeaqueList();
						break;
					case "ShowGoalId":
						ShowGoalId();
						break;


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

		public static int GetIntParameter2()
		{
			var userInput = "";
			var parameter = -1;
			do
			{
				Console.WriteLine("Type " +  "id");
				userInput = Console.ReadLine();
			} while (!int.TryParse(userInput, out parameter));

			return parameter;
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

			var leaque = database.GetLeaquesNames(scorer.GoalIds);

			var goals = database.GetGoalNames(scorer.GoalIds);

			var scorerViewModel = new
			{
				//scorer.ID,
				scorer.NameandSurname,
				scorer.Nation,
				scorer.YearofBirth,
				//scorer.GoalIds
				LeaqueNames = leaque,
				Goals = goals
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

			var scorer = database.GetScorersNames(leaque.GoalIds);

			var goal = database.GetGoalNames(leaque.GoalIds);		

			var leaqueViewModel = new
			{
				leaque.Nation,				
				ScorerNames = scorer,
				Gol = goal
				
			};
			WriteJson(leaqueViewModel);
		}

		private static void ShowGoalId()
		{
			Console.WriteLine("Choose goal Id which you want to see");

			var idGoal = GetIntParameter();

			Goal goal = database.GetGoalById(idGoal);

			//var scorer = database.GetScorersNames(goal.Ids.ScorerId);

			var goalViewModel = new
			{
				goal.NumberOfGoal,
				//goal.Ids
			};

			WriteJson(goalViewModel);
		}

		private static void AddGoal()
		{
			Console.WriteLine("choose id of scorer");
			var idScorer = GetIntParameter();

			Console.WriteLine("choose id of leaque");
			var idLeaque = GetIntParameter();

			Console.WriteLine("Goals in this Leaque");
			var goals = GetIntParameter();

			var goal = new Goal()
			{
				NumberOfGoal = goals,
				Ids = new GoalId(idScorer,idLeaque)
			};

			database.AddGoal(goal);
		}

		private static void RemoveGoals()
		{
			Console.WriteLine("Choose Id of goal which you want to remove");
			var idGoal = GetIntParameter();

			database.RemoveGoals(idGoal);
		}

		private static void AddGoalToScorer()
		{
			Console.WriteLine("Choose id of scorer");
			var idScorer = GetIntParameter();

			Console.WriteLine("choose id of goal");
			var idGoal = GetIntParameter();

			var scorer = database.GetScorerById(idScorer);
			scorer.GoalIds ??= new List<int>();
			scorer.GoalIds.Add(idGoal);
		}

		private static void AddGoalToLeaque()
		{
			Console.WriteLine("Choose id of leaque");
			var idLeaque = GetIntParameter();

			Console.WriteLine("choose id of goal");
			var idGoal = GetIntParameter();

			var leaque = database.GetLeaqueById(idLeaque);
			leaque.GoalIds ??= new List<int>();
			leaque.GoalIds.Add(idGoal);
		}
		
		private static void RemoveGoalIdFromScorerList()
		{
			Console.WriteLine("choose id of scorer");
			var idScorer = GetIntParameter();

			Console.WriteLine("choose goal Id which you want to remove from scorer list");
			var idGoal = GetIntParameter();

			var scorer = database.GetScorerById(idScorer);
			scorer.GoalIds.Remove(idGoal);
		}

		private static void RemoveGoalIdFromLeaqueList()
		{
			Console.WriteLine("choose id of scorer");
			var idLeaque = GetIntParameter();

			Console.WriteLine("choose goal Id which you want to remove from leaque list");
			var idGoal = GetIntParameter();

			var leaque = database.GetLeaqueById(idLeaque);
			leaque.GoalIds.Remove(idGoal);
		}

	}
}
