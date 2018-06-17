using System.Collections.Generic;
using System.Linq;
using Game.TicTacToe.CommandManagement.Commands;

namespace Game.TicTacToe.CommandManagement
{
    public class CommandManager
    {
        private readonly List<IGameCommand> _applicationCommands = new List<IGameCommand>();
        private static CommandManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public CommandManager()
        {
            AddNativeOperations();
        }

        private void AddNativeOperations()
        {
            _applicationCommands.Add(new CommandOne());
            _applicationCommands.Add(new CommandTwo());
            _applicationCommands.Add(new CommandSet());
            _applicationCommands.Add(new CommandHelp());
            _applicationCommands.Add(new CommandExit());
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
            return _applicationCommands.Select(p => p.Name);
        }

        /// <summary>
        /// managing given command to execute
        /// </summary>
        public void Execute(string choosenCommand)
        {
            _applicationCommands
                .SingleOrDefault(p => p.Name == choosenCommand)
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

        /// <summary>
        /// returning all avaible commands (for printing help)
        /// </summary>
        public List<IGameCommand> GetAllCommands()
        {
            return _applicationCommands.ToList();
        }
    }
}
