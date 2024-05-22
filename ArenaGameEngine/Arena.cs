using System;
using System.Collections.Generic;
using System.Linq;

namespace ArenaGameEngine
{
    public class Arena
    {
        private static Arena _instance;
        private List<Hero> heroes = new List<Hero>();
        public GameEventListener EventListener { get; set; }

        public static Arena Instance => _instance ??= new Arena();

        public List<Hero> Heroes => heroes;

        private Arena() { }

        public Arena(params Hero[] heroes)
        {
            _instance = this;
            this.heroes.AddRange(heroes);
        }

        public void SetEventListener(GameEventListener listener)
        {
            EventListener = listener;
        }

        public void StartBattle()
        {
            Console.WriteLine("Battle begins.");

            Random random = new Random();
            heroes = heroes.OrderBy(x => random.Next()).ToList(); // Разбъркване на реда на героите

            while (NumberOfAliveHeroes() > 1)
            {
                foreach (var attacker in heroes)
                {
                    if (attacker.IsDead) continue;

                    var defender = FindNextAliveHero(attacker);

                    if (defender == null) break;

                    int damage = attacker.Attack();
                    defender.TakeDamage(damage);

                    EventListener?.GameRound(attacker, defender, damage);

                    if (defender.IsDead)
                    {
                        Console.WriteLine($"{defender.Name} has died.");
                    }

                    if (NumberOfAliveHeroes() <= 1)
                        break;
                }
            }

            Hero winner = heroes.FirstOrDefault(hero => hero.IsAlive);
            Console.WriteLine("Battle ended.");
            Console.WriteLine($"Winner: {winner.Name}");
        }

        public int NumberOfAliveHeroes()
        {
            return heroes.Count(hero => hero.IsAlive);
        }

        private Hero FindNextAliveHero(Hero attacker)
        {
            return heroes.FirstOrDefault(hero => hero != attacker && hero.IsAlive);
        }
    }
}
