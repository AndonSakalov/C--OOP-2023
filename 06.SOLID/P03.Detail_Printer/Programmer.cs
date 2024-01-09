using P03.DetailPrinter;
using System;
using System.Collections.Generic;

namespace P03.Detail_Printer
{
    public class Programmer : Employee
    {
        public Programmer(string name, List<string> programmingLanguages) : base(name)
        {
            ProgrammingLanguages = programmingLanguages;
        }

        public List<string> ProgrammingLanguages { get; private set; }
        public override void Print()
        {
            Console.WriteLine(Name);
            foreach (var item in ProgrammingLanguages)
            {
                Console.WriteLine($"-> {item}");
            }
        }
    }
}
