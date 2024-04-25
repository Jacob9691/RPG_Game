using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Helpers
{
    internal class WeaponUpgrader
    {
        public WeaponUpgrader() { }

        public void Upgrade(IPlayer player, IWeapon weapon)
        {
            switch (weapon.WeaponLevel)
            {
                case "wood":
                    if (player.Money >= weapon.UpgrdePrice)
                    {
                        weapon.WeaponLevel = "copper";
                        weapon.MinDamage += 10;
                        weapon.MaxDamage += 20;
                        player.Money -= weapon.UpgrdePrice;
                        weapon.UpgrdePrice += 100;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money to upgrade");
                    }
                    break;
                case "copper":
                    if (player.Money >= weapon.UpgrdePrice)
                    {
                        weapon.WeaponLevel = "iron";
                        weapon.MinDamage += 10;
                        weapon.MaxDamage += 20;
                        player.Money -= weapon.UpgrdePrice;
                        weapon.UpgrdePrice += 200;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money to upgrade");
                    }
                    break;
                case "iron":
                    if (player.Money >= weapon.UpgrdePrice)
                    {
                        weapon.WeaponLevel = "gold";
                        weapon.MinDamage += 10;
                        weapon.MaxDamage += 20;
                        player.Money -= weapon.UpgrdePrice;
                        weapon.UpgrdePrice += 400;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money to upgrade");
                        Console.ReadLine();
                    }
                    break;
                case "gold":
                    if (player.Money >= weapon.UpgrdePrice)
                    {
                        weapon.WeaponLevel = "diamond";
                        weapon.MinDamage += 10;
                        weapon.MaxDamage += 20;
                        player.Money -= weapon.UpgrdePrice;
                        weapon.UpgrdePrice += 800;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money to upgrade");
                        Console.ReadLine();
                    }
                    break;
                case "diamond":
                    if (player.Money >= weapon.UpgrdePrice)
                    {
                        weapon.WeaponLevel = "platinum";
                        weapon.MinDamage += 10;
                        weapon.MaxDamage += 20;
                        player.Money -= weapon.UpgrdePrice;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money to upgrade");
                        Console.ReadLine();
                    }
                    break;
                case "platinum":
                    Console.WriteLine("Weapon can't be further upgraded...");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Couldn't upgrade weapon...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
