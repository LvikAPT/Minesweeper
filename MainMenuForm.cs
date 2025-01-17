using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            StartGame(10, 10, 10); // ������ �������
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            StartGame(16, 16, 40); // ������� �������
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            StartGame(24, 24, 99); // ������� �������
        }

        private void StartGame(int rows, int columns, int mines)
        {
            Game game = new Game(rows, columns, mines);
            MinesweeperForm gameForm = new MinesweeperForm(game);
            this.Hide();
            gameForm.Show();
        }
    }
}