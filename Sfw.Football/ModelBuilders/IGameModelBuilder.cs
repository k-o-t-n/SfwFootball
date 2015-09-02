using Sfw.Football.DataAccess.Entities;
using Sfw.Football.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.ModelBuilders
{
    public interface IGameModelBuilder
    {
        GameModel BuildModel(Game game);
    }
}
