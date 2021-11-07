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
        public List<int> GoalIds { get; set; }

	}

	public class Leaque
	{
		public int ID { get; set; }
		public string Nation { get; set; }
	}

	public class Goal
	{
		public int Id { get; set; }
		public int NumberOfGoal { get; set; }
        public GoalId Ids { get; set; }
    }

    public class GoalId : IEquatable<GoalId>
    {
        public GoalId(int leagueId, int scorerId)
        {
            LeagueId = leagueId;
            ScorerId = scorerId;
        }

        public int LeagueId { get; private set; }
        public int ScorerId { get; private set; }

        public bool Equals(GoalId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return LeagueId == other.LeagueId && ScorerId == other.ScorerId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GoalId)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashcode = 1430287;
                hashcode = hashcode * 7302013 ^ LeagueId.GetHashCode();
                hashcode = hashcode * 7302013 ^ ScorerId.GetHashCode();
                return hashcode;
            }
        }
    }

}

	

	

	


