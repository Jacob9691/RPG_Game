using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Helpers
{
    internal class Combat
    {
        readonly Random rng = new Random();
        EnemyGenerator enemyGenerator = new EnemyGenerator();
        public Combat() { }

        public string CombatLogic(IPlayer player, IUnit enemy, IWeapon bow, IWeapon sword, IWeapon shield) 
        {
            bool Combat = true;
            while (Combat)
            {
                Console.Clear();
                Console.WriteLine($"{player.Name}\nhealth: {player.CurrentHealth}\n");
                enemy.ShowStats();
                Console.WriteLine("\nAttack with bow, sword or shield");
                string? EnemyAction = enemyGenerator.GetEnemyAction(rng.Next(0, 2));
                string? Action = Console.ReadLine();

                int EnemyDamage = rng.Next(10, 20);
                int PlayerDamge = rng.Next(bow.MinDamage, bow.MaxDamage);

                if (Action == "bow")
                {
                    if (EnemyAction == "shield")
                    {
                        enemy.Attack(rng.Next(10, 20), EnemyAction);
                        player.TakeDamage(EnemyDamage);
                    }
                    else if (EnemyAction == "sword")
                    {
                        player.Attack(rng.Next(bow.MinDamage, bow.MaxDamage), Action);
                        enemy.TakeDamage(PlayerDamge);
                    }
                    else
                    {
                        Console.WriteLine("you both shoot at each other, but you cancel each other's attack");
                        Console.ReadLine();
                    }
                }
                else if (Action == "sword")
                {
                    if (EnemyAction == "bow")
                    {
                        enemy.Attack(rng.Next(10, 20), EnemyAction);
                        player.TakeDamage(EnemyDamage);
                    }
                    else if (EnemyAction == "shield")
                    {
                        player.Attack(rng.Next(sword.MinDamage, sword.MaxDamage), Action);
                        enemy.TakeDamage(PlayerDamge);
                    }
                    else
                    {
                        Console.WriteLine("you both swing at each other, but you cancel each other's attack");
                        Console.ReadLine();
                    }
                }
                else if (Action == "shield")
                {
                    if (EnemyAction == "sword")
                    {
                        enemy.Attack(rng.Next(10, 20), EnemyAction);
                        player.TakeDamage(EnemyDamage);
                    }
                    else if (EnemyAction == "bow")
                    {
                        player.Attack(rng.Next(shield.MinDamage, shield.MaxDamage), Action);
                        enemy.TakeDamage(PlayerDamge);
                    }
                    else
                    {
                        Console.WriteLine("you both shield, nothing happened...");
                        Console.ReadLine();
                    }
                }

                if (player.CurrentHealth <= 0 || enemy.CurrentHealth <= 0)
                {
                    Combat = false;
                }
            }

            if (player.CurrentHealth > 0)
            {
                player.Loot(enemy.Experience, enemy.Money);
                return "victory";
            }

            return "failed";
        }
    }
}
