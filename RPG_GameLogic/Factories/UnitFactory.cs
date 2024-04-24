using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Factories
{
    internal class UnitFactory
    {
        readonly Random rng = new Random();

        public IPlayer CreatePlayer(string? name, int maxHealth)
        {
            return new Player(name, maxHealth);
        }

        public IUnit CreateEnemy()
        {
            string? name = GetEnemyName(rng.Next(0, 4));
            int currentHealth = rng.Next(100, 200);
            int experience = rng.Next(25, 100);
            int money = rng.Next(50, 250);
            return new Enemy(name, currentHealth, experience, money);
        }

        private static string? GetEnemyName(int enemyPicker)
        {
            return enemyPicker switch
            {
                0 => "Slime",
                1 => "Goblin",
                2 => "Orc",
                3 => "Imp",
                4 => "Spider",
                _ => "Slime",
            };
        }
    }
}
