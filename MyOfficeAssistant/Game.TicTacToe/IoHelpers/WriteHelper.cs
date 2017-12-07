﻿using System;
using Game.TicTacToe.CommandManagement;

namespace Game.TicTacToe.IoHelpers
{
    public class WriteHelper
    {
        /// <summary>
        /// printing help for given commands
        /// </summary>
        public static void PrintAvaibleCommandsHelp()//List<ICommand> commands)
        {
            var commands = CommandManager.GetInstance().GetAllCommands();
            int i = 1;
            Console.Clear();
            Console.WriteLine("WELCOME TO HELP!");
            foreach (var command in commands)
            {
                Console.WriteLine($"\n{i++}. {command.Name}  \t-\t {command.HelpInfo}");
            }
            Console.WriteLine("\n\nzejnov/2017\n");
            Console.ReadKey();
            Console.Clear();
        }

        public static void PrintAvaibleCommands()
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
    }
}