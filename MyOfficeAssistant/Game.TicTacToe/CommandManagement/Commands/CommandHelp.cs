using Game.TicTacToe.IoHelpers;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandHelp : IMyCommand
    {
        public string Name => "Help";
        public string HelpInfo => "Printing help informations";
        public void Execute()
        {
            WriteHelper.PrintAvaibleCommandsHelp();
        }
    }
}
