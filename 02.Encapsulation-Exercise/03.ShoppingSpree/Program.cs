using ShoppingSpree.Models;
using System.Globalization;
using System.Xml.Linq;

List<Person> people = new List<Person>();
List<Product> products = new List<Product>();

string[] peopleInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

try
{
    foreach (string current in peopleInput)
    {
        string[] nameMoney = current.Split('='); //sss
        Person person = new(nameMoney[0], decimal.Parse(nameMoney[1]));
        people.Add(person);
    }

    foreach (string current in productInput)
    {
        string[] nameCost = current.Split('=');//sss
        Product product = new(nameCost[0], decimal.Parse(nameCost[1]));
        products.Add(product);
    }
}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
    return;
}

string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split();
    Person foundPerson = people.Find(p => p.Name == tokens[0]);
    Product foundProduct = products.Find(p => p.Name == tokens[1]);

    if (foundPerson.Money >= foundProduct.Price)
    {
        foundPerson.AddProduct(foundProduct);
        Console.WriteLine($"{foundPerson.Name} bought {foundProduct.Name}");
    }
    else
    {
        Console.WriteLine($"{foundPerson.Name} can't afford {foundProduct.Name}");
    }
}

foreach (Person person in people)
{
    Console.WriteLine(person);
}



