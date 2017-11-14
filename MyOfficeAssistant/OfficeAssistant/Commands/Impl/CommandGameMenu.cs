using System;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandGameMenu : ICommand
    {
        public string Name => "g";
        public string HelpInfo => "Doing sample stuff";
        public void Execute()
        {
            Console.WriteLine("Ssssample");

            var handler = new ArrowsHandling();
            var touple = handler.GetValidHighligthMove(5, 7, 10, 10);

            for (int i = 0; i < 5; i++)  //just testss
            {
                touple = handler.GetValidHighligthMove(5, 7,10,10);
                
            }
            Console.WriteLine($"{touple.Item1}  and {touple.Item2}");
            Console.ReadKey();
        }
    }
}
