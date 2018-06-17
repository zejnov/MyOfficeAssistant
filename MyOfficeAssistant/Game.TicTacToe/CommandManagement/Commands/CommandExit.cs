using System;

namespace Game.TicTacToe.CommandManagement.Commands
{
    public class CommandExit : IGameCommand
    {
        public string Name => "Exit";
        public int Ordinal => 999;
        public string Command => Name;
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
