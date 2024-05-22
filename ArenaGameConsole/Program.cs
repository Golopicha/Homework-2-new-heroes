using System;
using ArenaGameEngine;

namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void GameRound(Hero attacker, Hero defender, int attack)
        {
            string message = $"{attacker.Name} attacked {defender.Name} for {attack} points";
            if (defender.IsAlive)
            {
                message = message + $" but {defender.Name} survived.";
            }
            else
            {
                message = message + $" and {defender.Name} died.";
            }
            Console.WriteLine(message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Knight knight = new Knight("Sir John");
            Rogue rogue = new Rogue("Slim Shady");
            Wizard wizard = new Wizard("Merrick Starfire");
            Arena arena = new Arena(knight, rogue, wizard);
            arena.SetEventListener(new ConsoleGameEventListener());

            Vampire vampire = new Vampire("Vesper Nocturne");
            arena.Heroes.Add(vampire); 

            arena.StartBattle();
            Console.ReadLine();
        }
    }
}
