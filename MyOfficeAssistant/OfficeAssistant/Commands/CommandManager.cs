using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using InteractiveGraphicMenu.Interfaces;

namespace OfficeAssistant.Commands
{
    public class CommandManager
    {
        private readonly List<ICommand> _avaibleCommands = new List<ICommand>();
        private static CommandManager _manager;
        private Type _type;

        /// <summary>
        /// ctor
        /// </summary>
        public CommandManager(Type type)
        {
            _type = type;
           AddOperations();
        }

        /// <summary>
        /// getting/creating one instance of manager
        /// </summary>
        public static CommandManager GetInstance(Type type)
        {
            return _manager ?? (_manager = new CommandManager(type));
        }

        /// <summary>
        /// add commands from 'reflection'
        /// </summary>
        private void AddOperations()
        {
            var sth = _type;
            var sthIcom = typeof(ICommand);
            var xxx = typeof(ICommand);
            
            var icommands = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetInterfaces().Any(i => i.FullName == sth.FullName));

            var icommansfasdfds = System.Reflection.Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(s => s.GetInterfaces().Contains(_type));

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
        public List<ICommand> GetAvaibleCommands()
        {
            return _avaibleCommands
                .OrderBy(c => c.Ordinal)
                .ThenBy(c => c.Name)
                .ToList();;
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