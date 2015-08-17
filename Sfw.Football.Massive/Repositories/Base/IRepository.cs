using Sfw.Football.Massive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.Massive.Repositories.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<dynamic> All();
    }
}
