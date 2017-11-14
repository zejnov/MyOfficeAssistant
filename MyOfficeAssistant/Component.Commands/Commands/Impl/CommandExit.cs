using System;

namespace AppCommands.Commands.Impl
{
    internal class CommandExit : ICommand
    {
        public string Name => "Exit";
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            Environment.Exit(0);
            Framework.OfficeAssistant.Domain.Ap
                
        }
    }
}