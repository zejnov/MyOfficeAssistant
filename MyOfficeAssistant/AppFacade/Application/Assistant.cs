using Framework.OfficeAssistant.Domain;
using Framework.OfficeAssistant.Extensions;

namespace OfficeAssistant
{
    public class Assistant
    {
        public ApplicationState AppState { get; set; }
        private static Assistant _officeAssistant { get; set; }

        public static Assistant GetInstance()
        {
            return _officeAssistant ?? (_officeAssistant = new Assistant());
        }

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
