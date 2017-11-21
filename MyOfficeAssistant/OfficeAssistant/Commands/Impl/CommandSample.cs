using System;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandSample : ICommand
    {
        public string Name => "s";
        public string HelpInfo => "Doing sample stuff";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            var menu = new GraphicMenu();
            Console.Clear();
            var list = CommandManager.GetInstance().GetAvaibleCommands();

            menu.PrintMenu(list);

            Console.ReadKey();
        }
    }
}
