namespace _03.Raiding.Models.Interfaces
{
    public interface IHero
    {
        string Name { get; }
        int Power { get; }
        string CastAbility();
    }
}
