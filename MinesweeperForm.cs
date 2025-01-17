using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        private Game game;
        private Button[,] buttons;

        public MinesweeperForm(Game game)
        {
            InitializeComponent();
            this.game = game;
            InitializeGameBoard();
            this.Resize += MinesweeperForm_Resize; // Подписываемся на событие изменения размера
        }

        private void InitializeGameBoard()
        {
            buttons = new Button[game.Rows, game.Columns];
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(40, 40);
                    buttons[i, j].Tag = new Point(i, j);
                    buttons[i, j].Click += Button_Click;
                    this.Controls.Add(buttons[i, j]);
                }
            }
            PositionButtons(); // Располагаем кнопки
        }

        private void PositionButtons()
        {
            int buttonWidth = 40;
            int buttonHeight = 40;

            // Вычисляем начальные координаты для центрирования
            int startX = (this.ClientSize.Width - (game.Columns * buttonWidth)) / 2;
            int startY = (this.ClientSize.Height - (game.Rows * buttonHeight)) / 2;

            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    buttons[i, j].Location = new Point(startX + j * buttonWidth, startY + i * buttonHeight);
                }
            }
        }

        private void MinesweeperForm_Resize(object sender, EventArgs e)
        {
            PositionButtons(); // Перемещаем кнопки при изменении размера формы
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;

            Cell cell = game.GetCell(row, col);
            if (cell.IsMine)
            {
                button.BackColor = Color.Red; // Отображаем, что это мина
                MessageBox.Show("Game Over! You hit a mine.");
                this.Close(); // Закрываем форму после окончания игры
            }
            else
            {
                OpenCell(row, col);
            }
        }

        private void OpenCell(int row, int col)
        {
            if (!game.GetCell(row, col).IsRevealed)
            {
                game.OpenCell(row, col);
                buttons[row, col].BackColor = Color.LightGray; // Отображаем, что ячейка открыта
                buttons[row, col].Text = game.GetCell(row, col).NeighborMines > 0 ? game.GetCell(row, col).NeighborMines.ToString() : "";

                // Если ячейка не содержит соседних мин, открываем соседние ячейки
                if (game.GetCell(row, col).NeighborMines == 0)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            if (x == 0 && y == 0) continue; // Пропустить саму ячейку
                            int neighborRow = row + x;
                            int neighborCol = col + y;

                            if (game.IsInBounds(neighborRow, neighborCol))
                            {
                                OpenCell(neighborRow, neighborCol);
                            }
                        }
                    }
                }
            }
        }
    }
}