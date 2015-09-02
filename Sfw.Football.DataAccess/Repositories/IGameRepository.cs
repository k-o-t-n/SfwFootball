using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public interface IGameRepository
    {
        Game GetGameById(int id);
        IEnumerable<Game> GetAllGames();
    }
}
