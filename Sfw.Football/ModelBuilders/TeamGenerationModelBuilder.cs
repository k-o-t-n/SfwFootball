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
        private readonly IPlayerRepository _playerRepository;
        private readonly IShuffler _shuffler;

        public TeamGenerationModelBuilder(IPlayerRepository playerRepository, IShuffler shuffler)
        {
            _playerRepository = playerRepository;
            _shuffler = shuffler;
        }

        public TeamGenerationModel BuildModel()
        {
            var players = _playerRepository.GetAll().ToList().OrderBy(p => p.Name);
            return new TeamGenerationModel()
            {
                AllPlayers = players
            };
        }
    }
}