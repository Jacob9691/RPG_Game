using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Interfaces
{
    internal interface IUnit
    {
        string Name { get; }
        string Description { get; }
        int MaxHealth { get; }
        int CurrentHealth {  get; }
        void Move();
        void TakeDamage(int damage);
        void Attack(int damage);
        void Die();
    }
}
