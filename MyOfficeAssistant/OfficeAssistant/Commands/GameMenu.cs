using System;
using System.Linq;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Core.Exception;
using OfficeAssistant.Core.State;

namespace OfficeAssistant.Commands
{
    public class GameMenu : IMainMenuCommand
    {
        public string DisplayName => "GameMenu";
        public int Ordinal => 50;
        public string Command => "g";
        public string HelpInfo => "Showing games";
        public bool IsSelected { get; set; }

        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<IMainMenuCommand> _graphicMenu { get; set; }
        private MenuManager<IMainMenuCommand> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<IMainMenuCommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<IMainMenuCommand>());
        public GraphicMenu<IMainMenuCommand> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<IMainMenuCommand>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());

        public void Execute()
        {
            
            //TODO
            var tuple = new Tuple<int, int>(0, 0);

            var list = CommandManager<IMainMenuCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly())
                .GetAvaibleCommands();

            var commandsArray = MenuManager.GenerateCommandsArray(list,  4);

            try
            {
                while (ApplicationState.IsRunning)
                {
                    Console.Clear();
                    MenuManager.ExecuteMenuMove(commandsArray, tuple);
                    GraphicMenu.PrintMenu(commandsArray);
                    tuple = ArrowsHandling.GetValidHighligthMove(tuple.Item1, tuple.Item2, 4, 2, out var isExecution);
                    if (isExecution)
                    {
                        list.FirstOrDefault(c => c.IsSelected).Execute();
                    }
                }
            }
            catch (ExitException e)
            {
            }
            
        }
    }
}
