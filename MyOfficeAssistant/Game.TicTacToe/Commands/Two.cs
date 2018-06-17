using Game.TicTacToe.CommandManagement.Commands;
using Game.TTTProvider.TheGame;

namespace Game.TicTacToe.Commands
{
    class Two : IGameCommand
    {
        public string DisplayName => "Two"; //Play
        public int Ordinal => 2;
        public string Command => DisplayName;
        public string HelpInfo => "Game for Two";
        public void Execute()
        {
            new GameTicTacToe().Run(false);
        }
    }
}
