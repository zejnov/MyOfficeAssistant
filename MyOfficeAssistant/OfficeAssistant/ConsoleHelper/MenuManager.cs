using System;
using System.Collections.Generic;
using OfficeAssistant.Commands;

namespace OfficeAssistant.ConsoleHelper
{
    public class MenuManager
    {
        public void ExecuteMenuMove(ICommand[][] commandsArray, Tuple<int, int> tuple)
        {
            if (commandsArray[tuple.Item2][tuple.Item1] == null)
                return;

            ClearAllHiglihgts(commandsArray, 2,4);
            commandsArray[tuple.Item2][tuple.Item1].IsHighlighted = true;
        }

        private void ClearAllHiglihgts(ICommand[][] commandsArray, int rows, int columns)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    if (commandsArray[row][column] == null)
                        continue;
                    commandsArray[row][column].IsHighlighted = false;
                }
            }
        }

        public ICommand[][] GenerateCommandsArray(List<ICommand> list, int size)
        {
            var options = list.Count;
            var rows = options / 4;
            if (options % 4 != 0)
                rows++;

            var array = GenerateEmptyArray(rows, size);
            var index = 0;

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < size; column++)
                {
                    array[row][column] = index < options ? list[index++] : new CommandEmpty();
                }
            }
            return array;
        }

        private ICommand[][] GenerateEmptyArray(int rows, int size)
        {
            var array = new ICommand[rows][];
            for (var row = 0; row < rows; row++)
            {
                array[row] = new ICommand[size];
            }
            return array;
        }

        private class CommandEmpty : ICommand
        {
            public string Name => string.Empty;
            public bool IsHighlighted { get; set; }
            public string Command { get; }
            public string HelpInfo { get; }
            public void Execute()
            {
                throw new NotImplementedException();
            }
        }
    }
}
