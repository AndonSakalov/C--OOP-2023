using _04.WildFarm.Factories.AnimalFactory.Interfaces;
using _04.WildFarm.Models.Animals;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Factories.AnimalFactory
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalInfo)
        {
            switch (animalInfo[0])
            {
                case "Owl":
                    return new Owl(animalInfo[1], double.Parse(animalInfo[2]), int.Parse(animalInfo[3]));
                case "Hen":
                    return new Hen(animalInfo[1], double.Parse(animalInfo[2]), double.Parse(animalInfo[3]));
                case "Mouse":
                    return new Mouse(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                case "Dog":
                    return new Dog(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3]);
                case "Cat":
                    return new Cat(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                case "Tiger":
                    return new Tiger(animalInfo[1], double.Parse(animalInfo[2]), animalInfo[3], animalInfo[4]);
                default:
                    throw new ArgumentException("Invalid animal type");
            }
        }
    }
}
