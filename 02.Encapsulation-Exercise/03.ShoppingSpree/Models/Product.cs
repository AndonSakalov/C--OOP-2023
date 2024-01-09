using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal price;
        private const string MoneyException = "Money cannot be negative";
        private const string NameException = "Name cannot be empty";
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
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
        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value < 0)
                {
                    throw new Exception(MoneyException);
                }
                price = value;
            }
        }
    }
}