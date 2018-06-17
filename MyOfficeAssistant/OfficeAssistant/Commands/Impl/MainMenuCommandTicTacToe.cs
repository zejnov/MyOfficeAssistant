using Game.TicTacToe;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.Impl
{
    public class MainMenuCommandTicTacToe : IMainMenuCommand
    {
        public string DisplayName => "TicTacToe";
        public int Ordinal => 444;
        public string Command => "TTT";
        public string HelpInfo => "Play TicTacToe";
        public bool IsSelected { get; set; }

        public void Execute()
        {
            new TicTacToe().Run();
        }
    }
}
