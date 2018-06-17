using System;
using System.Collections.Generic;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Commands;

namespace OfficeAssistant.ConsoleHelper
{
    public class Write
    {
        internal static void AvaibleCommands()
        {
            var commands = CommandManager<ICommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).GetAvaibleCommandNames();
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

        public static void PrintAvaibleCommandsHelp(List<ICommand> commands)
        {
            int i = 1;
            Console.Clear();
            Console.WriteLine("WELCOME TO HELP!");
            foreach (var command in commands)
            {
                Console.WriteLine($"\n{i++}. {command.Name} \t-\t {command.HelpInfo}");
            }
            Console.WriteLine("\n\nzjv/2017\n");
            Read.Wait();
        }
    }
}
