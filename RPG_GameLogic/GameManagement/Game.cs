using RPG_GameLogic.Factories;
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
            bool NamePicking = true;
            string? name = "";

            while (NamePicking)
            {
                Console.WriteLine("Make your character");
                Console.WriteLine("Type your name:");
                try
                {
                    name = Console.ReadLine();
                    NamePicking = name == null || name.Length == 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Clear();
            }
            Console.WriteLine("Do you want easy or hard mode?");
            var mode = Console.ReadLine();
            int health;
            if (mode == "easy")
            {
                Console.WriteLine("You picked easy mode");
                health = 100;
            }
            else if (mode == "hard")
            {
                Console.WriteLine("You picked hard mode");
                health = 50;
            } 
            else
            {
                Console.WriteLine("You didn't pick a mode so you'll get extra hard mode :)");
                health = 25;
            }
            var unitFactory = new UnitFactory();
            var player = unitFactory.CreatePlayer(name, health);
        }
    }
}
