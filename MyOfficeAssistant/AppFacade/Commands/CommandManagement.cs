using System.Collections.Generic;
using System.Linq;
using Framework.OfficeAssistant.Commands.Impl;

namespace Framework.OfficeAssistant.Commands
{
    public class CommandManagement
    {
        private readonly List<ICommand> _applicationCommands = new List<ICommand>();
        private static CommandManagement _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public CommandManagement()
        {
            AddNativeOperations(); //usunąć konstruktor
        }

        /// <summary>
        /// add commands there
        /// </summary>
        private void AddNativeOperations()
        {
            _applicationCommands.Add(new CommandExit());
            _applicationCommands.Add(new CommandHelp());
            _applicationCommands.Add(new CommandSample());
        }

        /// <summary>
        /// getting/creating one instance of manager
        /// </summary>
        public static CommandManagement GetInstance()
        {
            return _manager ?? (_manager = new CommandManagement());
        }

        /// <summary>
        /// getting command from list
        /// </summary>
        public IEnumerable<string> GetAvaibleCommandNames()
        {
            return _applicationCommands.Select(c => c.Name);
        }

        /// <summary>
        /// managing given command to execute
        /// </summary>
        public void Execute(string choosenCommand)
        {
            _applicationCommands
                .SingleOrDefault(c => c.Name == choosenCommand)?
                .Execute();
        }

        /// <summary>
        /// check if command exist
        /// </summary>
        public bool Exist(string commandName)
        {
            var command = _applicationCommands.FirstOrDefault(c => c.Name == commandName);
            return command != null;
        }
    }
}