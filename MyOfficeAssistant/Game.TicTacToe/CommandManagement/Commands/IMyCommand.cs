using System;

namespace Game.TicTacToe.CommandManagement.Commands
{
    public interface IMyCommand 
    {
        String Name { get; }
        String HelpInfo { get; }
        void Execute();
    }
}
