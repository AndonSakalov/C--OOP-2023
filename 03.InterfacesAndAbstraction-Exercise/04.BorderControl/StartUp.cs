using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;

string command;
List<string> iDs = new List<string>();
while ((command = Console.ReadLine()) != "End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (tokens.Length == 3)
    {
        ICitizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
        iDs.Add(citizen.Id);
    }
    else if (tokens.Length == 2)
    {
        IRobot robot = new Robot(tokens[0], tokens[1]);
        iDs.Add(robot.Id);
    }
}

string invalidIdEnding = Console.ReadLine();
foreach (var iD in iDs)
{
    if (iD.Substring(iD.Length - invalidIdEnding.Length) == invalidIdEnding)
    {
        Console.WriteLine(iD);
    }
}
