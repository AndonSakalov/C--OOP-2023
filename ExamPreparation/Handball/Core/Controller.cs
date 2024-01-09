using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            this.players = new PlayerRepository();
            this.teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            ITeam team = new Team(name);
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, "TeamRepository");
            }

            teams.AddModel(team);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, "TeamRepository");
        }

        public string NewPlayer(string typeName, string name)
        {
            IPlayer player = null;
            if (players.ExistsModel(name))
            {
                player = players.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, "PlayerRepository", player.GetType().Name);
            }

            switch (typeName)
            {
                case "Goalkeeper":
                    player = new Goalkeeper(name);
                    players.AddModel(player);
                    break;
                case "CenterBack":
                    player = new CenterBack(name);
                    players.AddModel(player);
                    break;
                case "ForwardWing":
                    player = new ForwardWing(name);
                    players.AddModel(player);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, "PlayerRepository"); //hmm
            }

            if (!teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, "TeamRepository");
            }

            IPlayer player = players.GetModel(playerName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }
            ITeam team = teams.GetModel(teamName);

            team.SignContract(player);
            player.JoinTeam(team.Name);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }
            else if (secondTeam.OverallRating > firstTeam.OverallRating)
            {
                secondTeam.Win();
                firstTeam.Lose();

                return string.Format(OutputMessages.GameHasWinner, secondTeam.Name, firstTeam.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            ITeam team = teams.GetModel(teamName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            List<IPlayer> sortedList = team.Players.OrderByDescending(p => p.Rating) //hmm
                                                       .ThenBy(p => p.Name).ToList();
            foreach (var player in sortedList)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new();
            sb.AppendLine($"***League Standings***");
            List<ITeam> sortedList = teams.Models.OrderByDescending(t => t.PointsEarned)
                                                  .ThenByDescending(t => t.OverallRating)
                                                  .ThenBy(t => t.Name).ToList();

            foreach (var team in sortedList)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
