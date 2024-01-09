using _06.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage.Models
{
    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string name, int age, string id, string dateTime)
        {
            Name = name;
            Age = age;
            Id = id;
            BirthDate = dateTime;
            Food = 0;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public string BirthDate { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
