using PizzaCalories.Models;

try
{
    string[] pizzaInit = Console.ReadLine().Split();
    string[] doughInit = Console.ReadLine().Split();
    Dough dough = new(doughInit[1], doughInit[2], double.Parse(doughInit[3]));
    Pizza pizza = new(pizzaInit[1], dough);

    string input;
    while ((input = Console.ReadLine()) != "END")
    {
        string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

        Topping topping = new(tokens[1], double.Parse(tokens[2]));
        pizza.AddTopping(topping);
    }
    Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}



