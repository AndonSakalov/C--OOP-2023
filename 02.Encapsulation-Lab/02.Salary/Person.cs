using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }
        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                percentage /= 2;
            }
            Salary *= 1 + percentage / 100;

        }
        public override string ToString() => $"{FirstName} {LastName} receives {Salary:F2} leva.";

    }
}
