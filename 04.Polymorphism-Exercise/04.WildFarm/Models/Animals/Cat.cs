using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>
        {
            typeof(Meat),
            typeof(Vegetable)
        };

        protected override double WeightMultiplier => 0.30;

        public override string ProduceSound() => "Meow";

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
