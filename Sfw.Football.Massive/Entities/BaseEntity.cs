using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.Massive.Entities
{
    public class BaseEntity : DynamicModel
    {
        public BaseEntity() : base("DefaultConnection")
        {
            PrimaryKeyField = "Id";
        }
    }
}
