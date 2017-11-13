using System;
using OfficeAssistant.Commands;
using OfficeAssistant.ConsoleHelper;
using OfficeAssistant.Domain;
using OfficeAssistant.Extensions;

namespace OfficeAssistant.Application
{
    public class Assistant
    {
        public ApplicationState AppState { get; set; }
        public bool IsRunning { get; set; }
        private static Assistant _officeAssistant { get; set; }
        private readonly CommandManager _commandManager = CommandManager.GetInstance();

        public static Assistant GetInstance()
        {
            return _officeAssistant ?? (_officeAssistant = new Assistant());
        }

        public Assistant()
        {
            if (AppState != null) return;
            AppState = new ApplicationState();
            AppState.SetToRunning();
            IsRunning = true;
        }

        public void Run()
        {
            do
            {
                try
                {
                    SimpleMenu();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            } while (IsRunning);
        }

        private void SimpleMenu()
        {
            var commands = _commandManager.GetAvaibleCommandNames();
            Write.Commands(commands);

            var choosenCommand = Read.GetCommandFromuser(commands);
            Console.WriteLine($"{choosenCommand} <- selected"); //todo temp

            _commandManager.Execute(choosenCommand);
            Read.Wait();
        }
    }
}
