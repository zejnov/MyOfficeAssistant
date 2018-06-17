using Game.TicTacToe;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandTicTacToe : ICommand
    {
        public string Name => "TicTacToe";
        public int Ordinal => 444;
        public string Command => "TTT";
        public string HelpInfo => "Play TicTacToe";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            new TicTacToe().Run();
        }
    }
}
