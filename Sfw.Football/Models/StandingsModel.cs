using Sfw.Football.DataAccess.Entities;
using Sfw.Football.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Models
{
    public class StandingsModel
    {
        public List<Tuple<string, Player>> OrderedStandings { get; set; }
    }
}