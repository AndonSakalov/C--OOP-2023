using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    public abstract class Employee : IEmployee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public abstract void Print();
    }
}
