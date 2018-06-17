namespace Game.GuessGame
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                var gameExecutor = new GameExecutor();
                gameExecutor.Play(new GuessGame());
            }
        }
    }
}
