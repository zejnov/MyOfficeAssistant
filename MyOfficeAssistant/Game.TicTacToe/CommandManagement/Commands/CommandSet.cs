using Game.TicTacToe.IoHelpers;
using Game.TTTProvider.Configuration;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandSet : IMyCommand
    {
        public string Name => "Set"; //Play
        public string HelpInfo => "Set game parameters";
        public void Execute()
        {
            var config = ReadHelper.GetNewConfig();
            ConfigurationFile.GetInstance().SetNewConfiguration(config);
        }
    }
}
