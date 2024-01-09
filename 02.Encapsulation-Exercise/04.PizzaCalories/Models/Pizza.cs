using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;
        private int toppingsCount;
        private const string InvalidNameException = "Pizza name should be between 1 and 15 symbols.";
        private const string InvalidToppingsCount = "Number of toppings should be in range [0..10].";

        public Pizza(string name, Dough dough)
        {
            toppings = new List<Topping>();
            Name = name;
            Dough = dough;
        }
        public Dough Dough
        {
            get
            {
                return dough;
            }
            set
            {
                dough = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new Exception(InvalidNameException);
                }

                name = value;
            }
        }
        public int ToppingsCount
        {
            get
            {
                return toppingsCount;
            }
            private set
            {
                if (toppings.Count > 10)
                {
                    throw new Exception(InvalidToppingsCount);
                }
                toppingsCount = toppings.Count;
            }
        }
        public double TotalCalories => CalculateTotalCalories();

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
            ToppingsCount++;
        }
        public double CalculateTotalCalories()
        {
            double calories = 0;
            calories += Dough.Calories;
            foreach (var topping in toppings)
            {
                calories += topping.Calories;
            }

            return calories;
        }
    }
}
