using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>
        {
            typeof(Meat)
        };

        protected override double WeightMultiplier => 0.40;

        public override string ProduceSound() => "Woof!";
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
