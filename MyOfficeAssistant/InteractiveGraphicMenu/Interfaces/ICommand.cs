namespace InteractiveGraphicMenu.Interfaces
{
    public interface ICommand : IHighlighted, IBaseCommand 
    {
        string HelpInfo { get; }
    }
}
