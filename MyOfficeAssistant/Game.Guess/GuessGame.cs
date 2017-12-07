using System;

namespace Game.GuessGame
{
    public class GuessGame : IGame
    {
        public string Name { get; } = "Guess Game";
        public int Score { get; set; }
        
        public void Play()
        {
            bool guessed = false;
            int randomValue = GetRandomNumber();
            int userValue = 0;

            while (!guessed)
            {
                userValue = GetValueFromUser();
                IncreaseScore();

                if (userValue == randomValue)
                {
                    guessed = true;
                }

                if (userValue < randomValue)
                {
                    Console.WriteLine("Given number is too low");
                }
                if (userValue > randomValue)
                {
                    Console.WriteLine("Given number is too big");
                }
            }
        }

        public void ResetScore()
        {
            Score = 0;
        }

        public void IncreaseScore()
        {
            Score++;
        }

        private int GetValueFromUser()
        {
            int value = 0;
            bool inRange = false;

            while (!inRange)
            {
                try
                {
                    value = Int32.Parse(Console.ReadLine());

                    if (value >= 0 && value <= 1000)
                    {
                        inRange = true;
                    }
                    else
                    {
                        Console.WriteLine("Out of rangne, please try <0,1000>");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bad entry, please try again");
                }
            }
            return value;

        }

        private int GetRandomNumber()
        {
            var random = new Random(DateTime.Now.Millisecond);

            return random.Next(1000);
        }

    }
}
