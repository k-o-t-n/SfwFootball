using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sfw.Football.DataAccess.Entities;
using NPoco;

namespace Sfw.Football.DataAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly Database db = new Database("defaultConnection");

        public IEnumerable<Player> GetAllPlayersByTeamId(int id)
        {
            var teamPlayers = db.FetchWhere<Team>(t => t.Id == id);

            return db.FetchWhere<Player>(p => teamPlayers.Select(tp => tp.PlayerId).Contains(p.Id));
        }
    }
}
