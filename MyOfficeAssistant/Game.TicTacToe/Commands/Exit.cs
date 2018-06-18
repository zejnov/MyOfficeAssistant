using OfficeAssistant.Core.Exception;

namespace Game.TicTacToe.Commands
{
    public class Exit : IGameCommand
    {
        public string DisplayName => "Exit";
        public bool IsSelected { get; set; }
        public int Ordinal => 999;
        public string Command => DisplayName;
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            throw new ExitException();
        }
    }
}
