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
        private readonly IPlayerRepository _playersRepository;
        private readonly IShuffler _shuffler;

        public TeamGenerationModelBuilder(IPlayerRepository playersRepository, IShuffler shuffler)
        {
            _playersRepository = playersRepository;
            _shuffler = shuffler;
        }

        public TeamGenerationModel BuildModelWithNoTeams()
        {
            var players = _playersRepository.GetAll().ToList().OrderBy(p => p.Name);
            return new TeamGenerationModel()
            {
                AllPlayers = players
            };
        }

        public TeamGenerationModel BuildModelWithTeams(IEnumerable<int> selectedIds)
        {
            var allPlayers = _playersRepository.GetAll().ToList().OrderBy(p=>p.Name);
            var teamPlayers = allPlayers.Where(p => selectedIds.Contains(p.Id)).ToList();
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