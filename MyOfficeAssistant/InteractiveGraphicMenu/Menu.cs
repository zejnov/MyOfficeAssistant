using System;
using System.Collections.Generic;
using System.Linq;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;

namespace InteractiveGraphicMenu
{
    public class Menu
    {
        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<IMainMenuCommand> _graphicMenu { get; set; }
        private MenuManager<IMainMenuCommand> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<IMainMenuCommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<IMainMenuCommand>());
        public GraphicMenu<IMainMenuCommand> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<IMainMenuCommand>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());
        
        public void Invoke(List<IMainMenuCommand> list, bool IsRunning = true)
        {
            if (list.Count == 0)
                return;
            
            var tuple = new Tuple<int, int>(0, 0);

            var commandsArray = MenuManager.GenerateCommandsArray(list, 4);
            do
            {
                Console.Clear();
                MenuManager.ExecuteMenuMove(commandsArray, tuple);
                GraphicMenu.PrintMenu(commandsArray);
                tuple = ArrowsHandling.GetValidHighligthMove(tuple.Item1, tuple.Item2, 4, 2, out var isExecution);
                if (isExecution)
                {
                    list.FirstOrDefault(c => c.IsHighlighted)?.Execute();
                }

            } while (IsRunning);
        }
    }
}
