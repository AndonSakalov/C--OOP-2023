namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList list = new RandomList();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i.ToString());
            }

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
