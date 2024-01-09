using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Tomcat : Cat
    {
        private const string TomCatGender = "Male";
        private const string Sound = "MEOW";
        public Tomcat(string name, int age) : base(name, age, TomCatGender)
        {
        }
        public override string ProduceSound() => Sound;
    }
}
