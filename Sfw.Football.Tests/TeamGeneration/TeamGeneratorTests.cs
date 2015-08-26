using FakeItEasy;
using FluentAssertions;
using Sfw.Football.DataAccess.Entities;
using Sfw.Football.Helpers;
using Sfw.Football.TeamGeneration;
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
                selectedPlayers.Add(new Player() { Id = i, Name = "Name" + i, Points = 1 });
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
                selectedPlayers.Add(new Player() { Id = i, Name = "Name" + i, Points = 1 });
            }

            var result = teamGenerator.GenerateTeams(selectedPlayers);

            result.Item1.Count().Should().Be((numberOfPlayers+1) / 2);
            result.Item2.Count().Should().Be((numberOfPlayers-1) / 2);
        }

        [InlineData(1, 0, 0, -1)]
        [InlineData(5, 0, 0, -5)]
        [InlineData(1, 1, -1, -1)]
        [InlineData(5, 5, -5, -5)]
        [InlineData(2, 1, -1, -2)]
        [InlineData(10, 5, -5, -10)]
        [Theory]
        public void GenerateTeams_GivenFourPlayers_PerfectSolutionsExist_PerfectSolutionFound(int r1, int r2, int r3, int r4)
        {
            IShuffler shuffler = A.Fake<IShuffler>();
            TeamGenerator teamGenerator = new TeamGenerator(shuffler);

            Player player1 = new Player() { Id = 1, Name = "Name1", Points = r1 };
            Player player2 = new Player() { Id = 2, Name = "Name2", Points = r2 };
            Player player3 = new Player() { Id = 3, Name = "Name3", Points = r3 };
            Player player4 = new Player() { Id = 4, Name = "Name4", Points = r4 };

            List<Player> selectedPlayers = new List<Player> { player1, player2, player3, player4 };
            
            var result = teamGenerator.GenerateTeams(selectedPlayers);

            result.Item1.Sum(p => p.Points).Should().Be(0);
            result.Item2.Sum(p => p.Points).Should().Be(0);
        }

        [InlineData(1, 1, 2)]
        [InlineData(5, 5, 10)]
        [InlineData(-1, 3, 2)]
        [InlineData(2, 1, -1)]
        [Theory]
        public void GenerateTeams_GivenThreePlayers_PerfectSolutionsExist_PerfectSolutionFound(int r1, int r2, int r3)
        {
            IShuffler shuffler = A.Fake<IShuffler>();
            TeamGenerator teamGenerator = new TeamGenerator(shuffler);

            Player player1 = new Player() { Id = 1, Name = "Name1", Points = r1 };
            Player player2 = new Player() { Id = 2, Name = "Name2", Points = r2 };
            Player player3 = new Player() { Id = 3, Name = "Name3", Points = r3 };

            List<Player> selectedPlayers = new List<Player> { player1, player2, player3 };

            var result = teamGenerator.GenerateTeams(selectedPlayers);

            int expected = (r1 + r2 + r3) / 2;

            result.Item1.Sum(p => p.Points).Should().Be(expected);
            result.Item2.Sum(p => p.Points).Should().Be(expected);
        }
    }
}
