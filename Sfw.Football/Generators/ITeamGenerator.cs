using Sfw.Football.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Generators
{
    public interface ITeamGenerator
    {
        Tuple<IEnumerable<Player>, IEnumerable<Player>> GenerateTeams(List<Player> selectedPlayers);
    }
}