string[] input = Console.ReadLine().Split().ToArray();
int sum = 0;
foreach (var item in input)
{
    try
    {
        TryParseObj(item);
    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{item}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{item}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
    }
}
Console.WriteLine($"The total sum of all integers is: {sum}");

void TryParseObj(string item)
{
    int number = int.Parse(item);
    sum += number;
}