using Game.TicTacToe.CommandManagement.Commands;
using Game.TicTacToe.IoHelpers;

namespace Game.TicTacToe.Commands
{
    class Help : IGameCommand
    {
        public string DisplayName => "Help";
        public int Ordinal => 888;
        public string Command => DisplayName;
        public string HelpInfo => "Printing help informations";
        public void Execute()
        {
            WriteHelper.PrintAvaibleCommandsHelp();
        }
    }
}
