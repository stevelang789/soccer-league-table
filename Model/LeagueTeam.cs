using System;

namespace SteveLang.SoccerLeagueTable.Model
{
    public class LeagueTeam
    {
        public Guid Id { get; set; }
        public virtual League League { get; set; }
        public virtual Team Team { get; set; }
    }
}
