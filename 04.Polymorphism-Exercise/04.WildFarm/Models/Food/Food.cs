using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Food
{
    public abstract class Food : IFood
    {
        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
