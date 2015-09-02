using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Generators
{
    public interface ITeamNameGenerator
    {
        Tuple<string, string> GenerateTeamNames();
    }
}