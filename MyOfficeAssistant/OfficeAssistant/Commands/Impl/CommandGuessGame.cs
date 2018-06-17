using Game.GuessGame;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandGuessGame : ICommand
    {
        public string Name => "GuessGame";
        public int Ordinal => 101;
        public string Command => "GG";
        public string HelpInfo => "Play Guess Game";
        public bool IsHighlighted { get; set; }
        
        public void Execute()
        {
            var gameExecutor = new GameExecutor();
            gameExecutor.Play(new GuessGame());

        }
    }
}
