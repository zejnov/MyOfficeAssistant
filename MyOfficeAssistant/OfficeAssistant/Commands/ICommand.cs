namespace OfficeAssistant.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string HelpInfo { get; }
        void Execute();
    }
}
