using Game.TicTacToe.IoHelpers;
using Game.TTTProvider.Configuration;

namespace Game.TicTacToe.CommandManagement.Commands
{
    class CommandSet : IGameCommand
    {
        public string DisplayName => "Set"; //Play
        public int Ordinal => 5;
        public string Command => DisplayName;
        public string HelpInfo => "Set game parameters";
        public void Execute()
        {
            var config = ReadHelper.GetNewConfig();
            ConfigurationFile.GetInstance().SetNewConfiguration(config);
        }
    }
}
