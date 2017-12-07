namespace InteractiveGraphicMenu
{
    public class GraphicMenuParameters
    {
        public string Name { get; set; }
        public int Columns { get; set; }
        public int ColunmWidth { get; set; }

        public int RowWidth => Columns * ColunmWidth + Columns + 1;
    }
}
