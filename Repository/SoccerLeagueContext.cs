using System.Data.Entity;
using SteveLang.SoccerLeagueTable.Model;

namespace SteveLang.SoccerLeagueTable.Repository
{
    public class SoccerLeagueContext : DbContext
    {
        public SoccerLeagueContext() : base("SoccerLeagueContext")
        {
        }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
    }
}
