using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        protected override IReadOnlyCollection<Type> PreferredFood => new HashSet<Type>
        {
            typeof(Meat)
        };

        protected override double WeightMultiplier => 1;

        public override string ProduceSound() => "ROAR!!!";
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
