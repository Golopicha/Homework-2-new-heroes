using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    public class Wizard : Hero
    {
        public Wizard() : this("Merrick Starfire") 
        {
        }

        public Wizard(string name) : base(name)
        {
           
        }

        public override int Attack()
        {
            // Wizzard hits 3 times with her magic ball
            int totalDamage = 0;
            for (int i = 0; i < 3; i++)
            {
                int balldamage = Random.Shared.Next(40, 61); // Each ball can deal 15-40 damage
                totalDamage += balldamage;
            }
            return totalDamage;
        }
    }
}

