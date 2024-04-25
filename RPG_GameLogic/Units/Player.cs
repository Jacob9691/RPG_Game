using RPG_GameLogic.Interfaces;
using System;

namespace RPG_GameLogic.Units
{
    internal class Player : IPlayer
    {
        public string? Name { get; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public int ExpBar { get; set; }
        public int Money { get; set; }

        readonly object _locker = new object();

        public Player(string? name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Level = 1;
            Experience = 0;
            ExpBar = 100;
            Money = 0;
        }

        public void Attack(int damage, string weaponType)
        {
            try
            {
                switch (weaponType)
                {
                    case "bow":
                        Console.WriteLine($"{Name} shoots with their bow for {damage} damage!");
                        break;
                    case "sword":
                        Console.WriteLine($"{Name} swings with their sword for {damage} damage!");
                        break;
                    case "shield":
                        Console.WriteLine($"{Name} reflects with their shield the enemy's attack for {damage} damage!");
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
                Console.WriteLine($"{Name} has died...");
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

        public void Heal()
        {
            try
            {
                if (Money < 75)
                {
                    Console.WriteLine("Not enough money to heal");
                    return;
                }
                CurrentHealth = MaxHealth;
                Console.WriteLine($"{Name} heals themself. Current health: {CurrentHealth}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void LevelUp()
        {
            try
            {
                Experience = 0;
                Level++;
                ExpBar += 50;
                MaxHealth += 25;
                CurrentHealth = MaxHealth;
                Console.WriteLine($"{Name} leveled up to {Level}. Max health: {MaxHealth}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void Loot(int experience, int money)
        {
            try
            {
                Console.WriteLine($"{Name} won the battle");
                Experience += experience;
                if (Experience >= ExpBar)
                    LevelUp();
                Money += money;
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
                Console.WriteLine($"Name: {Name}\nHealth: {CurrentHealth}/{MaxHealth}\nLevel: {Level}\nExp: {Experience}/{ExpBar}\nMoney: {Money}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void HealingOrbs(int orb)
        {
            lock (_locker)
            {
                try
                {
                    if (CurrentHealth <= MaxHealth)
                        CurrentHealth += orb;
                    Console.WriteLine($"a {orb} orb heals you");
                    if (CurrentHealth > MaxHealth)
                        CurrentHealth = MaxHealth;
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
