using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.Resize += MainMenuForm_Resize; // Подписываемся на событие изменения размера
            CenterButtons(); // Центрируем кнопки при инициализации
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            StartGame(10, 10, 10); // Легкий уровень
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            StartGame(16, 16, 40); // Средний уровень
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            StartGame(24, 24, 99); // Сложный уровень
        }

        private void StartGame(int rows, int columns, int mines)
        {
            Game game = new Game(rows, columns, mines);
            MinesweeperForm gameForm = new MinesweeperForm(game);
            this.Hide();
            gameForm.Show();
        }

        private void MainMenuForm_Resize(object sender, EventArgs e)
        {
            CenterButtons(); // Центрируем кнопки при изменении размера
        }

        private void CenterButtons()
        {
            int buttonWidth = 100;
            int buttonHeight = 30;
            int spacing = 10; // расстояние между кнопками

            // Вычисляем начальные координаты для центрирования
            int startX = (this.ClientSize.Width - buttonWidth) / 2;
            int startY = (this.ClientSize.Height - (buttonHeight * 3 + spacing * 2)) / 2;

            btnEasy.Location = new System.Drawing.Point(startX, startY);
            btnMedium.Location = new System.Drawing.Point(startX, startY + buttonHeight + spacing);
            btnHard.Location = new System.Drawing.Point(startX, startY + (buttonHeight + spacing) * 2);
        }
    }
}