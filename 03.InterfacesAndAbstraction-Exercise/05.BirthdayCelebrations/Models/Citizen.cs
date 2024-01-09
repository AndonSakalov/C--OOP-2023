using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations.Models
{
    public class Citizen : ICitizen
    {
        public Citizen(string name, int age, string id, string dateTime)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = dateTime;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }
        public string Id { get; private set; }

        public string BirthDate { get; private set; }
    }
}
