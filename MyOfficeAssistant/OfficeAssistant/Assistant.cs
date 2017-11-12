using AppFacade.Domain;
using Extensions;
using OfficeAssistant.ConsoleHelper;

namespace OfficeAssistant
{
    public class Assistant
    {
        public ApplicationState AppState { get; set; }

        public Assistant()
        {
            AppState = new ApplicationState();
            AppState.SetToRunning();
        }

        public void Run()
        {
            while (AppState.IsRunning)
            {
                //
            }

            Write.AvaibleCommands();
            Read.Wait();
        }
    }
}
