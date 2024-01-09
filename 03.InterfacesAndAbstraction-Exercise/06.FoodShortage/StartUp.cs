using _06.FoodShortage.Models;
using _06.FoodShortage.Models.Interfaces;

int peopleCount = int.Parse(Console.ReadLine());
List<Rebel> rebels = new List<Rebel>();
List<Citizen> citizens = new List<Citizen>();

for (int i = 0; i < peopleCount; i++)
{
	string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
	if (tokens.Length == 3)
	{
		Rebel rebel = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
		rebels.Add(rebel);
	}
	else if (tokens.Length == 4)
	{
		Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
		citizens.Add(citizen);
	}
}

string input;
IBuyer buyer;
while ((input = Console.ReadLine()) != "End")
{
	
	if (rebels.Any(r => r.Name == input))
	{
		buyer = rebels.Find(r => r.Name == input);
        buyer.BuyFood();
	}
	else if (citizens.Any(c => c.Name == input))
	{
		buyer = citizens.Find(c => c.Name == input);
		buyer.BuyFood();
	}
}

int boughtFood = 0;
foreach (var rebel in rebels)
{
	boughtFood += rebel.Food;
}
foreach (var citizen in citizens)
{
	boughtFood += citizen.Food;
}

Console.WriteLine(boughtFood);