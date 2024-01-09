using _04.WildFarm.Models.Interfaces;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }

        protected virtual IReadOnlyCollection<Type> PreferredFood { get; }
        public abstract string ProduceSound();

        public void Eat(IFood food)
        {
            if (!PreferredFood.Any(p => p.Name == food.GetType().Name))
            {
                throw new ArgumentException($"{GetType().Name} does not eat {food.GetType().Name}!");
            }

            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightMultiplier;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
