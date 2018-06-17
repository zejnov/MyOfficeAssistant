using System;
using System.Linq;
using Component.Service.CommandsManager;
using Game.TicTacToe.CommandManagement;
using Game.TicTacToe.CommandManagement.Commands;
using Game.TTTProvider.Configuration;

namespace Game.TicTacToe.IoHelpers
{
    class ReadHelper
    {
        public static string GetCommandFromUser()
        {
            var command = "";
            bool commandOk = false;
            do
            {
                try
                {
                    command = GetData<string>("\nPlease provide command");
                }
                catch (Exception)
                {
                    Console.Write("Bad command, please try again.");
                }

                if (CheckCommandExist(command))
                {
                    commandOk = true;
                }
                else
                {
                    Console.Write("Bad command, please try again...");
                }
            } while (!commandOk);
            return command;
        }

        private static bool CheckCommandExist(string command)
        {
            return CommandManager<IGameCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).GetAvaibleCommandNames().Contains(command);
        }

        public static T GetData<T>(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message + ": ");
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("\nYou didnt gave anything, try again");
                }
                catch (Exception)
                {
                    Console.Write("\nSomething went wrong, try again\n");
                }
            }
        }

        public static ConfigurationModel GetNewConfig()
        {
            //command = GetData<string>("\nPlease provide command");
            var ok = false;
            int size, number;
            do
            {
                size = GetData<int>("Provide new board size");
                if (size >=3 && size <= 10)
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine("Number out of range <3-10>");
                }

            } while (!ok);

            ok = false;
            do
            {
                number = GetData<int>("Provide new winning-in-row number");
                if (number>=3 && number <= size)
                {
                    ok = true;
                }
                else
                {
                    Console.WriteLine($"Number out of range <3-{size}>");
                }
            } while (!ok);

            return new ConfigurationModel()
            {
                BoardSize = size,
                WinningNumber = number
            };
        }
    }
}
