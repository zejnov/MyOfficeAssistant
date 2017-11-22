namespace OfficeAssistant.Commands
{
    public interface IHighlighted
    {
        string Name { get; }
        bool IsHighlighted { get; set; }
    }
}
