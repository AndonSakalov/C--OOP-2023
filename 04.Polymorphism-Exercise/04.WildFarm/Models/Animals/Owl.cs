using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten) : base(name, weight, foodEaten)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>
        {
            typeof(Meat)
        };

        protected override double WeightMultiplier => 0.25;

        public override string ProduceSound() => "Hoot Hoot";
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
