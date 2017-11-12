using AppFacade.Domain;

namespace Extensions
{
    public static class AppStateExtensions
    {
        public static void SetToRunning(this ApplicationState state) => state.IsRunning = true;
        public static void SetToStop(this ApplicationState state) => state.IsRunning = false;
    }
}
