using System;
using System.Collections.Generic;

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

            CalculateNeighborMines();
        }

        private void CalculateNeighborMines()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (board[i, j].IsMine)
                    {
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                if (x == 0 && y == 0) continue; // Пропустить саму мину
                                int neighborRow = i + x;
                                int neighborCol = j + y;

                                if (IsInBounds(neighborRow, neighborCol))
                                {
                                    board[neighborRow, neighborCol].NeighborMines++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < Rows && col >= 0 && col < Columns;
        }

        public Group OpenCell(int row, int col)
        {
            if (!IsInBounds(row, col) || board[row, col].IsRevealed)
            {
                return null; // Ячейка вне границ или уже открыта
            }

            board[row, col].IsRevealed = true;

            Group group = new Group(board[row, col]);

            if (board[row, col].IsMine)
            {
                return group; // Если ячейка - мина, возвращаем группу с этой ячейкой
            }

            // Если ячейка не мина, добавляем соседние ячейки в группу
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0) continue; // Пропустить саму ячейку
                    int neighborRow = row + x;
                    int neighborCol = col + y;

                    if (IsInBounds(neighborRow, neighborCol) && !board[neighborRow, neighborCol].IsRevealed)
                    {
                        group.AddCell(board[neighborRow, neighborCol]);
                    }
                }
            }

            return group;
        }
    }
}