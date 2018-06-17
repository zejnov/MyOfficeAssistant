namespace InteractiveGraphicMenu.Interfaces
{
    public interface ICommand : IHighlighted
    {
        int Ordinal { get; }
        string Command { get; }
        string HelpInfo { get; }
        
        void Execute();
    }
}
