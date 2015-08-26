using Sfw.Football.DataAccess.Repositories;
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
		
		public StandingsModelBuilder(IPlayerRepository playerRepository)
		{
			_playerRepository = playerRepository;
		}
		
		public StandingsModel BuildModel()
		{
			var players = _playerRepository
                .GetAll()
                .Where(p => p.GamesPlayed != 0)
                .ToList()
                .OrderBy(p => p.Name)
                .OrderByDescending(p => p.PointsPerGame)
                .OrderByDescending(p => p.Points);
			return new StandingsModel()
			{
				AllPlayers = players	
			};
		}
	}
}