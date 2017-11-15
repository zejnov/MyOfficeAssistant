using System;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandSample : ICommand
    {
        public string Name => "s";
        public string HelpInfo => "Doing sample stuff";
        public void Execute()
        {
            var menu = new GraphicMenu();
            Console.Clear();
            menu.PrintMenu();

            Console.ReadKey();
        }
    }
}
