namespace Minesweeper
{
    public class Cell
    {
        public bool IsMine { get; set; }
        public bool IsRevealed { get; set; }
        public int NeighborMines { get; set; }

        public Cell()
        {
            IsMine = false;
            IsRevealed = false;
            NeighborMines = 0;
        }
    }
}