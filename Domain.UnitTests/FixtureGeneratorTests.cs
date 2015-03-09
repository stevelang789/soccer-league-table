using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteveLang.SoccerLeagueTable.Model;
using System;
using System.Diagnostics;
using System.Linq;

namespace SteveLang.SoccerLeagueTable.Domain.UnitTests
{
    [TestClass]
    public class FixtureGeneratorTests
    {
        [TestMethod]
        public void FixturesCorrectlyGeneratedFor3Teams()
        {
            // Arrange
            var league = new League { Id = Guid.NewGuid(), Name = "Test League" };
            var teams = new Team[]
            {
                new Team { Id = Guid.NewGuid(), Name = "Team A" },
                new Team { Id = Guid.NewGuid(), Name = "Team B" },
                new Team { Id = Guid.NewGuid(), Name = "Team C" }
            };

            // Act
            var fixtureGenerator = new FixtureGenerator();
            var fixtures = fixtureGenerator.GenerateDoubleRoundRobinFixtures(league, teams, new DateTime(2014, 10, 4), 7);

            // Assert
            fixtures.ToList().ForEach(x => Trace.WriteLine(x));
            const int numberOfTeams = 3;
            const int expectedTotalFixtures = numberOfTeams * (numberOfTeams - 1);
            const int expectedFixturesPerTeam = (numberOfTeams - 1) * 2;
            Assert.AreEqual(expectedTotalFixtures, fixtures.Count);
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team A" || x.AwayTeam.Name == "Team A"));
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team B" || x.AwayTeam.Name == "Team B"));
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team C" || x.AwayTeam.Name == "Team C"));
        }

        [TestMethod]
        public void FixturesCorrectlyGeneratedFor4Teams()
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

            // Act
            var fixtureGenerator = new FixtureGenerator();
            var fixtures = fixtureGenerator.GenerateDoubleRoundRobinFixtures(league, teams, new DateTime(2014, 10, 4), 7);

            // Assert
            fixtures.ToList().ForEach(x => Trace.WriteLine(x));
            const int numberOfTeams = 4;
            const int expectedTotalFixtures = numberOfTeams * (numberOfTeams - 1);
            const int expectedFixturesPerTeam = (numberOfTeams - 1) * 2;
            Assert.AreEqual(expectedTotalFixtures, fixtures.Count);
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team A" || x.AwayTeam.Name == "Team A"));
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team B" || x.AwayTeam.Name == "Team B"));
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team C" || x.AwayTeam.Name == "Team C"));
            Assert.AreEqual(expectedFixturesPerTeam, fixtures.Count(x => x.HomeTeam.Name == "Team D" || x.AwayTeam.Name == "Team D"));
        }
    }
}
