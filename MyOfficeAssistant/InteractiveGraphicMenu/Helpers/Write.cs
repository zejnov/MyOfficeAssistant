using System;

namespace InteractiveGraphicMenu.Helpers
{
    public class Write
    {
        public static void Enter()
        {
            Console.Write("\n");
        }

        public static void Vertical(bool withNewLine = false)
        {
            if (withNewLine) Enter();
            Console.Write("|");
        }

        public static void Space(int space = 1)
        {
            for (var i = 0; i < space; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
