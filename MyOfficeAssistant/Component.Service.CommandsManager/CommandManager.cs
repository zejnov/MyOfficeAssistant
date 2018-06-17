using System;
using System.Collections.Generic;
using System.Linq;
using Component.Service.CommandsManager.Interfaces;

namespace Component.Service.CommandsManager
{
    public class CommandManager<T> where T : class, IBaseCommand
    {
        private readonly List<T> _avaibleCommands = new List<T>();
        private static CommandManager<T> _manager;
        private readonly Type _type = typeof(T);

        /// <summary>
        /// ctor
        /// </summary>
        public CommandManager() => AddOperations();

        /// <summary>
        /// getting/creating one instance of manager
        /// </summary>
        public static CommandManager<T> GetInstance() => _manager ?? (_manager = new CommandManager<T>());

        /// <summary>
        /// add commands from 'reflection'
        /// </summary>
        private void AddOperations()
        {
            var icommands = System.Reflection.Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(s => s.GetInterfaces().Any(i => i.Name == _type.Name));

            foreach (var mytype in icommands)
            {
                var command = Activator.CreateInstance(mytype) as T;
                if (string.IsNullOrEmpty(command?.Command)) continue;
                _avaibleCommands.Add(command);
            }
        }

        /// <summary>
        /// getting command from list
        /// </summary>
        public List<string> GetAvaibleCommandNames() => _avaibleCommands.Select(c => c.Command).ToList();

        /// <summary>
        /// getting command from list
        /// </summary>
        public List<T> GetAvaibleCommands() => _avaibleCommands
            .OrderBy(c => c.Ordinal)
            .ThenBy(c => c.Command)
            .ToList();

        /// <summary>
        /// managing given command to execute
        /// </summary>
        public void Execute(string choosenCommand) => _avaibleCommands
            .SingleOrDefault(c => c.Command == choosenCommand)?
            .Execute();

        /// <summary>
        /// check if command exist
        /// </summary>
        public bool Exist(string commandName) => _avaibleCommands.FirstOrDefault(c => c.Command == commandName) != null;
    }
}