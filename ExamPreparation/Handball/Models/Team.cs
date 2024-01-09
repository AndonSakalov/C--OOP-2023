using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private string name;
        private List<IPlayer> players;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }

                name = value;
            }
        }
        public int PointsEarned { get; private set; }
        public double OverallRating
        {
            get
            {
                if (Players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(players.Average(p => p.Rating), 2);
            }
        }


        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Draw()
        {
            PointsEarned++;
            IPlayer goalKeeper = players.FirstOrDefault(p => p is Goalkeeper);
            if (goalKeeper != null)
            {
                goalKeeper.IncreaseRating();
            }
        }

        public void Lose()
        {
            foreach (IPlayer player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (IPlayer player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            if (players.Count == 0)
            {
                sb.AppendLine($"--Players: none");
            }
            else
            {
                sb.AppendLine("--Players: " + string.Join(", ", players.Select(p => p.Name)));
            }

            return sb.ToString().Trim();
        }
    }
}
