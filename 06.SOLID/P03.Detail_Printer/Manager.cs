using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override void Print()
        {
            Console.WriteLine(this.Name);
            foreach (var document in this.Documents)
            {
                Console.WriteLine($"  {document}");
            }
        }
    }
}
