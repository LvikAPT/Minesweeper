using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class VictoryForm : Form
    {
        public VictoryForm()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show(); // Показываем главное меню
            this.Close(); // Закрываем окно победы
        }
    }
}