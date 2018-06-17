namespace InteractiveGraphicMenu.Interfaces
{
    public interface ISelected
    {
        string DisplayName { get; }
        bool IsSelected { get; set; }
    }
}
