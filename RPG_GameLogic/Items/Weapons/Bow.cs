using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Items.Weapons
{
    internal class Bow : IWeapon
    {
        public string WeaponLevel { get; set; } = "wood";

        public int MinDamage { get; set; } = 10;

        public int MaxDamage { get; set; } = 20;

        public int UpgrdePrice { get; set; } = 100;
    }
}