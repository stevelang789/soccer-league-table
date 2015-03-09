using System;

namespace SteveLang.SoccerLeagueTable.Model
{
    public class Fixture
    {
        public Guid Id { get; set; }
        public virtual League League { get; set; }
        public DateTime Date { get; set; }
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public bool IsCompleted { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public override string ToString()
        {
            return Date.ToString("yyyy-MM-dd") + ": " + HomeTeam.Name + " vs " + AwayTeam.Name;
        }
    }
}
