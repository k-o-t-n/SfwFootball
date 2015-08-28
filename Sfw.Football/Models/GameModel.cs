using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Models
{
    public class GameModel
    {
        public IEnumerable<Player> Team1 { get; set; }
        public IEnumerable<Player> Team2 { get; set; }
        public int WinningTeam { get; set; }
        public DateTime Date { get; set; }

        private string _seperator = Environment.NewLine;

        public string Team1Display
        {
            get { return string.Join(_seperator, Team1.Select(p => p.Name)); }
        }

        public string Team2Display
        {
            get { return string.Join(_seperator, Team2.Select(p => p.Name)); }
        }

        public string WinningTeamDisplay
        {
            get { return string.Format("Team {0}", WinningTeam); }
        }

        public string DateDisplay
        {
            get { return Date.ToShortDateString(); }
}
    }
}