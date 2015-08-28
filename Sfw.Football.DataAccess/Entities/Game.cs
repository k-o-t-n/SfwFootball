using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int WinningTeamId { get; set; }
        public DateTime Date { get; set; }
    }
}
