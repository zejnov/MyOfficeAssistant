using System;
using System.Linq;
using InteractiveGraphicMenu;
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
                ExternalMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private void ExternalMenu()
        {
            var list = _commandManager
                .GetAvaibleCommands()
                .OrderBy(c => c.Name)
                .ToList();

            new Menu().Invoke(list);
        }

        /// <summary>
        /// if sth broke
        /// </summary>
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
