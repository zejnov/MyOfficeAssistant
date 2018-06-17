using System;
using System.Linq;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.Impl
{
    public class MainMenuCommandSample : IMainMenuCommand
    {
        public string DisplayName => "bcdefghijklmnoprst";
        public int Ordinal => 555;
        public string Command => DisplayName;
        public string HelpInfo => "Doing sample stuff";
        public bool IsSelected { get; set; }

        private MenuManager<IMainMenuCommand> _menuManager { get; set; }
        public MenuManager<IMainMenuCommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<IMainMenuCommand>());

        public void Execute()
        {
            var list = CommandManager<IMainMenuCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).GetAvaibleCommands();
            var commandsArray = MenuManager.GenerateCommandsArray(list, 4);

            var menu = new GraphicMenu<IMainMenuCommand>();
            Console.Clear();

            menu.PrintMenu(commandsArray);

            Console.ReadKey();
        }
    }
}
