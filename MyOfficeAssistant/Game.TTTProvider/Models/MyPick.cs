namespace Game.TTTProvider.Models
{
    public class MyPick
    {
        public int Id { get; set; }
        public int[] Pick { get; set; }
        public int Improtance { get; set; }
        public bool IsTryToWin { get; set; }
    }
}
