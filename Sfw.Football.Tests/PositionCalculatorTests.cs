using Sfw.Football.DataAccess.Entities;
using Sfw.Football.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Sfw.Football.Tests
{
    public class PositionCalculatorTests
    {
        private Player player1;
        private Player player2;
        private Player player3;
        private Player player4;
        private IOrderedEnumerable<Player> orderedPlayers;
        private readonly PlayerPositionCalculator positionCalculator;

        public PositionCalculatorTests()
        {
            positionCalculator = new PlayerPositionCalculator();

            player1 = new Player()
            {
                Id = 1,
                Name = "player1",
                Points = 3,
                GamesPlayed = 3
            };

            player2 = new Player()
            {
                Id = 2,
                Name = "player2",
                Points = 3,
                GamesPlayed = 3
            };

            player3 = new Player()
            {
                Id = 3,
                Name = "player3",
                Points = 3,
                GamesPlayed = 6
            };

            player4 = new Player()
            {
                Id = 4,
                Name = "player4",
                Points = 3,
                GamesPlayed = 6
            };

            orderedPlayers = new List<Player>() { player1, player2, player3, player4 }
                .OrderBy(p => p.Name)
                .OrderByDescending(p=>p.PointsPerGame)
                .OrderByDescending(p=>p.Points);
        }

        [Fact]
        public void PlayerInFirstPosition_HasPosition_1()
        {
            var result = positionCalculator.ComputeDisplayedPosition(orderedPlayers, player1);

            result.Should().Be("1");
        }

        [Fact]
        public void TiedPlayer_ShouldHave_SamePositionAsPreviousPlayer_WithEquals()
        {
            var result1 = positionCalculator.ComputeDisplayedPosition(orderedPlayers, player2);
            var result2 = positionCalculator.ComputeDisplayedPosition(orderedPlayers, player4);

            result1.Should().Be("= 1");
            result2.Should().Be("= 3");
        }

        [Fact]
        public void Player_AfterTiedPlayer_ShouldHaveNormalPosition()
        {
            var result = positionCalculator.ComputeDisplayedPosition(orderedPlayers, player3);

            result.Should().Be("3");
        }
    }
}
