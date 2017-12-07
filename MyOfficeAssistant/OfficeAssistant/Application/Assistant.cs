using System;
using System.Linq;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Helpers;
using OfficeAssistant.Commands;
using OfficeAssistant.ConsoleHelper;
using OfficeAssistant.Domain;
using Write = OfficeAssistant.ConsoleHelper.Write;

namespace OfficeAssistant.Application
{
    public class Assistant
    {
        public bool IsRunning { get; set; }
        private static Assistant _officeAssistant { get; set; }
        private readonly CommandManager _commandManager = CommandManager.GetInstance();
        private ArrowsHandling _arrowsHandling { get; set; }
        private GraphicMenu<ICommand> _graphicMenu { get; set; }
        private MenuManager<ICommand> _menuManager { get; set; }

        //for IoC in future
        public MenuManager<ICommand> MenuManager => _menuManager ?? (_menuManager = new MenuManager<ICommand>());
        public GraphicMenu<ICommand> GraphicMenu => _graphicMenu ?? (_graphicMenu = new GraphicMenu<ICommand>());
        public ArrowsHandling ArrowsHandling => _arrowsHandling ?? (_arrowsHandling = new ArrowsHandling());


        public static Assistant GetInstance()
        {
            return _officeAssistant ?? (_officeAssistant = new Assistant());
        }

        public Assistant()
        {
            ApplicationState.IsRunning = true;
        }

        public void Run()
        {
            try
            {
                //SimpleMenu();
                ExtraMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private void ExtraMenu()
        {
            var tuple = new Tuple<int, int>(0, 0);

            var list = _commandManager
                .GetAvaibleCommands()
                .OrderBy(c => c.Name)
                .ToList();

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
            } while (ApplicationState.IsRunning);
        }

        private void SimpleMenu()
        {
            do
            {
                var commands = _commandManager.GetAvaibleCommandNames();
                Write.Commands(commands);

                var choosenCommand = Read.GetCommandFromuser(commands);
                Console.WriteLine($"{choosenCommand} <- selected"); //todo temp

                _commandManager.Execute(choosenCommand);

            } while (ApplicationState.IsRunning);
        }
    }
}
