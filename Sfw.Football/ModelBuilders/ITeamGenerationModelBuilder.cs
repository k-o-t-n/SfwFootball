using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.ModelBuilders
{
    public interface ITeamGenerationModelBuilder
    {
        TeamGenerationModel BuildModelWithNoTeams();
        TeamGenerationModel BuildModelWithTeams(IEnumerable<int> selectedIds);
    }
}
