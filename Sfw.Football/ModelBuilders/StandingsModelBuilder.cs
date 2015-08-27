using Sfw.Football.DataAccess.Entities;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.Helpers;
using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.ModelBuilders
{
    public class StandingsModelBuilder : IStandingsModelBuilder
    {
        private readonly IPlayerRepository _playerRepository;
        private IPlayerPositionCalculator _playerPositionCalculator;

        public StandingsModelBuilder(IPlayerRepository playerRepository, IPlayerPositionCalculator playerPositionCalculator)
        {
            _playerRepository = playerRepository;
            _playerPositionCalculator = playerPositionCalculator;
        }

        public StandingsModel BuildModel()
        {
            var orderedPlayers = _playerRepository
                .GetAll()
                .Where(p => p.GamesPlayed != 0)
                .OrderBy(p => p.Name)
                .OrderByDescending(p => p.PointsPerGame)
                .OrderByDescending(p => p.Points);

            List<Tuple<string, Player>> orderedStandings = new List<Tuple<string, Player>>();

            foreach (var player in orderedPlayers)
            {
                orderedStandings.Add(new Tuple<string, Player>(
                    _playerPositionCalculator.ComputeDisplayedPosition(orderedPlayers, player),
                    player));
            }

            return new StandingsModel()
            {
                OrderedStandings = orderedStandings
            };
        }
    }
}