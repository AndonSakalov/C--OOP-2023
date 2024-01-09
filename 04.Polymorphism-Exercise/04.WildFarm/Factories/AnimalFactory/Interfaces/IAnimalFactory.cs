using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories.AnimalFactory.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string[] animalInfo);
    }
}
