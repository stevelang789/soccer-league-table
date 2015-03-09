using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SteveLang.SoccerLeagueTable.Domain;
using SteveLang.SoccerLeagueTable.Model;

namespace SteveLang.SoccerLeagueTable.Repository.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SoccerLeagueContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SoccerLeagueContext context)
        {
            var startDate = new DateTime(2014, 10, 4);
            var intervalInDays = 14;

            var league = CreateLeague();
            context.Leagues.Add(league);
            context.SaveChanges();

            var teams = CreateTeams(league);
            teams.ToList().ForEach(team => context.Teams.Add(team));
            context.SaveChanges();

            var fixtures = CreateFixtures(league, teams, startDate, intervalInDays);
            fixtures.ToList().ForEach(fixture => context.Fixtures.Add(fixture));
            context.SaveChanges();
        }

        private static League CreateLeague()
        {
            var league = new League
            {
                Id = Guid.NewGuid(),
                Name = "Melbourne Fictional Charity Shield",
                Season = "2015"
            };

            return league;
        }

        private static ICollection<Team> CreateTeams(League league)
        {
            var teams = new List<Team>
            {
                new Team
                {
                    Id = Guid.NewGuid(),
                    League = league,
                    Name = "Hume SC"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    League = league,
                    Name = "Manningham SC"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    League = league,
                    Name = "Dandenong SC"
                },
                new Team
                {
                    Id = Guid.NewGuid(),
                    League = league,
                    Name = "Melton SC"
                }
            };

            return teams;
        }

        private static ICollection<Fixture> CreateFixtures(
            League league,
            ICollection<Team> teams,
            DateTime startDate,
            int intervalInDays)
        {
            var fixtureGenerator = new FixtureGenerator();
            var fixtures = fixtureGenerator.GenerateDoubleRoundRobinFixtures(league, teams, startDate, intervalInDays);

            return fixtures;
        }
    }
}
