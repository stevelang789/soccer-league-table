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

        public void SetScores(int homeTeamScore, int awayTeamScore)
        {
            IsCompleted = true;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1} vs {2}",
                Date.ToString("yyyy-MM-dd"),
                HomeTeam.Name,
                AwayTeam.Name);
        }
    }
}
