using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Interfaces
{
    internal interface IWeapon
    {
        string WeaponLevel { get; set; }

        int MinDamage { get; set; }

        int MaxDamage { get; set; }

        int UpgrdePrice { get; set; }
    }
}
