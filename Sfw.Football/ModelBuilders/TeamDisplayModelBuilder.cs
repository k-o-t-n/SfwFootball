using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.Helpers;

namespace Sfw.Football.ModelBuilders
{
    public class TeamDisplayModelBuilder : ITeamDisplayModelBuilder
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IShuffler _shuffler;

        public TeamDisplayModelBuilder(IPlayerRepository playerRepository, IShuffler shuffler)
        {
            _playerRepository = playerRepository;
            _shuffler = shuffler;
        }

        public TeamDisplayModel BuildModel(IEnumerable<int> selectedIds)
        {
            var teamPlayers = _playerRepository.GetByIds(selectedIds).ToList();
            int halfCount = (int)Math.Ceiling((decimal)teamPlayers.Count / 2);
            _shuffler.Shuffle(teamPlayers);
            return new TeamDisplayModel()
            {
                Team1 = teamPlayers.Take(halfCount),
                Team2 = teamPlayers.Skip(halfCount).Take(teamPlayers.Count - halfCount)
            };
        }
    }
}