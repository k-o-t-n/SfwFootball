using FakeItEasy;
using FluentAssertions;
using Sfw.Football.DataAccess.Entities;
using Sfw.Football.Helpers;
using Sfw.Football.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Sfw.Football.Tests.TeamGeneration
{
    public class TeamGeneratorTests
    {
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(14)]
        [InlineData(16)]
        [InlineData(18)]
        [InlineData(20)]
        [Theory]
        public void GenerateTeams_GivenEvenPlayers_EvenSplitReturned(int numberOfPlayers)
        {
            IShuffler shuffler = A.Fake<IShuffler>();
            TeamGenerator teamGenerator = new TeamGenerator(shuffler);

            List<Player> selectedPlayers = new List<Player>();

            for (int i = 1; i<= numberOfPlayers; i++)
            {
                selectedPlayers.Add(new Player() { Id = i, Name = "Name" + i, Points = 1, GamesPlayed = 1 });
            }

            var result = teamGenerator.GenerateTeams(selectedPlayers);

            result.Item1.Count().Should().Be(numberOfPlayers / 2);
            result.Item2.Count().Should().Be(numberOfPlayers / 2);
        }

        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        [InlineData(11)]
        [InlineData(13)]
        [InlineData(15)]
        [InlineData(17)]
        [InlineData(19)]
        [Theory]
        public void GenerateTeams_GivenOddPlayers_EvenSplitReturned_Team1WithMorePlayers(int numberOfPlayers)
        {
            IShuffler shuffler = A.Fake<IShuffler>();
            TeamGenerator teamGenerator = new TeamGenerator(shuffler);

            List<Player> selectedPlayers = new List<Player>();

            for (int i = 1; i <= numberOfPlayers; i++)
            {
                selectedPlayers.Add(new Player() { Id = i, Name = "Name" + i, Points = 1, GamesPlayed = 1 });
            }

            var result = teamGenerator.GenerateTeams(selectedPlayers);

            result.Item1.Count().Should().Be((numberOfPlayers+1) / 2);
            result.Item2.Count().Should().Be((numberOfPlayers-1) / 2);
        }

        [InlineData(2, 2, 1, 2, 1, 2, 0, 2)]
        //PPG 1, 0.5, 0.5, 0
        [Theory]
        public void GenerateTeams_GivenFourPlayers_PerfectSolutionsExist_PerfectSolutionFound(
            int p1, int g1, 
            int p2, int g2,
            int p3, int g3,
            int p4, int g4)
        {
            IShuffler shuffler = A.Fake<IShuffler>();
            TeamGenerator teamGenerator = new TeamGenerator(shuffler);

            Player player1 = new Player() { Id = 1, Name = "Name1", Points = p1, GamesPlayed = g1 };
            Player player2 = new Player() { Id = 2, Name = "Name2", Points = p2, GamesPlayed = g2 };
            Player player3 = new Player() { Id = 3, Name = "Name3", Points = p3, GamesPlayed = g3 };
            Player player4 = new Player() { Id = 4, Name = "Name4", Points = p4, GamesPlayed = g4 };

            List<Player> selectedPlayers = new List<Player> { player1, player2, player3, player4 };
            
            var result = teamGenerator.GenerateTeams(selectedPlayers);

            result.Item1.Sum(p => p.PointsPerGame).Should().Be(1);
            result.Item2.Sum(p => p.PointsPerGame).Should().Be(1);
        }

        [InlineData(2, 2, 1, 2, 1, 2)]
        //PPG 1, 0.5, 0.5
        [Theory]
        public void GenerateTeams_GivenThreePlayers_PerfectSolutionsExist_PerfectSolutionFound(
            int p1, int g1,
            int p2, int g2,
            int p3, int g3)
        {
            IShuffler shuffler = A.Fake<IShuffler>();
            TeamGenerator teamGenerator = new TeamGenerator(shuffler);

            Player player1 = new Player() { Id = 1, Name = "Name1", Points = p1, GamesPlayed = g1 };
            Player player2 = new Player() { Id = 2, Name = "Name2", Points = p2, GamesPlayed = g2 };
            Player player3 = new Player() { Id = 3, Name = "Name3", Points = p3, GamesPlayed = g3 };

            List<Player> selectedPlayers = new List<Player> { player1, player2, player3 };

            var result = teamGenerator.GenerateTeams(selectedPlayers);
            var r1 = (double)p1 / g1;
            var r2 = (double)p2 / g2;
            var r3 = (double)p3 / g3;
            double expected = (r1 + r2 + r3) / 2;

            result.Item1.Sum(p => p.PointsPerGame).Should().Be(expected);
            result.Item2.Sum(p => p.PointsPerGame).Should().Be(expected);
        }
    }
}
