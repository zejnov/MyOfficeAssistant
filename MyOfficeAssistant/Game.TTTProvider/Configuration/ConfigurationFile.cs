namespace Game.TTTProvider.Configuration
{
    public class ConfigurationFile
    {
        private static ConfigurationFile _configFile;
        private static ConfigurationModel _configModel;
        
        public ConfigurationFile()
        {
            _configModel = new ConfigurationModel()
            {   //minimal initialization parameters
                BoardSize = 3,
                WinningNumber = 3,
            };
        }

        public static ConfigurationFile GetInstance()
        {
            return _configFile ?? (_configFile = new ConfigurationFile());
        }

        //public void SetNewConfig(ConfigurationModel model)
        //{
        //    _configModel.BoardSize = model.BoardSize;
        //    _configModel.WinningNumber = model.WinningNumber;
        //}

        public ConfigurationModel GetCurrentConfig()
        {
            return _configModel;
        }

        public void SetNewConfiguration(ConfigurationModel config)
        {
            _configModel.BoardSize = config.BoardSize;
            _configModel.WinningNumber = config.WinningNumber;
        }
    }
}
