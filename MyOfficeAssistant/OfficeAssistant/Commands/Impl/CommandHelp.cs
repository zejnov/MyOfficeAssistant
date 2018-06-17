using Component.Service.CommandsManager;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    internal class CommandHelp : ICommand
    {
        public string Name => "Help";
        public int Ordinal => 888;
        public string Command => Name;
        public string HelpInfo => "Printing help informatiosn";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            var commands = CommandManager<ICommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).GetAvaibleCommands();
            Write.PrintAvaibleCommandsHelp(commands);
        }
    }
}
