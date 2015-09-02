using System.Collections.Generic;
using NPoco;
using NPoco.Expressions;
using Sfw.Football.DataAccess.Entities;

namespace Sfw.Football.DataAccess.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Database db = new Database("defaultConnection");
        public IEnumerable<Player> GetAll()
        {
            return db.Fetch<Player>();
        }

        public IEnumerable<Player> GetByIds(IEnumerable<int> ids)
        {
            return db.FetchWhere<Player>(p => p.Id.In(ids));
        }
    }
}
