using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Sfw.Football.Generators
{
    public class TeamNameGenerator : ITeamNameGenerator
    {
        public Tuple<string, string> GenerateTeamNames()
        {
            List<string> animals = Constants.TeamNames.Animals;
            var random = new Random();
            int index1 = random.Next(animals.Count);
            int index2 = index1;
            while (index2 == index1)
            {
                index2 = random.Next(animals.Count);
            }
            string name1 = animals[index1];
            string name2 = animals[index2];
            return new Tuple<string, string>(name1, name2);
        }
    }
}