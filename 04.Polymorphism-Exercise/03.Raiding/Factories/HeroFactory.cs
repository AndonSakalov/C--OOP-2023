using _03.Raiding.Factories.Interfaces;
using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroName, string heroType)
        {
            switch (heroType)
            {
                case "Druid":
                    return new Druid(heroName);
                case "Paladin":
                    return new Paladin(heroName);
                case "Rogue":
                    return new Rogue(heroName);
                case "Warrior":
                    return new Warrior(heroName);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
