using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.Massive.Repositories;
using Sfw.Football.Helpers;
using Sfw.Football.Massive.Entities;

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
            var players = _playersRepository.All().ToList();
            _shuffler.Shuffle(players);
            return new TeamGenerationModel()
            {
                Team1 = players.Take(4),
                Team2 = players.Skip(4).Take(4)
            };
        }
    }
}