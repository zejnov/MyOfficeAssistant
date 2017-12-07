namespace InteractiveGraphicMenu.Interfaces
{
    public interface ICommand : IHighlighted
    {
        string Command { get; }
        string HelpInfo { get; }
        void Execute();
    }
}
