



List<int> numbers = new List<int>();
while (numbers.Count < 10)
{
    try
    {
        int currentNumber = int.Parse(Console.ReadLine());
        if (currentNumber <= 1 || currentNumber >= 100)
        {
            throw new ArgumentException($"Your number is not in range {currentNumber} - 100!");
        }

        numbers.Add(currentNumber);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FormatException fex)
    {
        Console.WriteLine("Invalid Number!");
    }
}
Console.WriteLine(string.Join(", ", numbers));
