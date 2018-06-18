using System;
using System.Collections.Generic;
using System.Linq;
using Component.Service.CommandsManager.Interfaces;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;

namespace InteractiveGraphicMenu
{
    public class Menu<T> where T : class, ISelected, IBaseCommand
    {
        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<T> _graphicMenu { get; set; }
        private MenuManager<T> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<T> MenuManager => _menuManager ?? (_menuManager = new MenuManager<T>());
        public GraphicMenu<T> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<T>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());
        
        public void Invoke(List<T> list, bool isRunning = true)
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
                    list.FirstOrDefault(c => c.IsSelected)?.Execute();
                    //todo use Command Manager Execution
                }

            } while (isRunning);
        }
    }
}
