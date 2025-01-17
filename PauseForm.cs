using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class PauseForm : Form
    {
        private MinesweeperForm mainForm;

        public PauseForm(MinesweeperForm form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем окно паузы
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Завершаем приложение
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            mainForm.Hide(); // Скрываем текущее игровое поле
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show(); // Показываем главное меню
            this.Close(); // Закрываем окно паузы
        }
    }
}