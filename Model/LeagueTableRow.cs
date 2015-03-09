
namespace SteveLang.SoccerLeagueTable.Model
{
    public class LeagueTableRow
    {
        public string TeamName { get; set; }
        public int Played { get; set; }
        public int Won { get; set; }
        public int Drew { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0,-15} {1,3} {2,3} {3,3} {4,3} {5,3} {6,3} {7,3} {8,3}",
                TeamName,
                Played,
                Won,
                Drew,
                Lost,
                GoalsFor,
                GoalsAgainst,
                GoalDifference,
                Points);
        }
    }
}
