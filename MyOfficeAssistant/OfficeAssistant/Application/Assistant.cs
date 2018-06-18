using System;
using Component.Service.CommandsManager;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.ConsoleHelper;
using OfficeAssistant.Core.Exception;
using OfficeAssistant.Core.State;
using Write = OfficeAssistant.ConsoleHelper.Write;

namespace OfficeAssistant.Application
{
    public class Assistant
    {
        public bool IsRunning { get; set; }
        private static Assistant _officeAssistant { get; set; }
        private readonly CommandManager<IMainMenuCommand> _commandManager = CommandManager<IMainMenuCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly());
      
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
            catch(ExitException){}
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
                throw;
            }
        }

        private void ExternalMenu()
        {
            var commands = _commandManager
                .GetAvaibleCommands();

            new Menu<IMainMenuCommand>().Invoke(commands, ApplicationState.IsRunning);
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
