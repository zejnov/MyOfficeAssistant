namespace OfficeAssistant.Commands
{
    public interface ICommand : IHighlighted
    {
        string Command { get; }
        string HelpInfo { get; }
        void Execute();
    }
}
