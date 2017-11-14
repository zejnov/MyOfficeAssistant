using System;

namespace OfficeAssistant.Commands.Impl
{
    public class CommandGameMenu : ICommand
    {
        public string Name => "GameMenu";
        public string HelpInfo => "Doing sample stuff";
        public void Execute()
        {
            Console.WriteLine("Ssssample");
            Console.ReadKey();
        }
    }
}
