using System;

namespace Framework.OfficeAssistant.Commands.Impl
{
    internal class CommandExit : ICommand
    {
        public string Name => "Exit";
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}