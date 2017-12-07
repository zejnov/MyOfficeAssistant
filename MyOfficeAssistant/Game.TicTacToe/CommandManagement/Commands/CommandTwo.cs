using Game.TTTProvider.TheGame;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandTwo : IMyCommand
    {
        public string Name => "Two"; //Play
        public string HelpInfo => "Game for Two";
        public void Execute()
        {
            new GameTicTacToe().Run(false);
        }
    }
}
