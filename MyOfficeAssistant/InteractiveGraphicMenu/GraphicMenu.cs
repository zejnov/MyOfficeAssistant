using System;
using InteractiveGraphicMenu.Domain;
using InteractiveGraphicMenu.Helpers;
using InteractiveGraphicMenu.Interfaces;

namespace InteractiveGraphicMenu
{
    public class GraphicMenu<T> where T : ISelected
    {
        public void PrintMenu(T[][] commandsArray)
        {
            var parameters = new GraphicMenuParameters()
            {
                Columns = 4,
                ColunmWidth = 14,
            };
            //TODO make use of params

            PrintHeader("Menu name");
            PrintMenuOptions(commandsArray);
            //print optionals info
            PrintHorizontalLine(61, true);
        }

        //********************************** OPTIONS ******************************
        private void PrintMenuOptions(T[][] commandsArray, int size = 61)
        {
            var rows = 2;
            var columns = 4;

            for (var row = 0; row < rows; row++)
            {
                Write.Enter();
                for (var column = 0; column < columns; column++)
                {
                    PrintOption(commandsArray[row][column]);
                }
                Write.Vertical();
                PrintHorizontalLine(size,true);
            }
        }

        private void PrintOption(T command, int optionSize = 14)
        {
            Write.Vertical();

            if (command == null)
            {
                Write.Space(optionSize);
                return;
            }
            
            var commandToPrint = command.DisplayName.Length > optionSize ? command.DisplayName.Remove(optionSize) : command.DisplayName;

            var freeSpace = optionSize - command.DisplayName.Length;
            var spaceSize = freeSpace / 2;

            if (command.IsSelected)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Write.Space(spaceSize);
            Console.Write($"{commandToPrint}");
            
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
            PrintStringInLine(size, menuName);
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

        private void PrintStringInLine(int x, string menuName)
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
