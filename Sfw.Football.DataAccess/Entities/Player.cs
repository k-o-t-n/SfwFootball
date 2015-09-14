using NPoco;

namespace Sfw.Football.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }

        [Ignore]
        public int Points { get; set; }

        [Ignore]
        public int GamesPlayed { get; set; }

        [Ignore]
        public double PointsPerGame
        {
            get { return  GamesPlayed == 0 ? 0 : (double) Points / GamesPlayed; }
        }
    }
}
