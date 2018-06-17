using Component.Service.CommandsManager;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands
{
    internal class Help : IMainMenuCommand
    {
        public string DisplayName => "Help";
        public int Ordinal => 888;
        public string Command => DisplayName;
        public string HelpInfo => "Printing help informatiosn";
        public bool IsSelected { get; set; }

        public void Execute()
        {
            var commands = CommandManager<IMainMenuCommand>.GetInstance(System.Reflection.Assembly.GetExecutingAssembly()).GetAvaibleCommands();
            Write.PrintAvaibleCommandsHelp(commands);
        }
    }
}
