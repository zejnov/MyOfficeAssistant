using Game.TicTacToe.IoHelpers;
using Game.TTTProvider.Configuration;

namespace Game.TicTacToe.Commands
{
    class Set : IGameCommand
    {
        public string DisplayName => "Set"; //Play
        public bool IsSelected { get; set; }
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
