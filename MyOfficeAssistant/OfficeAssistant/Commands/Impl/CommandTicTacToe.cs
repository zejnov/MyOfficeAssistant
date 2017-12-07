using Game.TicTacToe;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandTicTacToe : ICommand
    {
        public string Name => "TicTacToe";
        public string Command => "TTT";
        public string HelpInfo => "Play TicTacToe";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            new TicTacToe().Run();
        }
    }
}
