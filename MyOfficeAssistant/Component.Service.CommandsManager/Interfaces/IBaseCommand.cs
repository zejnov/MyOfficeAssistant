namespace Component.Service.CommandsManager.Interfaces
{
    public interface IBaseCommand
    {
        int Ordinal { get; }
        string Command { get; }
        string HelpInfo { get; }
        
        void Execute();
    }
}