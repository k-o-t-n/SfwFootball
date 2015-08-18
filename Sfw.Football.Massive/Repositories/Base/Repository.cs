using Sfw.Football.Massive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.Massive.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        public IEnumerable<dynamic> All()
        {
            var table = new T();
            return table.All();
        }
    }
}
