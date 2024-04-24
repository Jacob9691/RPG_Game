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
        public IPlayer CreatePlayer(string? name, int maxHealth)
        {
            return new Player(name, maxHealth);
        }

        public IUnit CreateEnemy()
        {
            return new Enemy(name, currentHealth, experience, money);
        }
    }
}
