using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.DataAccess.Entities;

namespace Sfw.Football.Helpers
{
    public class PlayerPositionCalculator : IPlayerPositionCalculator
    {
        private List<Player> OrderedPlayers;

        public string ComputeDisplayedPosition(IOrderedEnumerable<Player> orderedPlayers, Player currentPlayer)
        {
            OrderedPlayers = orderedPlayers.ToList();

            var indexOfPlayer = OrderedPlayers.IndexOf(currentPlayer);

            if (indexOfPlayer == 0)
            {
                return GetPlayersPosition(currentPlayer).ToString();
            }

            var previousPlayer = OrderedPlayers.ElementAt(indexOfPlayer - 1);

            if (currentPlayer.Points == previousPlayer.Points && currentPlayer.PointsPerGame == previousPlayer.PointsPerGame)
            {
                return string.Format("= {0}", GetPlayersPosition(currentPlayer));
            }

            return GetPlayersPosition(currentPlayer).ToString();
        }

        private int GetPlayersPosition(Player player)
        {
            var indexOfPlayer = OrderedPlayers.IndexOf(player);
            if (indexOfPlayer == 0)
            {
                return 1;
            }

            if (indexOfPlayer == 1 
                && player.Points == OrderedPlayers.First().Points
                && player.PointsPerGame == OrderedPlayers.First().PointsPerGame)
            {
                return 1;
            }
            else if (indexOfPlayer == 1)
            {
                return 2;
            }

            var previousPlayer = OrderedPlayers.ElementAt(indexOfPlayer - 1);

            if (previousPlayer.Points == player.Points && previousPlayer.PointsPerGame == player.PointsPerGame)
            {
                return GetPlayersPosition(previousPlayer);
            }
            else
            {
                return GetPlayersPosition(previousPlayer) + 1;
            }
        }
    }
}