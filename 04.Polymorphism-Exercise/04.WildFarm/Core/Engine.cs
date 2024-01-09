using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Factories.AnimalFactory.Interfaces;
using _04.WildFarm.Factories.FoodFactory.Interfaces;
using _04.WildFarm.IO.Interfaces;
using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;


        public Engine(IWriter writer, IReader reader, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.writer = writer;
            this.reader = reader;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }

        public void Run()
        {
            List<IAnimal> animals = new List<IAnimal>();
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] animalInput = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInput = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    IAnimal animal = animalFactory.CreateAnimal(animalInput);
                    IFood food = foodFactory.CreateFood(foodInput);
                    animals.Add(animal);

                    writer.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}


