using SteveLang.SoccerLeagueTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteveLang.SoccerLeagueTable.Domain
{
    public class FixtureGenerator
    {
        public ICollection<Fixture> GenerateDoubleRoundRobinFixtures(
            League league,
            ICollection<Team> teams,
            DateTime startDate,
            int intervalInDays)
        {
            var fixtures = new List<Fixture>();
            var fixtureDate = startDate;

            foreach (var team1 in teams)
            {
                foreach (var team2 in teams)
                {
                    if (team2.Name == team1.Name) continue;

                    var fixture = new Fixture
                    {
                        Id = Guid.NewGuid(),
                        League = league,
                        Date = fixtureDate,
                        HomeTeam = team1,
                        AwayTeam = team2
                    };
                    fixtures.Add(fixture);

                    fixtureDate = fixtureDate.AddDays(intervalInDays);
                }
            }

            return fixtures;
        }
    }
}
