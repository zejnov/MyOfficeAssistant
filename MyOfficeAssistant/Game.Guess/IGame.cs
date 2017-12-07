namespace Game.GuessGame
{
    public  interface IGame
    {
        string Name { get; }
        int Score { get; }

        void Play();
        void ResetScore();
    }
}
