using System;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandGameMenu : ICommand
    {
        public string Name => "g";
        public string HelpInfo => "Doing sample stuff";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            Console.WriteLine("Ssssample");

            var handler = new ArrowsHandling();
            var tuple = new Tuple<int,int>(5,5);


            for (int i = 0; i < 111; i++)
            {
                tuple = handler.GetValidHighligthMove(tuple.Item1, tuple.Item2, 10, 10);
                Console.WriteLine($"{tuple.Item1}  and {tuple.Item2}");
            }
            
            Console.ReadKey();
        }
    }
}
