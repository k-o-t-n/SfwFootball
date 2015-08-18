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
        public IEnumerable<Player> GetAll()
        {
            var db = new PetaPoco.Database("defaultConnection");

            return db.Query<Player>("SELECT * FROM Player");
        }
    }
}
