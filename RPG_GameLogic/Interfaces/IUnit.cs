using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Interfaces
{
    internal interface IUnit
    {
        string? Name { get; }
        int CurrentHealth { get; set; }
        int Experience { get; set; }
        int Money { get; set; }

        void Attack(int damage, string weaponType);
        void Die();
        void TakeDamage(int damage);
    }
}
