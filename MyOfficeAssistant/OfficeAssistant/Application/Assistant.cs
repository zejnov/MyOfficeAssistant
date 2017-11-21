using System;
using System.Collections.Generic;
using System.Linq;
using OfficeAssistant.Commands;
using OfficeAssistant.ConsoleHelper;
using OfficeAssistant.Domain;

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
            do
            {
                try
                {
                    SimpleMenu();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    //throw;
                }
            } while (ApplicationState.IsRunning);
        }

        private void SimpleMenu()
        {
            var commands = _commandManager.GetAvaibleCommandNames();
            Write.Commands(commands);

            var choosenCommand = Read.GetCommandFromuser(commands);
            Console.WriteLine($"{choosenCommand} <- selected"); //todo temp

            _commandManager.Execute(choosenCommand);
            //Read.Wait();
        }
    }
}
