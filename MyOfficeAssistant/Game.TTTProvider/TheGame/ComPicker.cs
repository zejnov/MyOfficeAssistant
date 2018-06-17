using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Game.TTTProvider.Configuration;
using Game.TTTProvider.Models;

namespace Game.TTTProvider.TheGame
{
    public class ComPicker
    {
        private readonly ConfigurationModel _config = ConfigurationFile.GetInstance().GetCurrentConfig();
        private readonly string[][] _gameRecord;
        private int[] _pick = new int[2];
        private List<MyPick> _picksAvaible = new List<MyPick>();
        private const string _emptySymbol = "_";
        private int _counter = 0; //just for observe sth... 

        public ComPicker(string[][] gameRecord)
        {
            _gameRecord = gameRecord;
        }

        public int[] Pick(IPlayer[] players)
        {
            /*
            GENERAL COMMENTS
            TODO: 
            - TASKS - separate task for each searching (Improvement?) (Add timeStamp)
            if picks avaible is over some number, and all search was made at least one, stop searching and pick
            */
            GetValuedPick(players);                 //assigning pick to _pick
            return ComputerPick();                  //returning field _pick, as a 'best' pick choosen
        }

        private void GetValuedPick(IPlayer[] players)
        {
            var searchSize = _config.WinningNumber;
            var playerSymbol = players[0].Symbol.ToString();
            var computerSymbol = players[1].Symbol.ToString();

            _picksAvaible.Clear();                  //just to be sure
            
            for (int i = searchSize; i > 1; i--)    // search
            {
                TryToWin(i, computerSymbol);
                TryNotLose(i, playerSymbol);
            }

            if (TryResolvePick()) return;           // resolve
            GetFreePick();
        }

        public void TryToWin(int i, string computerSymbol)
        {
            SearchHorizontal(i, computerSymbol, isTryToWin:true);
            SearchVertical(i, computerSymbol, isTryToWin: true);
            SearchDiagonal(i, computerSymbol, isTryToWin: true);
        }

        public void TryNotLose(int i, string playerSymbol)
        {
            SearchHorizontal(i, playerSymbol, isTryToWin: false);
            SearchVertical(i, playerSymbol, isTryToWin: false);
            SearchDiagonal(i, playerSymbol, isTryToWin: false);
        }

        private void SearchHorizontal(int sequence, string symbol, bool isTryToWin)
        {
            for (int i = 0; i < _config.BoardSize; i++)
            {
                int matches = 0;
                int symbolHits = 0;     //to increase the value of pick
                var thisList = new List<MyPick>();

                for (int j = 0; j < _config.BoardSize; j++)
                {
                    if (_gameRecord[i][j] == _emptySymbol || _gameRecord[i][j] == symbol) //searching for 'matching' sequence
                    {
                        if (_gameRecord[i][j] == _emptySymbol)
                        {
                            var pick = GenerateAvaiblePick(i, j, sequence, isTryToWin);
                            thisList.Add(pick);
                        }
                        else
                        {
                            symbolHits++;
                        }
                        matches++;
                    }
                    else
                    {
                        matches = 0;
                        symbolHits = 0;
                        thisList.Clear();
                    }

                    if (matches >= sequence) 
                    {
                        thisList.ForEach(p => p.Improtance += symbolHits);
                        _picksAvaible.AddRange(thisList);
                    }
                }
            }
        }

        private void SearchVertical(int sequence, string symbol, bool isTryToWin)
        {
            for (int i = 0; i < _config.BoardSize; i++)
            {
                int matches = 0;
                int symbolHits = 0;     //to increase the value of pick
                var thisList = new List<MyPick>();

                for (int j = 0; j < _config.BoardSize; j++)
                {
                    if (_gameRecord[j][i] == _emptySymbol || _gameRecord[j][i] == symbol) //searching for 'matching' sequence
                    {
                        if (_gameRecord[j][i] == _emptySymbol)
                        {
                            var pick = GenerateAvaiblePick(j, i, sequence, isTryToWin);
                            thisList.Add(pick);
                        }
                        else
                        {
                            symbolHits++;
                        }
                        matches++;
                    }
                    else
                    {
                        matches = 0;
                        symbolHits = 0;
                        thisList.Clear();
                    }
                    if (matches >= sequence)
                    {
                        thisList.ForEach(p => p.Improtance += symbolHits);
                        _picksAvaible.AddRange(thisList);
                    }
                }
            }
        }

        private void SearchDiagonal(int sequence, string symbol, bool isTryToWin)
        {
            //TODO diagonals
        }

        private bool TryResolvePick()
        {
            //TODO check resolving with 'no lose'

            if (_picksAvaible == null) return false;

            var pickToWin = _picksAvaible
                .OrderByDescending(p => p.Improtance)
                .FirstOrDefault(p => p.IsTryToWin);
            var pickToNotLose = _picksAvaible
                .OrderByDescending(p => p.Improtance)
                .FirstOrDefault(p => !p.IsTryToWin);

            if (pickToWin != null && pickToNotLose != null)         //operating on both
            {
                if (pickToWin.Improtance >= pickToNotLose.Improtance)
                {
                    AssignPick(pickToWin);
                    return true;
                }
                AssignPick(pickToNotLose);
                return true;
            }
            
            if (pickToNotLose == null && pickToWin != null)         //to win
            {
                AssignPick(pickToWin);
                return true;
            }
            if (pickToNotLose != null)                              //to not lose
            {
                AssignPick(pickToNotLose);
                return true;
            }
            return false;                                           //no pick found
        }

        private MyPick GenerateAvaiblePick(int i, int j, int sequence, bool isTryToWin)
        {
            //validate pick?
            _counter++;
            return new MyPick()
            {
                Id = _counter,
                Improtance = sequence,
                IsTryToWin = isTryToWin,
                Pick = new[] {i, j}
            };
        }

        private void GetFreePick()
        {
            var freeSlots = new List<int[]>();

            for (int i = 0; i < _config.BoardSize; i++)
            {
                for (int j = 0; j < _config.BoardSize; j++)
                {
                    if (_gameRecord[i][j] == _emptySymbol)
                    {
                        freeSlots.Add(new []{i,j});
                    }
                }
            }
            GetRandomPick(freeSlots);
        }

        private void GetRandomPick(List<int[]> freeSlots)
        {
            var randomPick = new Random().Next(0, freeSlots.Count - 1);
            _pick = freeSlots[randomPick];
        }

        private void AssignPick(MyPick pick)
        {
            _pick[0] = pick.Pick[0];
            _pick[1] = pick.Pick[1];
        }

        private int[] ComputerPick()
        {
            Thread.Sleep(333);                          //just to not happen immediately
            return new[] { _pick[1], _pick[0] };        //iverted, because human enter 'B1' -> row/line, we use line/row
        }
    }
}
