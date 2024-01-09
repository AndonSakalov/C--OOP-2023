using _04.WildFarm.Factories.FoodFactory.Interfaces;
using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories.FoodFactory
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string[] foodInfo)
        {
            switch (foodInfo[0])
            {
                case "Vegetable":
                    return new Vegetable(int.Parse(foodInfo[1]));
                case "Fruit":
                    return new Fruit(int.Parse(foodInfo[1]));
                case "Meat":
                    return new Meat(int.Parse(foodInfo[1]));
                case "Seeds":
                    return new Seeds(int.Parse(foodInfo[1]));
                default:
                    throw new ArgumentException("Invalid food type"); //Possible problem here
            }

        }
    }
}
