using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        private int age;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            this.age = age;
            Gender = gender;
        }
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                age = value;
            }
        }
        public string Gender { get; set; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
        }

    }
}
