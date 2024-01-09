using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams;
        public TeamRepository()
        {
            teams = new List<ITeam>();
        }
        public IReadOnlyCollection<ITeam> Models => teams.AsReadOnly();

        public void AddModel(ITeam model)
        {
            teams.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return teams.Any(t => t.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return teams.FirstOrDefault(t => t.Name == name);
        }

        public bool RemoveModel(string name)
        {
            ITeam team = GetModel(name);
            return teams.Remove(team);
        }
    }
}
