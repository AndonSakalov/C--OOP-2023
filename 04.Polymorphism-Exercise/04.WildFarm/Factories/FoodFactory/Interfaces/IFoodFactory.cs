using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories.FoodFactory.Interfaces
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] foodInfo);
    }
}
