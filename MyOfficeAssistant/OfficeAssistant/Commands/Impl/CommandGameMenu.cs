using System;
using System.Linq;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandGameMenu : ICommand
    {
        public string Name => "GameMenu";
        public string Command => "g";
        public string HelpInfo => "Doing sample stuff";
        public bool IsHighlighted { get; set; }

        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu _graphicMenu { get; set; }
        private MenuManager _menuManager { get; set; }

        public MenuManager MenuManager => _menuManager ?? (_menuManager = new MenuManager());
        public GraphicMenu GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());

        public void Execute()
        {
            var tuple = new Tuple<int, int>(0, 0);

            var list = CommandManager.GetInstance()
                .GetAvaibleCommands()
                .OrderBy(c => c.Name)
                .ToList();

            var commandsArray = MenuManager.GenerateCommandsArray(list,  4);
            
            while (true)
            {
                Console.Clear();
                MenuManager.ExecuteMenuMove(commandsArray, tuple);
                GraphicMenu.PrintMenu(commandsArray);
                tuple = ArrowsHandling.GetValidHighligthMove(tuple.Item1, tuple.Item2, 4, 2);
            }
        }
    }
}
