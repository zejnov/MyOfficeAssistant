using System;
using System.Linq;
using Game.TTTProvider.Configuration;
using Game.TTTProvider.Models;

namespace Game.TTTProvider.TheGame
{
    public class BoardManager
    {
        private readonly string[] _alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private ConfigurationModel _config;

        public BoardManager(ConfigurationFile getInstance)
        {
            _config = getInstance.GetCurrentConfig();
        }

        public void PrintBoard(string[][] gameRecord)
        {
            Console.Clear();
            PrintHeader();      //printing game info
            PrintUpperEdge();   //printing letters
            PrintField(gameRecord);       //printing game field
        }
        
        private void PrintField(string[][] gameRecord)
        {
            Console.WriteLine("");

            for (int i = 0; i < _config.BoardSize; i++)
            {
                Console.Write($"\n{i} ");

                for (int j = 0; j < _config.BoardSize; j++)
                {
                    Console.Write($" {gameRecord[i][j]} ");
                }

                Console.WriteLine("");
            }
        }

        private void PrintUpperEdge()
        {
            Console.Write("  ");
            for (int i = 0; i < _config.BoardSize; i++)
            {
                Console.Write($" {_alphabet[i]} ");
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine("Tic Tac Toe - The Great Game :D\n");
        }

        public void PrintBottom(IPlayer[] players, bool playerTurn)
        {
            var player = playerTurn ? players[0] : players[1];

            Console.WriteLine("");
            Console.Write($"{player.Name} [{player.Symbol}] - pick the box:");
        }

        public bool CheckPick(string pick)
        {
            if (pick.Length != 2)
            {
                Console.WriteLine("Coordinates should have 2 positions");
                return false;
            }

            var firstCoordinate = pick[0];
            var secondCoordinate = pick[1];

            return FirstOk(firstCoordinate) && SecondOk(secondCoordinate);
        }

        private bool FirstOk(char firstCoordinate)
        {
            var coordinate = firstCoordinate.ToString().ToUpper();
            var alphabet = _alphabet.Take(_config.BoardSize);

            if (alphabet.Contains(coordinate))
            {
                return true;
            }

            Console.WriteLine("First coordinate is wrong");
            return false;
        }

        private bool SecondOk(char secondCoordinate)
        {
            int coordinate;

            try
            {
                coordinate = Int32.Parse(secondCoordinate.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Second coordinate should be number");
                return false;
            }
            
            if (coordinate >= 0 && coordinate < _config.BoardSize)
            {
                return true;
            }
            Console.WriteLine("Second coordinate too large. ");
            return false;
        }

        public int[] ResolvePick(char[] pick)
        {
            int first = MyCheckingMachine(pick[0]);
            var second = Int32.Parse(pick[1].ToString());

            return new[] {first, second};
        }

        private int MyCheckingMachine(char c)
        {
            var counter = 0;
            while (_alphabet[counter] != c.ToString().ToUpper())
            {
                counter++;
            }
            return counter;
        }

        public bool CheckCoordinates(int[] coordinates, string[][] gameRecord)
        {
            return gameRecord[coordinates[1]][coordinates[0]] == "_";
        }

        public void PrintWinner(IPlayer[] players, bool playerTurn)
        {
            var player = playerTurn ? players[0] : players[1];

            Console.WriteLine("");
            Console.Write($"{player.Name} [{player.Symbol}] - won the game!");
            Console.ReadKey();
        }
    }
}
