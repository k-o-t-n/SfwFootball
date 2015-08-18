using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.Helpers;
using Sfw.Football.DataAccess.Entities;

namespace Sfw.Football.ModelBuilders
{
    public class TeamGenerationModelBuilder : ITeamGenerationModelBuilder
    {
        private readonly IPlayersRepository _playersRepository;
        private readonly IShuffler _shuffler;

        public TeamGenerationModelBuilder(IPlayersRepository playersRepository, IShuffler shuffler)
        {
            _playersRepository = playersRepository;
            _shuffler = shuffler;
        }

        public TeamGenerationModel BuildModel()
        {
            var players = _playersRepository.GetAll().ToList();
            return new TeamGenerationModel()
            {
                AllPlayers = players
            };
        }

        public TeamGenerationModel BuildModel(IEnumerable<int> selectedIds)
        {
            var allPlayers = _playersRepository.GetAll().ToList();
            var teamPlayers = _playersRepository.GetByIds(selectedIds).ToList();
            int halfCount = (int)Math.Ceiling((decimal)teamPlayers.Count / 2);
            _shuffler.Shuffle(teamPlayers);
            return new TeamGenerationModel()
            {
                AllPlayers = allPlayers,
                Team1 = teamPlayers.Take(halfCount),
                Team2 = teamPlayers.Skip(halfCount).Take(teamPlayers.Count - halfCount)
            };
        }
    }
}