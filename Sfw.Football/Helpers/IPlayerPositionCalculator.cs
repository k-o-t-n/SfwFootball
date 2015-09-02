using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.Helpers
{
    public interface IPlayerPositionCalculator
    {
        string ComputeDisplayedPosition(IOrderedEnumerable<Player> orderedPlayers, Player currentPlayer); 
    }
}
