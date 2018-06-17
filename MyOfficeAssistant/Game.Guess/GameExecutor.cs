using System;

namespace Game.GuessGame
{
    public class GameExecutor
    {
        public void Play(IGame game)
        {
            Console.WriteLine("You play " + game.Name + " game!");
            game.Play();
            Console.WriteLine("You scored " + game.Score + " points");
            Console.ReadKey(false);
            game.ResetScore();
        }
    }
}
