using _05.FootballTeamGenerator.Models;

List<Team> teams = new();
string input;
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        switch (tokens[0])
        {
            case "Team":
                Team team = new(tokens[1]);
                teams.Add(team);
                break;
            case "Add":
                if (teams.Any(t => t.Name == tokens[1]))
                {
                    Team foundTeam = teams.Find(t => t.Name == tokens[1]);
                    Player player = new(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                    foundTeam.AddPlayer(player);
                }
                else
                {
                    throw new ArgumentException($"Team {tokens[1]} does not exist.");
                }
                break;
            case "Remove":
                Team foundTeamToRemoveIn = teams.Find(t => t.Name == tokens[1]);
                foundTeamToRemoveIn.RemovePlayer(tokens[2]);
                break;
            case "Rating":
                if (teams.Any(t => t.Name == tokens[1]))
                {
                    Team foundTeamForRating = teams.Find(t => t.Name == tokens[1]);
                    Console.WriteLine($"{foundTeamForRating.Name} - {foundTeamForRating.Rating:F0}");
                }
                else
                {
                    throw new ArgumentException($"Team {tokens[1]} does not exist.");
                }
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}