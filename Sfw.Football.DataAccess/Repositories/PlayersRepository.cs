using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        private readonly PetaPoco.Database db = new PetaPoco.Database("defaultConnection");
        public IEnumerable<Player> GetAll()
        {
            return db.Query<Player>("SELECT * FROM Player");
        }

        public IEnumerable<Player> GetByIds(IEnumerable<int> ids)
        {
            var query = PetaPoco.Sql.Builder.Select("*").From("Player").Where("Id in (@Ids)", new { Ids = ids });
            return db.Query<Player>(query);
        }
    }
}
