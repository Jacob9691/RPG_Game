using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Interfaces
{
    internal interface IPlayer : IUnit
    {
        int MaxHealth { get; set; }
        int Level { get; set; }
        int ExpBar { get; set; }

        void Heal();
        void LevelUp();
        void Loot(int experience, int money);
        void HealingOrbs(int orb);
    }
}
