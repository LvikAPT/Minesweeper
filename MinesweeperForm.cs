using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        private Game game;
        private Button[,] buttons;
        private Button btnPause;

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
                    buttons[i, j].MouseDown += Button_MouseDown; // Добавляем обработчик для нажатия мыши
                    this.Controls.Add(buttons[i, j]);
                }
            }
            PositionButtons(); // Располагаем кнопки

            // Добавляем кнопку паузы
            btnPause = new Button();
            btnPause.Text = "Пауза";
            btnPause.Size = new Size(100, 30);
            btnPause.Location = new Point((this.ClientSize.Width - btnPause.Width) / 2, this.ClientSize.Height - 50);
            btnPause.Click += BtnPause_Click;
            this.Controls.Add(btnPause);
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
            btnPause.Location = new Point((this.ClientSize.Width - btnPause.Width) / 2, this.ClientSize.Height - 50); // Перемещаем кнопку паузы
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            PauseForm pauseForm = new PauseForm(this);
            pauseForm.ShowDialog(); // Открываем окно паузы как модальное
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
                // Если нажата мина, открываем все клетки
                ShowAllCells();
                GameOverForm gameOverForm = new GameOverForm();
                gameOverForm.ShowDialog(); // Показываем окно поражения
                this.Close(); // Закрываем игровую форму
            }
            else
            {
                OpenCell(row, col);

                // Проверяем, выиграл ли игрок
                if (CheckWinCondition())
                {
                    ShowAllCells(); // Открываем все клетки при выигрыше
                    VictoryForm victoryForm = new VictoryForm();
                    victoryForm.ShowDialog(); // Показываем окно победы
                    this.Close(); // Закрываем игровую форму
                }
            }
        }

        private void ShowAllCells()
        {
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    Cell cell = game.GetCell(i, j);
                    buttons[i, j].Enabled = false; // Деактивируем кнопку
                    if (cell.IsMine)
                    {
                        buttons[i, j].BackColor = Color.Red; // Отображаем, что это мина
                    }
                    else
                    {
                        buttons[i, j].Text = cell.NeighborMines > 0 ? cell.NeighborMines.ToString() : "";
                    }
                }
            }
        }

        private void btnInstantWin_Click(object sender, EventArgs e)
        {
            // Открываем все клетки
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    Cell cell = game.GetCell(i, j);
                    cell.IsRevealed = true; // Открываем клетку
                    buttons[i, j].Enabled = false; // Деактивируем кнопку
                    if (cell.IsMine)
                    {
                        buttons[i, j].BackColor = Color.Red; // Отображаем, что это мина
                    }
                    else
                    {
                        buttons[i, j].Text = cell.NeighborMines > 0 ? cell.NeighborMines.ToString() : "";
                    }
                }
            }

            // Показываем окно победы
            VictoryForm victoryForm = new VictoryForm();
            victoryForm.ShowDialog(); // Показываем окно победы
            this.Close(); // Закрываем игровую форму
        }

        private bool CheckWinCondition()
        {
            // Проверяем, все ли ячейки, кроме мин, открыты
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    if (!game.GetCell(i, j).IsMine && !game.GetCell(i, j).IsRevealed)
                    {
                        return false; // Если есть не открытая ячейка, игрок не выиграл
                    }
                }
            }

            // Проверяем, установлены ли флажки на всех минах
            int flaggedMines = 0;
            for (int i = 0; i < game.Rows; i++)
            {
                for (int j = 0; j < game.Columns; j++)
                {
                    if (game.GetCell(i, j).IsMine && buttons[i, j].Text == "F")
                    {
                        flaggedMines++;
                    }
                }
            }

            // Игрок выигрывает, если все мины отмечены флажками
            return flaggedMines == game.TotalMines; // Предполагается, что game.TotalMines содержит общее количество мин
        }

        private void OpenCell(int row, int col)
        {
            // Логика открытия ячейки
            Cell cell = game.GetCell(row, col);
            if (!cell.IsRevealed)
            {
                cell.IsRevealed = true;
                buttons[row, col].Text = cell.NeighborMines > 0 ? cell.NeighborMines.ToString() : "";
                buttons[row, col].Enabled = false; // Деактивируем кнопку после открытия
                if (cell.NeighborMines == 0)
                {
                    // Если ячейка пустая, открываем соседние ячейки
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            if (i == 0 && j == 0) continue; // Пропускаем саму ячейку
                            int newRow = row + i;
                            int newCol = col + j;
                            if (newRow >= 0 && newRow < game.Rows && newCol >= 0 && newCol < game.Columns)
                            {
                                OpenCell(newRow, newCol);
                            }
                        }
                    }
                }
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Button button = sender as Button;
                if (button.Text == "F")
                {
                    button.Text = ""; // Убираем флажок
                }
                else
                {
                    button.Text = "F"; // Устанавливаем флажок
                }
            }
        }
    }
}