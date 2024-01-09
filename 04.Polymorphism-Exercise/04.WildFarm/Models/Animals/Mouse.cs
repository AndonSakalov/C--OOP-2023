using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>
        {
            typeof(Vegetable),
            typeof(Fruit)
        };

        protected override double WeightMultiplier => 0.10;

        public override string ProduceSound() => "Squeak";
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

