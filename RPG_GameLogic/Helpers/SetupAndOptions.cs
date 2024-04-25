using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_GameLogic.Helpers
{
    internal class SetupAndOptions
    {
        public SetupAndOptions() { }

        public string? PlayerOptions()
        {
            Console.Clear();
            Console.WriteLine("Available inputs:\n- show stats\n- combat\n- heal (75g)\n- upgrade weapons\n- end");
            return Console.ReadLine();
        }
        public (string?, int) Setup()
        {
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
                Console.ReadLine();
                health = 25;
            }
            return (name, health);
        }
    }
}
