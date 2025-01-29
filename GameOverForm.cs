using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();
            this.FormClosing += MinesweeperForm_FormClosing; // Добавляем обработчик закрытия формы
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            // Создаем и показываем главное меню
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show(); // Показываем главное меню
            this.Close(); // Закрываем окно поражения
        }
        private void MinesweeperForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Здесь можно добавить логику, если нужно, например, подтверждение закрытия
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Отменяем закрытие формы
            }
        }
    }
}