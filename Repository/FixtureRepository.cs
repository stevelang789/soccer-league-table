using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteveLang.SoccerLeagueTable.Model;

namespace SteveLang.SoccerLeagueTable.Repository
{
    public class FixtureRepository
    {
        public ICollection<Fixture> GetFixtures()
        {
            using (var context = new SoccerLeagueContext())
            {
                context.Configuration.LazyLoadingEnabled = false;

                return context.Fixtures
                    .Include("HomeTeam")
                    .Include("AwayTeam")
                    .ToArray();
            }
        }

        public void UpdateFixtures(ICollection<Fixture> fixtures)
        {
            using (var context = new SoccerLeagueContext())
            {
                foreach (var fixture in fixtures)
                {
                    var fixtureInDb = context.Fixtures.Find(fixture.Id);
                    if (fixtureInDb == null) continue;

                    fixtureInDb.IsCompleted = fixture.IsCompleted;
                    fixtureInDb.HomeTeamScore = fixture.HomeTeamScore;
                    fixtureInDb.AwayTeamScore = fixture.AwayTeamScore;
                }

                context.SaveChanges();
            }
        }
    }
}
