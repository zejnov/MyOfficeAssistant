using Game.TTTProvider.TheGame;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandTwo : IGameCommand
    {
        public string Name => "Two"; //Play
        public int Ordinal => 2;
        public string Command => Name;
        public string HelpInfo => "Game for Two";
        public void Execute()
        {
            new GameTicTacToe().Run(false);
        }
    }
}
