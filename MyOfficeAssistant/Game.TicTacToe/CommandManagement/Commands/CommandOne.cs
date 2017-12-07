using Game.TTTProvider.TheGame;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandOne : IMyCommand
    {
        public string Name => "One"; //Play
        public string HelpInfo => "Game for One vs AI";
        public void Execute()
        {
            new GameTicTacToe().Run(true);
        }
    }
}
