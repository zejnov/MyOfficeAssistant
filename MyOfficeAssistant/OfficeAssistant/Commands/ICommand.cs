namespace OfficeAssistant.Commands
{
    public interface ICommand
    {
        string Name { get; }
        string HelpInfo { get; }
        bool IsHighlighted { get; set; }
        void Execute();
    }
}
