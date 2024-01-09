

List<Card> deck = new List<Card>();

string[] cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < cards.Length; i++)
{
    string[] currentCard = cards[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        Card card = new Card(currentCard[0], currentCard[1]);
        deck.Add(card);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine(string.Join(" ", deck));


public class Card
{
    private string face;
    private string suit;
    private readonly ICollection<string> validFaces;
    private readonly ICollection<string> validSuits;

    public Card(string face, string suit)
    {
        validFaces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        validSuits = new HashSet<string> { "S", "H", "D", "C" };
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get
        {
            return face;
        }
        set
        {
            if (!validFaces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            face = value;
        }
    }
    public string Suit
    {
        get
        {
            return suit;
        }
        set
        {
            if (!validSuits.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            switch (value)
            {
                case "S":
                    suit = "\u2660";
                    break;
                case "H":
                    suit = "\u2665";
                    break;
                case "D":
                    suit = "\u2666";
                    break;
                case "C":
                    suit = "\u2663";
                    break;
            }
        }
    }
    public override string ToString()
    {
        return $"[{Face}{Suit}]";
    }
}

