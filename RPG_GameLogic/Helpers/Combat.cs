using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            List<int> HealingOrbs = new List<int>();
            List<Task> Tasks = new List<Task>();

            bool Combat = true;
            
            while (Combat)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"{player.Name}\nhealth: {player.CurrentHealth}\n");
                    enemy.ShowStats();
                    Console.WriteLine($"\nAttack with bow, sword or shield\nYou got {HealingOrbs.Count} healing orbs (type heal to use)\n");
                    string? EnemyAction = enemyGenerator.GetEnemyAction(rng.Next(0, 3));
                    string? Action = Console.ReadLine();

                    int EnemyDamage = rng.Next(10, 20);
                    int PlayerDamge = rng.Next(bow.MinDamage, bow.MaxDamage);

                    if (HealingOrbs.Count > 0 && Action == "heal")
                    {
                        _ = HandleHealingOrbsAsync(player, HealingOrbs, Tasks);
                        HealingOrbs = new List<int>();
                        Tasks = new List<Task>();
                    }

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
                            HealingOrbs.Add(rng.Next(1, 6));
                            Console.WriteLine("You got a healing orb");
                        }
                        else
                        {
                            Console.WriteLine("you both shoot at each other, but you cancel each other's attack");
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
                            HealingOrbs.Add(rng.Next(1, 6));
                            Console.WriteLine("You got a healing orb");
                        }
                        else
                        {
                            Console.WriteLine("you both swing at each other, but you cancel each other's attack");
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
                            HealingOrbs.Add(rng.Next(1, 6));
                            Console.WriteLine("You got a healing orb");
                        }
                        else
                        {
                            Console.WriteLine("you both shield, nothing happened...");
                        }
                    }

                    if (player.CurrentHealth <= 0 || enemy.CurrentHealth <= 0)
                    {
                        Combat = false;
                    }
                    Console.ReadLine();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            if (player.CurrentHealth > 0)
            {
                player.Loot(enemy.Experience, enemy.Money);
                return "victory";
            }

            return "failed";
        }

        private async Task HandleHealingOrbsAsync(IPlayer player, List<int> HealingOrbs, List<Task> Tasks)
        {
            foreach (int i in HealingOrbs)
            {
                Tasks.Add(Task.Run(() => {
                    player.HealingOrbs(i);
                }));
            }
            await Task.WhenAll(Tasks);
        }
    }
}
