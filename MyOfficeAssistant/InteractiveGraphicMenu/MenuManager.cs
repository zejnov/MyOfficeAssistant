using System;
using System.Collections.Generic;

namespace InteractiveGraphicMenu
{
    public class MenuManager<T> where T : class, IHighlighted
    {
        public void ExecuteMenuMove(T[][] commandsArray, Tuple<int, int> tuple)
        {
            if (commandsArray[tuple.Item2][tuple.Item1] == null)
                return;

            ClearAllHiglihgts(commandsArray, 2,4);
            commandsArray[tuple.Item2][tuple.Item1].IsHighlighted = true;
        }

        private void ClearAllHiglihgts(T[][] commandsArray, int rows, int columns)
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

        public T[][] GenerateCommandsArray(List<T> list, int size)
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
                    array[row][column] = index < options 
                        ? list[index++] 
                        : null;
                }
            }
            return array;
        }

        private T[][] GenerateEmptyArray(int rows, int size)
        {
            var array = new T[rows][];
            for (var row = 0; row < rows; row++)
            {
                array[row] = new T[size];
            }
            return array;
        }

        //private class CommandEmpty : IHighlighted
        //{
        //    public string Name => string.Empty;
        //    public bool IsHighlighted { get; set; }
        //    public string Command { get; }
        //    public string HelpInfo { get; }
        //    public void Execute()
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
