using System;
using System.Linq;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandSample : ICommand
    {
        public string Name => "bcdefghijklmnoprst";
        public string Command => Name;
        public string HelpInfo => "Doing sample stuff";
        public bool IsHighlighted { get; set; }

        private MenuManager _menuManager { get; set; }
        public MenuManager MenuManager => _menuManager ?? (_menuManager = new MenuManager());

        public void Execute()
        {
            var list = CommandManager.GetInstance().GetAvaibleCommands().ToList();
            var commandsArray = MenuManager.GenerateCommandsArray(list, 4);

            var menu = new GraphicMenu();
            Console.Clear();

            menu.PrintMenu(commandsArray);

            Console.ReadKey();
        }
    }
}
