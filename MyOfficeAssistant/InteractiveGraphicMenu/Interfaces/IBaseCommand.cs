namespace InteractiveGraphicMenu.Interfaces
{
    public interface IBaseCommand
    {
        int Ordinal { get; }
        string Command { get; }
        
        void Execute();
    }
}