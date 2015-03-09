using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteveLang.SoccerLeagueTable.Model;

namespace SteveLang.SoccerLeagueTable.WebApi.Dtos
{
    public class StandingsAndFixturesDto
    {
        public ICollection<LeagueTableRow> Standings { get; set; }
        public ICollection<Fixture> Fixtures { get; set; }
    }
}