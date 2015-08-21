using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.Helpers;
using Sfw.Football.TeamGeneration;

namespace Sfw.Football.ModelBuilders
{
    public class TeamDisplayModelBuilder : ITeamDisplayModelBuilder
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IShuffler _shuffler;
        private readonly ITeamGenerator _teamGenerator;

        public TeamDisplayModelBuilder(IPlayerRepository playerRepository, IShuffler shuffler, ITeamGenerator teamGenerator)
        {
            _playerRepository = playerRepository;
            _shuffler = shuffler;
            _teamGenerator = teamGenerator;
        }

        public TeamDisplayModel BuildModel(IEnumerable<int> selectedIds)
        {
            var teamPlayers = _playerRepository.GetByIds(selectedIds).ToList();
            var teams = _teamGenerator.GenerateTeams(teamPlayers);
            return new TeamDisplayModel()
            {
                Team1 = teams.Item1,
                Team2 = teams.Item2
            };
        }
    }
}