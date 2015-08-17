using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sfw.Football.Helpers
{
    public class Shuffler : IShuffler
    {
        private readonly Random rng = new Random();

        public void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}