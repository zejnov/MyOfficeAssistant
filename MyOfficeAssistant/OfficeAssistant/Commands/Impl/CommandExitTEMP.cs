using OfficeAssistant.Domain;

namespace OfficeAssistant.Commands.Impl
{
    internal class CommandExitTEMP : ICommand
    {
        public string Name => "Exittt";
        public string HelpInfo => "Exit application";
        public bool IsHighlighted { get; set; }

        public void Execute()
        {
            ApplicationState.IsRunning = false;
        }
    }
}