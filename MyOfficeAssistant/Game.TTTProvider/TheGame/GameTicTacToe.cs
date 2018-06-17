using System;
using System.Threading;
using Game.TTTProvider.Configuration;
using Game.TTTProvider.Models;

namespace Game.TTTProvider.TheGame
{
    public class GameTicTacToe
    {
        private static readonly ConfigurationFile _configuration = ConfigurationFile.GetInstance();
        private readonly BoardManager _board = new BoardManager(_configuration);
        private readonly GameHelper _gameHelper = new GameHelper();
        private string[][] _gameRecord;
        private IPlayer[] _players = new IPlayer[2];
        private bool _playerTurn = true;
        private bool _endGame = false;

        /// <summary>
        /// ctor, generating game table
        /// </summary>
        public GameTicTacToe()
        {
            _gameRecord = _gameHelper.CreateGameRecordTable();
        }
        
        /// <summary>
        /// running game
        /// </summary>
        public void Run(bool artifcialIntelligence)
        {
            InitializePlayers(artifcialIntelligence);
            PrintPlayers();
            Console.ReadKey();
            //****************Main game body*********************//
            var rounds = 0;
            do
            {
                rounds++;
                _board.PrintBoard(_gameRecord);
                
                if (_gameHelper.CheckBoard(_gameRecord, _players))
                {   //if player get win number in row
                    _endGame = true;
                    _board.PrintWinner(_players, !_playerTurn);
                }
                else
                { 
                    if (rounds > _configuration.GetCurrentConfig().BoardSize * _configuration.GetCurrentConfig().BoardSize)
                    {   //if board is full with no winner
                        _endGame = true;
                        Console.WriteLine("\n\n SPLIT! \n");
                        Console.ReadKey();
                    }
                    else
                    {   //ticking tacking toeing
                        _board.PrintBottom(_players, _playerTurn);
                        GetPlayerPick(artifcialIntelligence && !_playerTurn);
                        _playerTurn = !_playerTurn; //switching turns
                    }
                }
            } while (!_endGame);
        }

        /// <summary>
        /// Resolving picking for human or AI
        /// </summary>
        private void GetPlayerPick(bool aI)
        {
            var pick = aI ? GetAiPick() : GetPick();
            EnterPick(pick);
        }

        /// <summary>
        /// Entering pick on game board
        /// </summary>
        private void EnterPick(int[] pick)
        {
            var player = _playerTurn ? _players[0] : _players[1];
            _gameRecord[pick[1]][pick[0]] = player.Symbol.ToString();
        }

        /// <summary>
        /// Getting pick from AI algorithm...
        /// </summary>
        private int[] GetAiPick()
        {
            Thread.Sleep(1);
            return new ComPicker(_gameRecord).Pick(_players);
        }

        /// <summary>
        /// Getting pick from human user
        /// </summary>
        private int[] GetPick()
        {
            int[] coordinates = null;
            var pickOk = false;
            do
            {
                var pick = Console.ReadLine();

                if (_board.CheckPick(pick))
                {
                    coordinates = _board.ResolvePick(pick?.ToCharArray());
                    if (_board.CheckCoordinates(coordinates, _gameRecord))
                    {
                        pickOk = true;
                    }
                    else
                    {
                        Console.WriteLine("Box already picked!");
                        Console.Write("Pick again: ");
                    }
                }
                else
                {
                    Console.Write("Pick again: ");
                }
            } while (!pickOk);
            return new []{coordinates[0],coordinates[1]};
        }

        /// <summary>
        /// Initialazing players
        /// </summary>
        private void InitializePlayers(bool artifcialIntelligence)
        {
            _players[0] = _gameHelper.CreatePlayer($"{Environment.UserName}", 'O');

            if (artifcialIntelligence)
            {
                _players[1] = _gameHelper.CreatePlayer("ArtI", 'X');
            }
            else
            {
                //todo ... ADD ... get user name
                _players[1] = _gameHelper.CreatePlayer("Player_2", 'X');
            }
        }

        /// <summary>
        /// printing players in game
        /// </summary>
        private void PrintPlayers()
        {
            Console.WriteLine("Players in this game:\n");

            foreach (var player in _players)
            {
                Console.WriteLine($"{player.Name} - {player.Symbol}");
            }
        }
    }
}
