using Game.TicTacToe.IoHelpers;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandHelp : IGameCommand
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
