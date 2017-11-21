using System.Linq;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    internal class CommandHelp : ICommand
    {
        public string Name => "Help";
        public string HelpInfo => "Printing help informatiosn";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            var commands = CommandManager.GetInstance().GetAvaibleCommands().ToList();
            Write.PrintAvaibleCommandsHelp(commands);
        }
    }
}
