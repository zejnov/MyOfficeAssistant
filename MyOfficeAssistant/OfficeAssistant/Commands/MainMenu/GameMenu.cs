using System;
using System.Linq;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Core.Exception;
using OfficeAssistant.Core.State;

namespace OfficeAssistant.Commands.MainMenu
{
    public class GameMenu : IMainMenuCommand
    {
        public string DisplayName => "GameMenu";
        public int Ordinal => 50;
        public string Command => "g";
        public string HelpInfo => "Showing games";
        public bool IsSelected { get; set; }

        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<IGameMenuCommand> _graphicMenu { get; set; }
        private MenuManager<IGameMenuCommand> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<IGameMenuCommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<IGameMenuCommand>());
        public GraphicMenu<IGameMenuCommand> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<IGameMenuCommand>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());

        public void Execute()
        {
            var list = CommandManager<IGameMenuCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly())
                .GetAvaibleCommands();

            try
            {
                new Menu<IGameMenuCommand>().Invoke(list, ApplicationState.IsRunning);
            }
            catch (ExitException e)
            {
            }
            
        }
    }
}
