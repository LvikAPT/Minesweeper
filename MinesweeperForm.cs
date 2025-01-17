using System;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MinesweeperForm : Form
    {
        private Game game;

        public MinesweeperForm(Game game)
        {
            InitializeComponent();
            this.game = game;
            // Здесь добавьте код для инициализации игрового поля на основе объекта game
        }

        // Добавьте методы для обработки кликов по ячейкам и отображения состояния игры
    }
}