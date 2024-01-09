List<int> list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
int exceptionsCount = 0;

while (exceptionsCount < 3)
{
    string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        ProcessCommand(command);
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionsCount++;
    }
    catch (ArgumentException)
    {
        Console.WriteLine("The index does not exist!");
        exceptionsCount++;
    }
    catch (FormatException)
    {
        Console.WriteLine("The variable is not in the correct format!");
        exceptionsCount++;
    }
}
Console.WriteLine(string.Join(", ", list));

void ProcessCommand(string[] command)
{
    switch (command[0])
    {
        case "Replace":
            int indexToReplace = int.Parse(command[1]);
            int element = int.Parse(command[2]);
            list[indexToReplace] = element;
            break;
        case "Show":
            int indexToShow = int.Parse(command[1]);
            Console.WriteLine(list[indexToShow]);
            break;
        case "Print":
            int startIndex = int.Parse(command[1]);
            int endIndex = int.Parse(command[2]);
            Console.WriteLine(string.Join(", ", list.GetRange(startIndex, endIndex)));
            break;
        default:
            break;
    }
}