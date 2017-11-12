using System;
using System.Collections.Generic;
using Component.Commands.Commands;

namespace Component.Service.ConsoleHelper.ConsoleHelper
{
    public class Write
    {
        internal static void AvaibleCommands(IEnumerable<ICommand> commands)
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
