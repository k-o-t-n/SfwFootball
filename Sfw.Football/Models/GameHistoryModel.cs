using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Models
{
    public class GameHistoryModel
    {
        public IEnumerable<GameModel> Games { get; set; }
    }
}