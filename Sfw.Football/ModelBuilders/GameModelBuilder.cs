using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.DataAccess.Repositories;
using Sfw.Football.DataAccess.Entities;

namespace Sfw.Football.ModelBuilders
{
    public class GameModelBuilder : IGameModelBuilder
    {
        private readonly ITeamRepository _teamRepository;

        public GameModelBuilder(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public GameModel BuildModel(Game game)
        {
            var team1 = _teamRepository.GetAllPlayersByTeamId(game.Team1Id);
            var team2 = _teamRepository.GetAllPlayersByTeamId(game.Team2Id);

            int winningTeam = game.WinningTeamId == game.Team1Id ? 1 : 2;

            return new GameModel
            { 
                Team1 = team1,
                Team2 = team2,
                WinningTeam = winningTeam,
                Date = game.Date
            };
        }
    }
}