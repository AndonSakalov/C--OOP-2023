using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private Dictionary<string, double> typeModifier;
        private double grams;
        private string type;
        private const string InvalidTypeException = "Cannot place {0} on top of your pizza.";
        private const string InvalidGramsException = "{0} weight should be in the range [1..50].";


        public Topping(string type, double grams)
        {
            typeModifier = new Dictionary<string, double>
            {
                { "meat", 1.2 },
                { "veggies", 0.8 },
                { "cheese", 1.1 } ,
                { "sauce", 0.9 }
            };

            Type = type;
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
                if (value < 1 || value > 50)
                {
                    throw new Exception(string.Format(InvalidGramsException, Type));
                }
                grams = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                if (!typeModifier.ContainsKey(value.ToLower()))
                {
                    throw new Exception(string.Format(InvalidTypeException, value));
                }

                type = value;
            }
        }
        public double Calories => CalculateCaloriesPerGram();
        
        private double CalculateCaloriesPerGram() => 2 * typeModifier[Type.ToLower()] * Grams;
    }
}
