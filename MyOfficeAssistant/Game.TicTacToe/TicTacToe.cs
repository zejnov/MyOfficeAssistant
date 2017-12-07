namespace Game.TicTacToe
{
    public class TicTacToe
    {
        public void Run()
        {
            new GameOperations.GameProvider().Execute();
        }
    }
}
