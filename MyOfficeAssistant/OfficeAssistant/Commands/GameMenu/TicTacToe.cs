using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.GameMenu
{
    public class TicTacToe : IGameMenuCommand
    {
        public string DisplayName => "TicTacToe";
        public int Ordinal => 444;
        public string Command => "TTT";
        public string HelpInfo => "Play TicTacToe";
        public bool IsSelected { get; set; }

        public void Execute()
        {
            new Game.TicTacToe.TicTacToe().Run();
        }
    }
}
