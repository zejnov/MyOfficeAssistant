using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;

namespace InteractiveGraphicMenu
{
    public class Menu
    {
        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<ICommand> _graphicMenu { get; set; }
        private MenuManager<ICommand> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<ICommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<ICommand>());
        public GraphicMenu<ICommand> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<ICommand>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());
        
        public void Invoke(List<ICommand> list, bool IsRunning = true)
        {
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
