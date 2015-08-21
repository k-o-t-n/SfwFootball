using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Sfw.Football.DataAccess.Entities;
using Sfw.Football.ExtensionMethods;
using Sfw.Football.Helpers;

namespace Sfw.Football.TeamGeneration
{
    public class TeamGenerator : ITeamGenerator
    {
        private readonly IShuffler _shuffler;

        public TeamGenerator(IShuffler shuffler)
        {
            _shuffler = shuffler;
        }

        public Tuple<IEnumerable<Player>, IEnumerable<Player>> GenerateTeams(List<Player> selectedPlayers)
        {
            int halfCount = (int)Math.Ceiling((decimal)selectedPlayers.Count / 2);
            int totalSum = selectedPlayers.Sum(p => p.Rating);
            decimal target = decimal.Divide(totalSum, 2);

            List<IEnumerable<Player>> team1combinations = selectedPlayers.Combinations(halfCount).ToList();

            List<Tuple<IEnumerable<Player>, IEnumerable<Player>>> solutions = new List<Tuple<IEnumerable<Player>, IEnumerable<Player>>>();
            
            decimal bestDifferential = -1;
            foreach (var team1 in team1combinations.Select(p => p.ToList()))
            {
                var team1Temp = team1;
                int team1Score = team1Temp.Sum(p => p.Rating);
                var team2Temp = selectedPlayers.Except(team1Temp).ToList();
                int team2Score = team2Temp.Sum(p => p.Rating);
                decimal totalDifferential = Math.Abs(team1Score - target) + Math.Abs(team2Score - target);
                if (bestDifferential == -1 || totalDifferential < bestDifferential)
                {
                    // Everything found so far is not a solution, so wipe the list
                    solutions = new List<Tuple<IEnumerable<Player>, IEnumerable<Player>>>();
                    solutions.Add(new Tuple<IEnumerable<Player>, IEnumerable<Player>>(team1Temp, team2Temp));
                    bestDifferential = totalDifferential;
                }
            }
            _shuffler.Shuffle(solutions);
            return solutions.First();
        }
    }
}