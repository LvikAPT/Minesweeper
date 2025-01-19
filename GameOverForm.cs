using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class GameOverForm : Form
    {
        public GameOverForm()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            // Создаем и показываем главное меню
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show(); // Показываем главное меню
            this.Close(); // Закрываем окно поражения
        }
    }
}