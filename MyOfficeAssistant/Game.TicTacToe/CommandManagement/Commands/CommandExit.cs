using System;

namespace Game.TicTacToe.CommandManagement.Commands
{
    public class CommandExit : IMyCommand
    {
        public string Name => "Exit";
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
