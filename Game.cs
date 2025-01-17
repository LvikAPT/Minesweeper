using System;

namespace Minesweeper
{
    public class Game
    {
        public int Rows { get; }
        public int Columns { get; }
        public int Mines { get; }
        private Cell[,] board;

        public Game(int rows, int columns, int mines)
        {
            Rows = rows;
            Columns = columns;
            Mines = mines;
            board = new Cell[rows, columns];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    board[i, j] = new Cell();
                }
            }

            Random rand = new Random();
            for (int i = 0; i < Mines; i++)
            {
                int row, col;
                do
                {
                    row = rand.Next(Rows);
                    col = rand.Next(Columns);
                } while (board[row, col].IsMine);

                board[row, col].IsMine = true;
            }
        }

        public Cell GetCell(int row, int col)
        {
            return board[row, col];
        }
    }
}