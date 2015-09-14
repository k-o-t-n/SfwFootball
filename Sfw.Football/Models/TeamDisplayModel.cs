using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Models
{
    public class TeamDisplayModel
    {
        public List<Player> Team1 { get; set; }
        public List<Player> Team2 { get; set; }
        public string Team1Name { get; set; }
        public string Team2Name { get; set; }
    }
}