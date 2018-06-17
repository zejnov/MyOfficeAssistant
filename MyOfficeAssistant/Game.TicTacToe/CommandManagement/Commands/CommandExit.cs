using System;

namespace Game.TicTacToe.CommandManagement.Commands
{
    public class CommandExit : IGameCommand
    {
        public string DisplayName => "Exit";
        public int Ordinal => 999;
        public string Command => DisplayName;
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
