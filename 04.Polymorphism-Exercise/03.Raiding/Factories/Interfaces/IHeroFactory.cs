using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IHero CreateHero(string heroName, string heroType);
    }
}
