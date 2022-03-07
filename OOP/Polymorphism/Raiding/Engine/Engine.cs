using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raiding
{
    public class Engine
    {
        public void Run()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            int n = int.Parse(Console.ReadLine());
            while (heroes.Count != n)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();
                if (type == "Druid")
                {
                    heroes.Add(new Druid(name));
                }
                else if (type == "Paladin")
                {
                    heroes.Add(new Paladin(name));
                }
                else if (type == "Rogue")
                {
                    heroes.Add(new Rogue(name));
                }
                else if (type == "Warrior")
                {
                    heroes.Add(new Warrior(name));
                }
                else
                {
                    Console.WriteLine($"Invalid hero!");
                }
            }
            int bossHp = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            var sum = heroes.Select(x => x.Power).Sum();
            if (sum >= bossHp)
            {
                Console.WriteLine($"Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
