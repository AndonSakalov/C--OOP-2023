using P03.DetailPrinter;
using System;

namespace P03.Detail_Printer
{
    public class HR : Employee
    {
        public HR(string name) : base(name)
        {
        }

        public override void Print()
        {
            Console.WriteLine(this.Name);
        }
    }
}
