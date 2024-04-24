using RPG_GameLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Units
{
    internal class Enemy(string? name, int currentHealth, int experience, int money) : IUnit
    {
        public string? Name { get; } = name;

        public int CurrentHealth { get; set; } = currentHealth;

        public int Experience { get; set; } = experience;

        public int Money { get; set; } = money;

        public void Attack(int damage, string weaponType)
        {
            switch (weaponType)
            {
                case "Bow":
                    Console.WriteLine($"{Name} shoots at you for {damage} damage!");
                    break;
                case "Sword":
                    Console.WriteLine($"{Name} swings at you for {damage} damage!");
                    break;
                case "Shield":
                    Console.WriteLine($"{Name} reflects your attack back at you for {damage} damage!");
                    break;
                default:
                    break;
            }
        }

        public void Die()
        {
            Console.WriteLine($"{Name} has died!");
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
                Die();
            else
                Console.WriteLine($"{Name} takes {damage} damage. Current health: {CurrentHealth}");
        }
    }
}
