using NPoco;
using NPoco.Expressions;
using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sfw.Football.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Database db = new Database("defaultConnection");
        private readonly ITeamRepository teamRepository;
        private readonly IGameRepository gameRepository;

        public PlayerRepository(ITeamRepository teamRepo, IGameRepository gameRepo)
        {
            this.teamRepository = teamRepo;
            this.gameRepository = gameRepo;
        }

        public IEnumerable<Player> GetAll()
        {
            var players = db.Fetch<Player>();

            FetchPlayersStats(players);

            return players;
        }

        public IEnumerable<Player> GetByIds(IEnumerable<int> ids)
        {
            var players = db.FetchWhere<Player>(p => p.Id.In(ids));

            FetchPlayersStats(players);

            return players;
        }

        private void FetchPlayersStats(IEnumerable<Player> players)
        {
            foreach (var player in players)
            {
                player.Points = FetchPlayerPoints(player.Id);
                player.GamesPlayed = FetchPlayerGamesPlayed(player.Id);
            }
        }

        private int FetchPlayerGamesPlayed(int id)
        {
            var teamsPlayedIn = teamRepository.GetAllTeamsFeaturingPlayer(id);

            return teamsPlayedIn.ToList().Count;
        }

        private int FetchPlayerPoints(int id)
        {
            var teamsPlayedIn = teamRepository.GetAllTeamsFeaturingPlayer(id);

            int numberOfGamesWon = 0;
            foreach (var team in teamsPlayedIn)
            {
                var gamesWon = gameRepository.GamesWonByTeam(team.Id);
                numberOfGamesWon += gamesWon.ToList().Count;
            }

            return numberOfGamesWon;
        }
    }
}
