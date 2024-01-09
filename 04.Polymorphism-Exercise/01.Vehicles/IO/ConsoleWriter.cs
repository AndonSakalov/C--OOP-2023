using _01.Vehicles.IO.Interfaces;

namespace _01.Vehicles.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(object obj) => Console.WriteLine(obj);
    }
}
