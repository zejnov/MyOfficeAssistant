using Game.TTTProvider.TheGame;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandOne : IGameCommand
    {
        public string DisplayName => "One"; //Play
        public int Ordinal => 1;
        public string Command => DisplayName;
        public string HelpInfo => "Game for One vs AI";
        public void Execute()
        {
            new GameTicTacToe().Run(true);
        }
    }
}
