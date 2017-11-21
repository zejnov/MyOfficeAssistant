using System;
using System.Linq;
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
            var list = CommandManager.GetInstance()
                .GetAvaibleCommands()
                .OrderBy(c => c.Name)
                .ToList();

            var menu = new GraphicMenu(list);
            var handler = new ArrowsHandling();
            var tuple = new Tuple<int, int>(0, 0);

            Console.Clear();
            

            while (true)
            {
                tuple = handler.GetValidHighligthMove(tuple.Item1, tuple.Item2, 4, 2);
                Console.WriteLine($"{tuple.Item1}  and {tuple.Item2}");
                
                //add validation and highlighting

                menu.PrintMenu();
                
            }
            
        }
    }
}
