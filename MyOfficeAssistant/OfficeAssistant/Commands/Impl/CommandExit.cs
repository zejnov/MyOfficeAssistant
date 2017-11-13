using OfficeAssistant.Application;
using OfficeAssistant.Extensions;

namespace OfficeAssistant.Commands.Impl
{
    internal class CommandExit : ICommand
    {
        public string Name => "Exit";
        public string HelpInfo => "Exit application";
        public void Execute()
        {
            var sth = Assistant.GetInstance();
            sth.IsRunning = false;
        }
    }
}