using System.Collections.Generic;
using System.Linq;
using OfficeAssistant.Commands.Impl;

namespace OfficeAssistant.Commands
{
    public class CommandManager
    {
        private readonly List<ICommand> _applicationCommands = new List<ICommand>();
        private static CommandManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public CommandManager()
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
        public static CommandManager GetInstance()
        {
            if (_manager == null)
            {
                _manager = new CommandManager();
            }
            return _manager;
        }

        /// <summary>
        /// getting command from list
        /// </summary>
        public IEnumerable<string> GetAvaibleCommandNames()
        {
            return _applicationCommands.Select(c => c.Name);
        }

        /// <summary>
        /// getting command from list
        /// </summary>
        public IEnumerable<ICommand> GetAvaibleCommands()
        {
            return _applicationCommands;
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