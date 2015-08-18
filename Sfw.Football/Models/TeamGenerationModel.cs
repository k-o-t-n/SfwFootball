using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Models
{
    public class TeamGenerationModel
    {
        public IEnumerable<Players> AllPlayers { get; set; }
        public IEnumerable<Players> Team1 { get; set; }
        public IEnumerable<Players> Team2 { get; set; }
    }
}