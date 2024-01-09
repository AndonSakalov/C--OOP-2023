using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private int numberOfPlayers;
        private string name;
        private double rating;
        private const string InvalidNameException = "A name should not be empty.";
        private const string MissingPlayerException = "Player {0} is not in {1} team."
;
        private List<Player> players;
        public Team(string name)
        {
            players = new List<Player>();
            Name = name;
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value == " ")
                {
                    throw new ArgumentException(InvalidNameException);
                }

                name = value;
            }
        }

        public double Rating => CalculateRating();
        private double CalculateRating()
        {
            double sum = 0;
            foreach (var player in players)
            {
                sum += player.SkillLevel;
            }
            if (players.Count == 0)
            {
                return 0;
            }

            return sum / players.Count;
        }
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            if (players.Any(p => p.Name == name))
            {
                Player foundPlayer = players.Find(p => p.Name == name);
                players.Remove(foundPlayer);
            }

            else
            {
                throw new ArgumentException(string.Format(MissingPlayerException, name, Name));
            }
        }
    }
}
