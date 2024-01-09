

using _03.Telephony.Models;
using _03.Telephony.Models.Interfaces;

public class StartUp
{
    static void Main()
    {
        string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        ICallable phone;
        for (int i = 0; i < phoneNumbers.Length; i++)
        {
            if (phoneNumbers[i].Any(n => !char.IsDigit(n)))
            {
                Console.WriteLine("Invalid number!");
                continue;
            }

            if (phoneNumbers[i].Length == 7)
            {
                phone = new StationaryPhone();
                phone.Call(phoneNumbers[i]);
            }

            else if (phoneNumbers[i].Length == 10)
            {
                phone = new Smartphone();
                phone.Call(phoneNumbers[i]);
            }
        }

        IBrowsable browsingPhone;
        for (int i = 0; i < urls.Length; i++)
        {
            if (urls[i].Any(n => char.IsNumber(n)))
            {
                Console.WriteLine("Invalid URL!");
                continue;
            }

            browsingPhone = new Smartphone();
            browsingPhone.Browse(urls[i]);
        }

    }
}