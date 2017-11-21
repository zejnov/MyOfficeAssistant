using System;
using System.Collections.Generic;
using System.Linq;
using OfficeAssistant.Commands;

namespace OfficeAssistant.ConsoleHelper
{
    public class GraphicMenu
    {
        public void PrintMenu(IEnumerable<ICommand> list)
        {
            PrintHeader("Menu name");
            PrintMenuOptions(list.ToList());
            PrintHorizontalLine(61, true);
        }

        private void PrintMenuOptions(List<ICommand> list, int size = 61)
        {
            var options = list.Count;
            var rows = options / 4;
            if (options %4 !=0)
                rows++;

            for (var row = 0; row < rows; row++)
            {
                var dataLine = new List<ICommand>();

                for (var i = 0; i < 4; i++)
                {
                    var calculatedIndex = row + i + 3 * row;

                    dataLine.Add(calculatedIndex < options ? list[calculatedIndex] : null);
                }

                PrintOptionsLine(dataLine);
                PrintHorizontalLine(size,true);
            }
        }

        private void PrintOptionsLine(List<ICommand> dataLine, int optionsInLine = 4)
        {
            Write.Enter();

            for (int option = 0; option < optionsInLine; option++)
            {
                Write.Vertical();
                PrintOption(dataLine[option]);
            }
            Write.Vertical();
        }

        private void PrintOption(ICommand command, int optionSize = 14)
        {
            if (command == null)
            {
                Write.Space(optionSize);
                return;
            }

            var freeSpace = optionSize - command.Name.Length;
            var spaceSize = freeSpace / 2;

            if (command.IsHighlighted)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Write.Space(spaceSize);
            Console.Write($"{command.Name}");
            
            if (freeSpace % 2 != 0)
                spaceSize++;

            Write.Space(spaceSize);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //********************************** HEADER ******************************

        private void PrintHeader(string menuName, int size = 61)
        {
            PrintnumerousLine(size);
            PrintHorizontalLine(size, true);
            PrintHeaderNameLine(size, menuName);
            PrintHorizontalLine(size);
            PrintHorizontalLine(size, true);

        }

        private void PrintnumerousLine(int size)  //just temp
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{i%10}");
            }
        }

        private void PrintHeaderNameLine(int x, string menuName)
        {
            var freeSpace = x - 2 - menuName.Length;
            var spaceSize = freeSpace / 2;
            
            Write.Enter();
            Write.Vertical();
            Write.Space(spaceSize);

            Console.Write($"{menuName}");

            if (freeSpace % 2 != 0)
                spaceSize++;

            Write.Space(spaceSize);
            Write.Vertical();
            Write.Enter();
        }

        private void PrintHorizontalLine(int x, bool startWithNewLine = false)
        {
            if (startWithNewLine)
                Write.Enter();

            for (var i = 0; i < x; i++)
            {
                Console.Write("-");
            }
        }
    }
}
