using _01.Vehicles.IO.Interfaces;

namespace _01.Vehicles.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
    }
}
