using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {

        }
        protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>
        {
            typeof(Meat),
            typeof(Vegetable),
            typeof(Seeds),
            typeof(Fruit)
        };

        protected override double WeightMultiplier => 0.35;

        public override string ProduceSound() => "Cluck";
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
