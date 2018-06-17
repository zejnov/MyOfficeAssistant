using Game.GuessGame;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands.Impl
{
    public class MainMenuCommandGuessGame : IMainMenuCommand
    {
        public string DisplayName => "GuessGame";
        public int Ordinal => 101;
        public string Command => "GG";
        public string HelpInfo => "Play Guess Game";
        public bool IsSelected { get; set; }
        
        public void Execute()
        {
            var gameExecutor = new GameExecutor();
            gameExecutor.Play(new GuessGame());

        }
    }
}
