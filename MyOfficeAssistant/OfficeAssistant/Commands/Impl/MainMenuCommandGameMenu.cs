using System;
using System.Linq;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Domain;

namespace OfficeAssistant.Commands.Impl
{
    public class MainMenuCommandGameMenu : IMainMenuCommand
    {
        public string Name => "GameMenu";
        public int Ordinal => 50;
        public string Command => "g";
        public string HelpInfo => "Doing sample stuff";
        public bool IsHighlighted { get; set; }

        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<IMainMenuCommand> _graphicMenu { get; set; }
        private MenuManager<IMainMenuCommand> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<IMainMenuCommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<IMainMenuCommand>());
        public GraphicMenu<IMainMenuCommand> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<IMainMenuCommand>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());

        public void Execute()
        {
            var tuple = new Tuple<int, int>(0, 0);

            var list = CommandManager<IMainMenuCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly())
                .GetAvaibleCommands();

            var commandsArray = MenuManager.GenerateCommandsArray(list,  4);
            
            while (ApplicationState.IsRunning)
            {
                Console.Clear();
                MenuManager.ExecuteMenuMove(commandsArray, tuple);
                GraphicMenu.PrintMenu(commandsArray);
                tuple = ArrowsHandling.GetValidHighligthMove(tuple.Item1, tuple.Item2, 4, 2, out var isExecution);
                if (isExecution)
                {
                    list.FirstOrDefault(c => c.IsHighlighted).Execute();
                }
            }
        }
    }
}
