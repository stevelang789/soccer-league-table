using System;

namespace SteveLang.SoccerLeagueTable.Model
{
    public class Team
    {
        public Guid Id { get; set; }
        public virtual League League { get; set; }
        public string Name { get; set; }
    }
}
