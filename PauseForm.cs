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
            this.FormClosing += MinesweeperForm_FormClosing; // Добавляем обработчик закрытия формы
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