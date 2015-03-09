using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteveLang.SoccerLeagueTable.Model;
using SteveLang.SoccerLeagueTable.Repository;
using SteveLang.SoccerLeagueTable.Domain;

namespace SteveLang.SoccerLeagueTable.Services
{
    public class LeagueTableService
    {
        private readonly FixtureRepository _fixtureRepository = new FixtureRepository();
        private readonly TeamRepository _teamRepository = new TeamRepository();
        private readonly LeagueTableCalculator _leagueTableCalculator = new LeagueTableCalculator();
 
        public ICollection<Fixture> GetFixtures()
        {
            return _fixtureRepository.GetFixtures();
        }

        public void UpdateFixtures(ICollection<Fixture> fixtures)
        {
            _fixtureRepository.UpdateFixtures(fixtures);
        }

        public ICollection<LeagueTableRow> CalculateStandings(ICollection<Fixture> fixtures)
        {
            var teams = _teamRepository.GetTeams();
            var standings = _leagueTableCalculator.CalculateStandings(teams, fixtures);

            return standings;
        }
    }
}
