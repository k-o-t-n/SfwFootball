using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Helpers
{
    public interface IShuffler
    {
        void Shuffle<T>(List<T> list);
    }
}