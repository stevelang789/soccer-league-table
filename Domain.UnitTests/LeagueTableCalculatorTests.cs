using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteveLang.SoccerLeagueTable.Model;

namespace SteveLang.SoccerLeagueTable.Domain.UnitTests
{
    [TestClass]
    public class LeagueTableCalculatorTests
    {
        [TestMethod]
        public void LeagueTableRowsCorrectlyCalculatedFor4Teams()
        {
            // Arrange
            var league = new League { Id = Guid.NewGuid(), Name = "Test League" };
            var teams = new Team[]
            {
                new Team { Id = Guid.NewGuid(), Name = "Team A" },
                new Team { Id = Guid.NewGuid(), Name = "Team B" },
                new Team { Id = Guid.NewGuid(), Name = "Team C" },
                new Team { Id = Guid.NewGuid(), Name = "Team D" }
            };
            var fixtureGenerator = new FixtureGenerator();
            var fixtures = fixtureGenerator.GenerateDoubleRoundRobinFixtures(league, teams, new DateTime(2014, 10, 4), 7);
            var teamAvsTeamD = fixtures
                .Single(fixture => fixture.HomeTeam.Name == "Team A" && fixture.AwayTeam.Name == "Team D");
            teamAvsTeamD.SetScores(4, 2);
            var teamDvsTeamA = fixtures
                .Single(fixture => fixture.HomeTeam.Name == "Team D" && fixture.AwayTeam.Name == "Team A");
            teamDvsTeamA.SetScores(0, 1);
            var teamAvsTeamC = fixtures
                .Single(fixture => fixture.HomeTeam.Name == "Team A" && fixture.AwayTeam.Name == "Team C");
            teamAvsTeamC.SetScores(1, 1);

            // Act
            var leagueTableCalculator = new LeagueTableCalculator();
            var leagueTableRows = leagueTableCalculator.Calculate(teams, fixtures);

            leagueTableRows.ToList().ForEach(row => Trace.WriteLine(row));
        }
    }
}
