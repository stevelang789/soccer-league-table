using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SteveLang.SoccerLeagueTable.Model;
using SteveLang.SoccerLeagueTable.Services;
using SteveLang.SoccerLeagueTable.WebApi.Dtos;

namespace SteveLang.SoccerLeagueTable.WebApi.Controllers
{
    public class SoccerLeagueTableController : ApiController
    {
        private readonly LeagueTableService _leagueTableService = new LeagueTableService(); 

        // GET api/soccerleaguetable
        public StandingsAndFixturesDto Get()
        {
            var fixtures = _leagueTableService.GetFixtures();
            var standings = _leagueTableService.CalculateStandings(fixtures);
            var standingsAndFixtures = new StandingsAndFixturesDto
            {
                Standings = standings,
                Fixtures = fixtures
            };

            return standingsAndFixtures;
        }

        // POST api/soccerleaguetable
        public ICollection<LeagueTableRow> Post([FromBody] ICollection<Fixture> fixtures)
        {
            var standings = _leagueTableService.CalculateStandings(fixtures);

            return standings;
        }
    }
}
