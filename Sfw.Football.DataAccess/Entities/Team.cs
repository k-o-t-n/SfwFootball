using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Entities
{
    [PrimaryKey("Id,PlayerId")]
    public class Team : BaseEntity
    {
        public int PlayerId { get; set; }
    }
}
