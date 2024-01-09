using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> productsBag;
        private const string MoneyException = "Money cannot be negative";
        private const string NameException = "Name cannot be empty";
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            productsBag = new List<Product>();
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
                    throw new Exception(NameException);
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception(MoneyException);
                }
                money = value;
            }
        }
        public IReadOnlyCollection<Product> ProductsBag => productsBag;

        public void AddProduct(Product product)
        {
            productsBag.Add(product);
            Money -= product.Price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (productsBag.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            for (int i = 0; i < productsBag.Count; i++)
            {
                if (i == productsBag.Count - 1)
                {
                    sb.Append(productsBag[i].Name);
                }
                else
                {
                    sb.Append(productsBag[i].Name + ", ");
                }
            }

            return $"{Name} - {sb}";
        }
    }
}
