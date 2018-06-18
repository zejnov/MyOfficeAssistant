using Game.TicTacToe.IoHelpers;

namespace Game.TicTacToe.Commands
{
    class Help : IGameCommand
    {
        public string DisplayName => "Help";
        public bool IsSelected { get; set; }
        public int Ordinal => 888;
        public string Command => DisplayName;
        public string HelpInfo => "Printing help informations";
        public void Execute()
        {
            WriteHelper.PrintAvaibleCommandsHelp();
        }
    }
}
