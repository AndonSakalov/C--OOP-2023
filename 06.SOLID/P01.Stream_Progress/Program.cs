using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            StreamProgressInfo z = new StreamProgressInfo(new Music("Maroon 5", "Without you!", 3, 50));
            Console.WriteLine(z.CalculateCurrentPercent());
        }
    }
}
