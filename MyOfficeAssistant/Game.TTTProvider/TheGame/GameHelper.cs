using Game.TTTProvider.Configuration;
using Game.TTTProvider.Models;

namespace Game.TTTProvider.TheGame
{
    public class GameHelper
    {
        private static readonly ConfigurationFile _configuration = ConfigurationFile.GetInstance();
        
        public Player CreatePlayer(string name, char symbol)
        {
            return new Player()
            {
                Name = name,
                Symbol = symbol
            };
        }

        public string[][] CreateGameRecordTable()
        {
            var size = _configuration.GetCurrentConfig().BoardSize;
            string[][] resultTable = new string[size][];
            for (int i = 0; i < size; i++)
            {
                resultTable[i] = new string[size];

                for (int j = 0; j < size; j++)      //********//
                {
                    resultTable[i][j] = "_";        
                }
            }
            return resultTable;
        }

        public bool CheckBoard(string[][] gameRecord, IPlayer[] players)
        {
            var check = false;
            foreach (var player in players)
            {
                check |= CheckHorizontal(gameRecord, player.Symbol.ToString());
                check |= CheckVertical(gameRecord, player.Symbol.ToString());
                check |= CheckDiagonal(gameRecord, player.Symbol.ToString());
            }
            return check;
        }

        private bool CheckHorizontal(string[][] gameRecord, string playerSymbol)
        {
            for (int i = 0; i < _configuration.GetCurrentConfig().BoardSize; i++)
            {
                var hit = 0;

                for (int j = 0; j < _configuration.GetCurrentConfig().BoardSize; j++)
                {
                    if (gameRecord[i][j] == playerSymbol)
                    {
                        hit++;
                    }
                    else
                    {
                        hit = 0;
                    }

                    if (hit >= _configuration.GetCurrentConfig().WinningNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckVertical(string[][] gameRecord, string playerSymbol)
        {
            for (int i = 0; i < _configuration.GetCurrentConfig().BoardSize; i++)
            {
                var hit = 0;

                for (int j = 0; j < _configuration.GetCurrentConfig().BoardSize; j++)
                {
                    if (gameRecord[j][i] == playerSymbol)
                    {
                        hit++;
                    }
                    else
                    {
                        hit = 0;
                    }

                    if (hit >= _configuration.GetCurrentConfig().WinningNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDiagonal(string[][] gameRecord, string playerSymbol)
        {
            var size = _configuration.GetCurrentConfig().BoardSize;
            var number = _configuration.GetCurrentConfig().WinningNumber;
            int hit;
            ////**********************  \  **************************////
            
            //diagonal and under '\' 
            hit = 0;
            for (int j = 0; j <= size - number; j++) //j=0 - diagonal
            {
                for (int i = 0; i < size - j; i++)
                {
                    if (gameRecord[i + j][i] == playerSymbol)
                    {
                        hit++;
                    }
                    else
                    {
                        hit = 0;
                    }

                    if (hit >= number)
                    {
                        return true;
                    }
                }
            }

            //above diagonal '\'
            hit = 0;
            for (int j = 1; j <= size - number; j++)
            {
                for (int i = 0; i < size - j; i++)
                {
                    if (gameRecord[i][i + j] == playerSymbol)
                    {
                        hit++;
                    }
                    else
                    {
                        hit = 0;
                    }

                    if (hit >= number)
                    {
                        return true;
                    }
                }
            }

            ////**********************  /  **************************////
            //under and diagonal '/'
            hit = 0;
            for (int j = 0; j <= size - number; j++)
            {
                for (int i = 0; i < size - j; i++)
                {
                    if (gameRecord[i + j][size - 1 - i] == playerSymbol)
                    {
                        hit++;
                    }
                    else
                    {
                        hit = 0;
                    }

                    if (hit >= number)
                    {
                        return true;
                    }
                }
            }

            //above diagonal '/'
            hit = 0;
            for (int j = 1; j <= size - number; j++)
            {
                for (int i = 0; i < size - j; i++)
                {
                    if (gameRecord[i][size - 1 - i - j] == playerSymbol)
                    {
                        hit++;
                    }
                    else
                    {
                        hit = 0;
                    }

                    if (hit >= number)
                    {
                        return true;
                    }
                }
            }
                return false;
        }
    }
}
