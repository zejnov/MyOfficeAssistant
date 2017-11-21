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

        public static void Enter()
        {
            Console.Write("\n");
        }

        public static void Vertical(bool withNewLine = false)
        {
            if (withNewLine) Enter();
            Console.Write("|");
        }

        public static void Space(int space = 1)
        {
            for (var i = 0; i < space; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
