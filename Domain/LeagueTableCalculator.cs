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
        public ICollection<LeagueTableRow> Calculate(ICollection<Team> teams, ICollection<Fixture> fixtures)
        {
            var leagueTableRows = new List<LeagueTableRow>();

            foreach (var team in teams)
            {
                var completedHomeGames = fixtures
                    .Where(fixture => fixture.IsCompleted && fixture.HomeTeam.Id == team.Id)
                    .ToArray();
                var completedAwayGames = fixtures
                    .Where(fixture => fixture.IsCompleted && fixture.AwayTeam.Id == team.Id)
                    .ToArray();
                var played = completedHomeGames.Length + completedAwayGames.Length;
                var won = completedHomeGames
                    .Where(fixture => fixture.HomeTeamScore > fixture.AwayTeamScore)
                    .ToArray();
            }

            throw new NotImplementedException();
        }
    }
}
