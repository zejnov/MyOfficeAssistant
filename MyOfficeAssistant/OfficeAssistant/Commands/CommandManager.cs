using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeAssistant.Commands
{
    public class CommandManager
    {
        private readonly List<ICommand> _avaibleCommands = new List<ICommand>();
        private static CommandManager _manager;

        /// <summary>
        /// ctor
        /// </summary>
        public CommandManager()
        {
           AddOperations();
        }

        /// <summary>
        /// getting/creating one instance of manager
        /// </summary>
        public static CommandManager GetInstance()
        {
            return _manager ?? (_manager = new CommandManager());
        }

        /// <summary>
        /// add commands from 'reflection'
        /// </summary>
        private void AddOperations()
        {
            var icommands = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(mytype => mytype.GetInterfaces()
                    .Contains(typeof(ICommand))
                    );

            foreach (var mytype in icommands)
            {
                var command = Activator.CreateInstance(mytype) as ICommand;
                if (string.IsNullOrEmpty(command?.Name)) continue;
                _avaibleCommands.Add(command);
            }
        }

        /// <summary>
        /// getting command from list
        /// </summary>
        public IEnumerable<string> GetAvaibleCommandNames()
        {
            return _avaibleCommands.Select(c => c.Command);
        }

        /// <summary>
        /// getting command from list
        /// </summary>
        public IEnumerable<ICommand> GetAvaibleCommands()
        {
            return _avaibleCommands;
        }

        /// <summary>
        /// managing given command to execute
        /// </summary>
        public void Execute(string choosenCommand)
        {
            _avaibleCommands
                .SingleOrDefault(c => c.Command == choosenCommand)?
                .Execute();
        }

        /// <summary>
        /// check if command exist
        /// </summary>
        public bool Exist(string commandName)
        {
            var command = _avaibleCommands.FirstOrDefault(c => c.Command == commandName);
            return command != null;
        }
    }
}