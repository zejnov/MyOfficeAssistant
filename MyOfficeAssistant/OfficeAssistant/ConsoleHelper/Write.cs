using System;
using System.Collections.Generic;
using OfficeAssistant.Commands;

namespace OfficeAssistant.ConsoleHelper
{
    public class Write
    {
        internal static void AvaibleCommands()
        {
            var commands = CommandManager.GetInstance().GetAvaibleCommandNames();
            Console.Clear();
            Console.Write("Avaible commands: ");
            var counter = 0;
            foreach (var entry in commands)
            {
                Console.Write($"{entry}   ");
                counter++;
                if (counter % 6 == 0)
                {
                    Console.Write("\n\t\t  ");
                }
            }
        }

        public static void Commands(IEnumerable<string> commands)
        {
            Console.Clear();
            Console.Write("Avaible commands: ");
            var counter = 0;
            foreach (var entry in commands)
            {
                Console.Write($"{entry}   ");
                counter++;
                if (counter % 6 == 0)
                {
                    Console.Write("\n\t\t  ");
                }
            }
        }
    }
}
