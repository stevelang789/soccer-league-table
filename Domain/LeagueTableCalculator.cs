using SteveLang.SoccerLeagueTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteveLang.SoccerLeagueTable.Domain
{
    public class LeagueTableCalculator
    {
        public static readonly int PointsForWin = 3;
        public static readonly int PointsForDraw = 1;
        public static readonly int PointsForLoss = 0;

        public ICollection<LeagueTableRow> Calculate(ICollection<Team> teams, ICollection<Fixture> fixtures)
        {
            var unorderedRows = new List<LeagueTableRow>();

            foreach (var team in teams)
            {
                var completedHomeGames = fixtures
                    .Where(fixture => fixture.IsCompleted && fixture.HomeTeam.Id == team.Id)
                    .ToArray();
                var completedAwayGames = fixtures
                    .Where(fixture => fixture.IsCompleted && fixture.AwayTeam.Id == team.Id)
                    .ToArray();
                var played = completedHomeGames.Length + completedAwayGames.Length;
                var won = completedHomeGames.Count(fixture => fixture.HomeTeamScore > fixture.AwayTeamScore) +
                    completedAwayGames.Count(fixture => fixture.AwayTeamScore > fixture.HomeTeamScore);
                var drew = completedHomeGames.Count(fixture => fixture.HomeTeamScore == fixture.AwayTeamScore) +
                    completedAwayGames.Count(fixture => fixture.AwayTeamScore == fixture.HomeTeamScore);
                var lost = completedHomeGames.Count(fixture => fixture.HomeTeamScore < fixture.AwayTeamScore) +
                    completedAwayGames.Count(fixture => fixture.AwayTeamScore < fixture.HomeTeamScore);
                var goalsFor = completedHomeGames.Sum(fixture => fixture.HomeTeamScore) +
                    completedAwayGames.Sum(fixture => fixture.AwayTeamScore);
                var goalsAgainst = completedHomeGames.Sum(fixture => fixture.AwayTeamScore) +
                    completedAwayGames.Sum(fixture => fixture.HomeTeamScore);
                var goalDifference = goalsFor - goalsAgainst;
                var points = (won * PointsForWin) + (drew * PointsForDraw) + (lost * PointsForLoss);

                var leagueTableRow = new LeagueTableRow
                {
                    TeamName = team.Name,
                    Played = played,
                    Won = won,
                    Drew = drew,
                    Lost = lost,
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst,
                    GoalDifference = goalDifference,
                    Points = points
                };
                unorderedRows.Add(leagueTableRow);
            }

            var playedRows = unorderedRows
                .Where(row => row.Played > 0)
                .OrderByDescending(row => row.Points)
                .ThenBy(row => row.Played)
                .ThenByDescending(row => row.GoalDifference)
                .ThenByDescending(row => row.GoalsFor)
                .ToArray();

            var unplayedRows = unorderedRows
                .Where(row => row.Played == 0)
                .OrderBy(row => row.TeamName)
                .ToArray();

            var orderedRows = new List<LeagueTableRow>();
            orderedRows.AddRange(playedRows);
            orderedRows.AddRange(unplayedRows);

            return orderedRows;
        }
    }
}
