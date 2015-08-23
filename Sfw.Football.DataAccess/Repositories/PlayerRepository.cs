using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;
using NPoco.Expressions;

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
