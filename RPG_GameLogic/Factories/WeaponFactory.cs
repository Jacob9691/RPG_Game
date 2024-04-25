using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Factories
{
    internal class WeaponFactory
    {
        public IWeapon CreateWeapon<T>() where T : IWeapon, new()
        {
            try
            {
                return new T();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't create weapon: " + ex.Message);
                throw;
            }
        }
    }
}
