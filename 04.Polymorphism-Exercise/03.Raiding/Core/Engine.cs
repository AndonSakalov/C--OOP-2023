using _03.Raiding.Core.Interfaces;
using _03.Raiding.Factories.Interfaces;
using _03.Raiding.IO.Interfaces;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;
        private readonly ICollection<IHero> raidGroup;
        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
            raidGroup = new List<IHero>();
        }
        public void Run()
        {
            int countOfHeroes = int.Parse(reader.ReadLine());
            for (int i = 0; i < countOfHeroes; i++)
            {
                string heroName = reader.ReadLine();
                string heroType = reader.ReadLine();
                try
                {
                    IHero currentHero = heroFactory.CreateHero(heroName, heroType);
                    raidGroup.Add(currentHero);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    i--;
                }
            }

            int bossPower = int.Parse(reader.ReadLine());
            int raidGroupPower = 0;
            foreach (var hero in raidGroup)
            {
                writer.WriteLine(hero.CastAbility());
                raidGroupPower += hero.Power;
            }

            if (raidGroupPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}
