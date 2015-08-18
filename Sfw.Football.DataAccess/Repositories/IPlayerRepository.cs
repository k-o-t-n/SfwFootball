using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Repositories
{
    public interface IPlayerRepository
    {
        IEnumerable<Player> GetAll();
        IEnumerable<Player> GetByIds(IEnumerable<int> ids);
    }
}
