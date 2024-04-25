using RPG_GameLogic.Factories;
using RPG_GameLogic.Helpers;
using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Items.Weapons;
using RPG_GameLogic.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG_GameLogic.GameManagement
{
    public class Game
    {
        public Game() {}

        public void Start()
        {
            Console.WriteLine("Welcome to the game...");
            Console.WriteLine();

            SetupAndOptions setupAndOptions = new SetupAndOptions();
            var Char = setupAndOptions.Setup();

            UnitFactory unitFactory = new UnitFactory();
            var player = unitFactory.CreatePlayer(Char.Item1, Char.Item2);

            WeaponFactory weaponFactory = new WeaponFactory();
            var bow = weaponFactory.CreateWeapon<Bow>();
            var sword = weaponFactory.CreateWeapon<Sword>();
            var shield = weaponFactory.CreateWeapon<Shield>();
            WeaponUpgrader weaponUpgrader = new WeaponUpgrader();

            Combat combat = new Combat();

            while (true)
            {
                string? playerOption = setupAndOptions.PlayerOptions();

                switch (playerOption)
                {
                    case "show stats":
                        Console.Clear();
                        player.ShowStats();
                        Console.WriteLine($"{bow.WeaponLevel} bow\n{sword.WeaponLevel} sword\n{shield.WeaponLevel} shield");
                        Console.ReadLine();
                        break;
                    case "combat":
                        Console.Clear();
                        var enemy = unitFactory.CreateEnemy();
                        string result = combat.CombatLogic(player, enemy, bow, sword, shield);
                        if (result == "failed")
                            return;
                        Console.ReadLine();
                        break;
                    case "heal":
                        Console.Clear();
                        player.Heal();
                        Console.ReadLine();
                        break;
                    case "upgrade weapons":
                        Console.Clear();
                        Console.WriteLine($"Upgrade list:\nbow {bow.UpgrdePrice}g\nsword {sword.UpgrdePrice}\nshield {shield.UpgrdePrice}");
                        string? ItemPick = Console.ReadLine();
                        switch (ItemPick)
                        {
                            case "bow":
                                Console.Clear();
                                weaponUpgrader.Upgrade(player, bow);
                                break;
                            case "sword":
                                Console.Clear();
                                weaponUpgrader.Upgrade(player, sword);
                                break;
                            case "shield":
                                Console.Clear();
                                weaponUpgrader.Upgrade(player, shield);
                                break;
                            default:
                                Console.Clear();
                                break;
                        }
                        break;
                    case "end":
                        Console.WriteLine("Thank you for playing");
                        Console.ReadLine();
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
