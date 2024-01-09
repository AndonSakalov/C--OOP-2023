using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;
        private Dictionary<string, double> flourTypeModifier;
        private Dictionary<string, double> bakingTechniqueModifier;
        private const string InvalidDoughMessage = "Invalid type of dough.";
        public Dough(string flourType, string bakingTechnique, double grams)
        {
            flourTypeModifier = new Dictionary<string, double>
            {
               { "white", 1.5 },
               { "wholegrain", 1.0 }
            };

            bakingTechniqueModifier = new Dictionary<string, double>
            {
               { "crispy", 0.9 },
               { "chewy", 1.1 },
               { "homemade", 1.0 }
            };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }
        public double Grams
        {
            get
            {
                return grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }
        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (!flourTypeModifier.ContainsKey(value.ToLower()))
                {
                    throw new Exception(InvalidDoughMessage);
                }

                flourType = value.ToLower();
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (!bakingTechniqueModifier.ContainsKey(value.ToLower()))
                {
                    throw new Exception(InvalidDoughMessage);
                }

                bakingTechnique = value.ToLower();
            }

        }

        public double Calories => CalculateCalories();

        private double CalculateCalories() => (2 * Grams) * flourTypeModifier[FlourType] * bakingTechniqueModifier[BakingTechnique];
    }
}
