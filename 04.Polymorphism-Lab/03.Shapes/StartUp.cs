using Shapes.Models;

namespace Shapes;
public class StartUp
{
    static void Main()
    {
        Shape shape = new Rectangle(10, 10);
        Console.WriteLine(shape.Draw());

    }
}