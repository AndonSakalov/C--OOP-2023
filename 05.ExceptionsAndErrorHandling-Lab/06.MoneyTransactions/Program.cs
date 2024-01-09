string[] bankAccountInfo = Console.ReadLine().Split(new char[] { '-', ',' });
Dictionary<int, double> accountBalance = new Dictionary<int, double>();
for (int i = 0; i < bankAccountInfo.Length - 1; i += 2)
{
    accountBalance[int.Parse(bankAccountInfo[i])] = double.Parse(bankAccountInfo[i + 1]);
}

string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        ProcessCommand(tokens);
        Console.WriteLine($"Account {tokens[1]} has new balance: {accountBalance[int.Parse(tokens[1])]:F2}");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }

}

void ProcessCommand(string[] tokens)
{
    switch (tokens[0])
    {
        case "Deposit":
            int accNum = int.Parse(tokens[1]);
            double sumToDeposit = double.Parse(tokens[2]);
            if (accountBalance.Any(kvp => kvp.Key == accNum))
            {
                accountBalance[accNum] += sumToDeposit;
            }
            else
            {
                throw new ArgumentException("Invalid account!");
            }
            break;
        case "Withdraw":
            int accNum2 = int.Parse(tokens[1]);
            double sumToWithdraw = double.Parse(tokens[2]);
            if (accountBalance.Any(kvp => kvp.Key == accNum2))
            {
                if (accountBalance[accNum2] < sumToWithdraw)
                {
                    throw new ArgumentException("Insufficient balance!");
                }

                accountBalance[accNum2] -= sumToWithdraw;
            }
            else
            {
                throw new ArgumentException("Invalid account!");
            }
            break;
        default:
            throw new ArgumentException("Invalid command!");
    }
}