using Game.TicTacToe.CommandManagement.Commands;
using OfficeAssistant.Core.Exception;

namespace Game.TicTacToe.Commands
{
    public class Exit : IGameCommand
    {
        public string DisplayName => "Exit";
        public int Ordinal => 999;
        public string Command => DisplayName;
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            throw new ExitException();
        }
    }
}
