using System.Collections.Generic;
using System.Linq;
using SteveLang.SoccerLeagueTable.Model;

namespace SteveLang.SoccerLeagueTable.Repository
{
    public class TeamRepository
    {
        public ICollection<Team> GetTeams()
        {
            using (var context = new SoccerLeagueContext())
            {
                return context.Teams.ToArray();
            }
        }
    }
}
