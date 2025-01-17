using System.Collections.Generic;

namespace Minesweeper
{
    public class Group
    {
        public List<Cell> Cells { get; set; }
        public Cell AdjacentCell { get; set; }

        public Group(Cell adjacentCell)
        {
            Cells = new List<Cell>();
            AdjacentCell = adjacentCell;
        }

        public void AddCell(Cell cell)
        {
            Cells.Add(cell);
        }
    }
}