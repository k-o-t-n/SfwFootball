using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.Helpers;
using Sfw.Football.Generators;

namespace Sfw.Football.ModelBuilders
{
    public class TeamDisplayModelBuilder : ITeamDisplayModelBuilder
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamGenerator _teamGenerator;
        private readonly ITeamNameGenerator _teamNameGenerator;

        public TeamDisplayModelBuilder(IPlayerRepository playerRepository, ITeamGenerator teamGenerator, ITeamNameGenerator teamNameGenerator)
        {
            _playerRepository = playerRepository;
            _teamGenerator = teamGenerator;
            _teamNameGenerator = teamNameGenerator;
        }

        public TeamDisplayModel BuildModel(IEnumerable<int> selectedIds)
        {
            var teamPlayers = _playerRepository.GetByIds(selectedIds).ToList();
            var teams = _teamGenerator.GenerateTeams(teamPlayers);
            var teamNames = _teamNameGenerator.GenerateTeamNames();

            return new TeamDisplayModel()
            {
                Team1 = teams.Item1,
                Team2 = teams.Item2,
                Team1Name = teamNames.Item1,
                Team2Name = teamNames.Item2
            };
        }
    }
}