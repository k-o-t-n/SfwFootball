using Sfw.Football.Massive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.Massive.Repositories
{
    public class PlayersRepository : IPlayersRepository
    {
        public IEnumerable<dynamic> All()
        {
            var table = new Players();
            return table.All();
        }
    }
}
