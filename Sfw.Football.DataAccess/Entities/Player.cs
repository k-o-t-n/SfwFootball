using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public int GamesPlayed { get; set; }

        [Ignore]
        public double PointsPerGame
        {
            get { return  GamesPlayed == 0 ? 0 : (double) Points / GamesPlayed; }
        }
    }
}
