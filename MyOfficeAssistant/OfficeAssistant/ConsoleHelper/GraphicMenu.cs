using System;

namespace OfficeAssistant.ConsoleHelper
{
    public class GraphicMenu
    {

        public void PrintMenu()
        {
            PrintHeader("Menu name");
        }

        private void PrintHeader(string menuName)
        {
            PrintHorizontalLine(59);
            PrintHeaderName(70, menuName);
            PrintHorizontalLine(59);
        }

        private void PrintHeaderName(int x, string menuName)
        {
            var size = (x / 2) - 3 - menuName.Length;

            Write.Enter();
            Console.Write("|");

            for (var i = 0; i < size; i++)
            {
                Console.Write(" ");
            }

            Console.Write($" {menuName} ");

            for (var i = 0; i < size; i++)
            {
                Console.Write(" ");
            }
            Console.Write("|");
            Write.Enter();
        }

        private void PrintHorizontalLine(int x)
        {
            for (var i = 0; i < x; i++)
            {
                Console.Write("-");
            }
        }
    }
}
