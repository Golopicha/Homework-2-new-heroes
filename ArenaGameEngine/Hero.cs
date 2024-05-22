using System;

namespace ArenaGameEngine
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public bool IsAlive => Health > 0;
        public bool IsDead => !IsAlive;
        public bool IsSkipNextTurn { get; private set; }

        public Hero(string name)
        {
            Name = name;
            Health = 300;
            Strength = 60;
            IsSkipNextTurn = false;
        }

        public void SkipNextTurn()
        {
            Console.WriteLine($"{Name} skips the next turn.");
            IsSkipNextTurn = true;
        }

        public void ResetSkipNextTurn()
        {
            IsSkipNextTurn = false;
        }

        public virtual int Attack()
        {
            if (IsSkipNextTurn)
            {
                Console.WriteLine($"{Name} skips the attack due to special condition.");
                ResetSkipNextTurn();
                return 0;
            }
            int coef = Random.Shared.Next(80, 121);
            return (coef * Strength) / 100;
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            Health -= incomingDamage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
        public Hero Target { get; private set; }

        public void SetTarget(Hero target)
        {
            Target = target;
        }

    }
}