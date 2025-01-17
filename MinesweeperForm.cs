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
                    buttons[i, j].Location = new Point(j * 40, i * 40);
                    buttons[i, j].Tag = new Point(i, j);
                    buttons[i, j].Click += Button_Click;
                    this.Controls.Add(buttons[i, j]);
                }
            }
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
                button.BackColor = Color.LightGray; // Отображаем, что ячейка открыта
                button.Text = cell.NeighborMines.ToString(); // Показываем количество соседних мин
            }
        }
    }
}