using System;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.MainMenu
{
    public class Sample : IMainMenuCommand
    {
        public string DisplayName => "Sample";
        public int Ordinal => 555;
        public string Command => DisplayName;
        public string HelpInfo => "Doing sample stuff";
        public bool IsSelected { get; set; }

        private MenuManager<IMainMenuCommand> _menuManager { get; set; }
        public MenuManager<IMainMenuCommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<IMainMenuCommand>());

        public void Execute()
        {
            Console.Clear();
            Console.Write("Sample command");

            Console.ReadKey();
        }
    }
}
