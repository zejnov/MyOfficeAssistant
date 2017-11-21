using System;
using System.Linq;
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
            var list = CommandManager.GetInstance().GetAvaibleCommands().ToList();

            var menu = new GraphicMenu(list);
            Console.Clear();




            menu.PrintMenu();

            Console.ReadKey();
        }
    }
}
