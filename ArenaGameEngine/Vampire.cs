using System;
using System.Linq;

namespace ArenaGameEngine
{
    public class Vampire : Hero
    {
        public Vampire(string name) : base(name)
        {
        }

        public override int Attack()
        {
            int damage;
            int dice = new Random().Next(0, 100);

            if (dice <= 30) // 30% шанс за специална атака
            {
                var target = FindAliveHeroToSkip();
                if (target != null)
                {
                    Console.WriteLine($"{Name} uses special attack to make {target.Name} skip a turn and deal extra damage!");
                    target.SkipNextTurn();
                }

                damage = base.Attack() + 80;
            }
            else
            {
                damage = base.Attack();
            }

            return damage;
        }

        private Hero FindAliveHeroToSkip()
        {
            return Arena.Instance.Heroes.FirstOrDefault(hero => hero != this && hero.IsAlive);
        }
    }
}
