using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _05.FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private const int StatsMinValue = 0;
        private const int StatsMaxValue = 100;
        private const string OutOfStatRangeExeption = "{0} should be between 0 and 100.";
        private const string InvalidNameException = "A name should not be empty.";
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
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
        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                if (CheckStats(value))
                {
                    throw new ArgumentException(string.Format(OutOfStatRangeExeption, nameof(Endurance)));
                }

                endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (CheckStats(value))
                {
                    throw new ArgumentException(string.Format(OutOfStatRangeExeption, nameof(Sprint)));
                }

                sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                if (CheckStats(value))
                {
                    throw new ArgumentException(string.Format(OutOfStatRangeExeption, nameof(Dribble)));
                }

                dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                if (CheckStats(value))
                {
                    throw new ArgumentException(string.Format(OutOfStatRangeExeption, nameof(Passing)));
                }

                passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                if (CheckStats(value))
                {
                    throw new ArgumentException(string.Format(OutOfStatRangeExeption, nameof(Shooting)));
                }

                shooting = value;
            }
        }

        public double SkillLevel => CalculateSkillLevel();
        private bool CheckStats(int stat)
        {
            return stat < StatsMinValue || stat > StatsMaxValue;
        }

        private double CalculateSkillLevel() => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;
    }
}
