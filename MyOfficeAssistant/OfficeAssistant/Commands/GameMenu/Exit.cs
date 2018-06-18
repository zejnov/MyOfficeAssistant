using InteractiveGraphicMenu.Interfaces;
using OfficeAssistant.Core.Exception;

namespace OfficeAssistant.Commands.GameMenu
{
    internal class Exit : IGameMenuCommand
    {
        public string DisplayName => "Exit";
        public int Ordinal => 999;
        public string Command => DisplayName;
        public string HelpInfo => "Exit application";
        public bool IsSelected{get; set; }

        public void Execute()
        {
            throw new ExitException();
        }
    }
}