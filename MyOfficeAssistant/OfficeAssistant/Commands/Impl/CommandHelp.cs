using System.Linq;
using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    internal class CommandHelp : ICommand
    {
        public string Name => "Help";
        public string Command => Name;
        public string HelpInfo => "Printing help informatiosn";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            var commands = CommandManager.GetInstance().GetAvaibleCommands().ToList();
            Write.PrintAvaibleCommandsHelp(commands);
        }
    }
}
