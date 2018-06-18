﻿using Game.TTTProvider.TheGame;

namespace Game.TicTacToe.Commands
{
    class One : IGameCommand
    {
        public string DisplayName => "One"; //Play
        public bool IsSelected { get; set; }
        public int Ordinal => 1;
        public string Command => DisplayName;
        public string HelpInfo => "Game for One vs AI";
        public void Execute()
        {
            new GameTicTacToe().Run(true);
        }
    }
}
