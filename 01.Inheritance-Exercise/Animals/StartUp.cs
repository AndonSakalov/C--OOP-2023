using System;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string[] inputInfoTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                try
                {
                    switch (input)
                    {
                        case "Dog":
                            Dog dog = new(inputInfoTokens[0], int.Parse(inputInfoTokens[1]), inputInfoTokens[2]);
                            Console.WriteLine(input);
                            Console.WriteLine(dog);
                            break;
                        case "Cat":
                            Cat cat = new(inputInfoTokens[0], int.Parse(inputInfoTokens[1]), inputInfoTokens[2]);
                            Console.WriteLine(input);
                            Console.WriteLine(cat);
                            break;
                        case "Frog":
                            Frog frog = new(inputInfoTokens[0], int.Parse(inputInfoTokens[1]), inputInfoTokens[2]);
                            Console.WriteLine(input);
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new(inputInfoTokens[0], int.Parse(inputInfoTokens[1]));
                            Console.WriteLine(input);
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(inputInfoTokens[0], int.Parse(inputInfoTokens[1]));
                            Console.WriteLine(input);
                            Console.WriteLine(tomcat);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
