using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sfw.Football.DataAccess.Entities;
using NPoco;

namespace Sfw.Football.DataAccess.Repositories
{
    public class GameRepository : IGameRepository
    {
        private Database db = new Database("defaultConnection");

        public IEnumerable<Game> GetAllGames()
        {
            return db.Fetch<Game>();
        }

        public Game GetGameById(int id)
        {
            return db.SingleById<Game>(id);
        }
    }
}
