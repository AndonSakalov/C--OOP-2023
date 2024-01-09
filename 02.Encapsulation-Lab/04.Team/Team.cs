using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        private string name;
        public Team(string name)
        {
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
            this.name = name;
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get
            {
                return firstTeam.AsReadOnly();
            }
            
        }
        public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
                return;
            }
            reserveTeam.Add(person);
        }
    }
}
