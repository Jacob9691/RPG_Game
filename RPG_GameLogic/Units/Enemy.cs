using RPG_GameLogic.Interfaces;
using System;

namespace RPG_GameLogic.Units
{
    internal class Enemy : IUnit
    {
        public string? Name { get; }
        public int CurrentHealth { get; set; }
        public int Experience { get; set; }
        public int Money { get; set; }

        public Enemy(string? name, int currentHealth, int experience, int money)
        {
            Name = name;
            CurrentHealth = currentHealth;
            Experience = experience;
            Money = money;
        }

        public void Attack(int damage, string weaponType)
        {
            try
            {
                switch (weaponType)
                {
                    case "bow":
                        Console.WriteLine($"{Name} shoots at you for {damage} damage!");
                        break;
                    case "sword":
                        Console.WriteLine($"{Name} swings at you for {damage} damage!");
                        break;
                    case "shield":
                        Console.WriteLine($"{Name} reflects your attack back at you for {damage} damage!");
                        break;
                    default:
                        throw new ArgumentException("Invalid weapon type");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Die()
        {
            try
            {
                Console.WriteLine($"{Name} has died!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void TakeDamage(int damage)
        {
            try
            {
                CurrentHealth -= damage;
                if (CurrentHealth <= 0)
                    Die();
                else
                    Console.WriteLine($"{Name} takes {damage} damage. Current health: {CurrentHealth}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ShowStats()
        {
            try
            {
                Console.WriteLine($"Name: {Name}\nHealth: {CurrentHealth}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
