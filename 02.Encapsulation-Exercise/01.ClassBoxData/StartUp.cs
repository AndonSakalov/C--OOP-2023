using _01.ClassBoxData.Models;

double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());

try
{
    Box box = new(length, width, height);
    Console.WriteLine(box);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}