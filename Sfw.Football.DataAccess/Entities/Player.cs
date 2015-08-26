using NPoco;

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
