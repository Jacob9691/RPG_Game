﻿using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RPG_GameLogic.Units
{
    internal class Player(string? name, int maxHealth) : IPlayer
    {
        public string? Name { get; } = name;

        public int MaxHealth { get; set; } = maxHealth;

        public int CurrentHealth { get; set; } = maxHealth;

        public int Level { get; set; } = 1;

        public int Experience { get; set; } = 0;

        public int ExpBar { get; set; } = 100;

        public int Money { get; set; } = 0;

        public void Attack(int damage, string weaponType)
        {
            switch (weaponType)
            {
                case "Bow":
                    Console.WriteLine($"{Name} shoots with their bow for {damage} damage!");
                    break;
                case "Sword":
                    Console.WriteLine($"{Name} swings with their sword for {damage} damage!");
                    break;
                case "Shield":
                    Console.WriteLine($"{Name} reflects with their shield the enemy's attack for {damage} damage!");
                    break;
                default:
                    break;
            }
        }

        public void Die()
        {
            Console.WriteLine($"{Name} has died...");
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
                Die();
            else
                Console.WriteLine($"{Name} takes {damage} damage. Current health: {CurrentHealth}");
        }

        public void Heal()
        {
            CurrentHealth = MaxHealth;
            Console.WriteLine($"{Name} heals themself. Current health: {CurrentHealth}");
        }

        public void LevelUp()
        {
            Experience = 0;
            Level++;
            ExpBar += 50;
            MaxHealth += 25;
            CurrentHealth = MaxHealth;

            Console.WriteLine($"{Name} leveled up to {Level}. Max health: {MaxHealth}");
        }

        public void Loot(int experience, int money) 
        {
            Experience += experience;
            if (Experience >= ExpBar)
                LevelUp();
            Money += money;
        }
    }
}
