using RPG_GameLogic.Helpers;
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
        EnemyGenerator enemyGenerator = new EnemyGenerator();

        public IPlayer CreatePlayer(string? name, int maxHealth)
        {
            try
            {
                return new Player(name, maxHealth);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't create player: " + ex.Message);
                throw;
            }
        }

        public IUnit CreateEnemy()
        {
            try
            {
                string? name = enemyGenerator.GetEnemyName(rng.Next(0, 4));
                int currentHealth = rng.Next(50, 100);
                int experience = rng.Next(25, 100);
                int money = rng.Next(50, 250);
                return new Enemy(name, currentHealth, experience, money);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't create enemy: " + ex.Message);
                throw;
            }
        }
    }
}
