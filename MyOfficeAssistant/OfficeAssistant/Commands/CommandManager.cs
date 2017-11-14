using System;
using System.Collections.Generic;
using System.Linq;

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
           AddOperations();
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
                _applicationCommands.Add(Activator.CreateInstance(mytype) as ICommand);
            }
        }

        /// <summary>
        /// getting/creating one instance of manager
        /// </summary>
        public static CommandManager GetInstance()
        {
            return _manager ?? (_manager = new CommandManager());
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