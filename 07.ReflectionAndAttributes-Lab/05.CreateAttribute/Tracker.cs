
using System.Reflection;

namespace AuthorProblem
{
    public class Tracker
    {
        public Tracker()
        {
        }

        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                AuthorAttribute[] authorAttributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();
                if (authorAttributes.Length > 0)
                {
                    foreach (AuthorAttribute authorAttribute in authorAttributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            }
        }
    }
}