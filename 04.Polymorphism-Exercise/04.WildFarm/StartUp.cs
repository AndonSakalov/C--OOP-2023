using _04.WildFarm.Core;
using _04.WildFarm.Core.Interfaces;
using _04.WildFarm.Factories.AnimalFactory;
using _04.WildFarm.Factories.AnimalFactory.Interfaces;
using _04.WildFarm.Factories.FoodFactory;
using _04.WildFarm.Factories.FoodFactory.Interfaces;
using _04.WildFarm.IO;
using _04.WildFarm.IO.Interfaces;


IWriter writer = new ConsoleWriter();
IReader reader = new ConsoleReader();
IAnimalFactory animalFactory = new AnimalFactory();
IFoodFactory foodFactory = new FoodFactory();
IEngine engine = new Engine(writer, reader, animalFactory, foodFactory);

engine.Run();


ICollection<string> names = new HashSet<string>();