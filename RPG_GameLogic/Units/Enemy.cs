using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Units
{
    internal class Enemy : IUnit
    {
        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public int MaxHealth => throw new NotImplementedException();

        public int CurrentHealth => throw new NotImplementedException();

        public void Attack(int damage)
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }
}
