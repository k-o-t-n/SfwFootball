using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sfw.Football.Models;
using Sfw.Football.DataAccess.Repositories;

namespace Sfw.Football.ModelBuilders
{
    public class GameHistoryModelBuilder : IGameHistoryModelBuilder
    {
        private IGameModelBuilder _gameModelBuilder;
        private IGameRepository _gameRepository;

        public GameHistoryModelBuilder(IGameModelBuilder gameModelBuilder, IGameRepository gameRepository)
        {
            _gameModelBuilder = gameModelBuilder;
            _gameRepository = gameRepository;
        }

        public GameHistoryModel BuildModel()
        {
            var games = _gameRepository.GetAllGames();

            List<GameModel> result = new List<GameModel>();
            foreach (var game in games)
            {
                result.Add(_gameModelBuilder.BuildModel(game));
            }

            return new GameHistoryModel
            {
                Games = result
            };
        }
    }
}