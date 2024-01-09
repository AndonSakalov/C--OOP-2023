using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IEmployee> list = new();
            list.Add(new HR("Doni"));
            list.Add(new Manager("Marko", new List<string> { "sad", "asf" }));
            list.Add(new HR("Stefan"));
            IEmployee programmer = new Programmer("GoShow", new List<string> { "C#", "Java Script", "HTML", "CSS" });
            list.Add(programmer);
            DetailsPrinter dp = new DetailsPrinter(list);
            dp.PrintDetails();
        }
    }
}
