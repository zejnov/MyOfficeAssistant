using InteractiveGraphicMenu;
using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Application;

namespace OfficeAssistant.Commands.Impl
{
    internal class CommandMaras : ICommand
    {
        public string Name => "aMaras";
        public string Command => "a";
        public string HelpInfo => "Maras stuff";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            //new Maras().Run();
            new Maras2().Run();
        }
    }
}