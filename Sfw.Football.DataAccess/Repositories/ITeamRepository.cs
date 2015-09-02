using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public interface ITeamRepository
    {
        IEnumerable<Player> GetAllPlayersByTeamId(int id);
    }
}
