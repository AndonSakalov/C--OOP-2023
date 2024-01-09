using _05.BirthdayCelebrations.Models;
using _05.BirthdayCelebrations.Models.Interfaces;


string command;
List<string> birthDates = new List<string>();
while ((command = Console.ReadLine()) != "End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    switch (tokens[0])
    {
        case "Citizen":
            ICitizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
            birthDates.Add(citizen.BirthDate);
            break;
        case "Robot":
            IRobot robot = new Robot(tokens[1], tokens[2]);
            break;
        case "Pet":
            IPet pet = new Pet(tokens[1], tokens[2]);
            birthDates.Add(pet.BirthDate);
            break;
    }
}

string invalidIdEnding = Console.ReadLine();
foreach (var birthDate in birthDates)
{
    if (birthDate.Substring(birthDate.Length - invalidIdEnding.Length) == invalidIdEnding)
    {
        Console.WriteLine(birthDate);
    }
}

