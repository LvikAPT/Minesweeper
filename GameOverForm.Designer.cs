namespace Minesweeper
{
    partial class GameOverForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameOverForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Name = "GameOverForm";
            this.Text = "Игра окончена";

            // Кнопка для возврата в главное меню
            Button btnMainMenu = new Button();
            btnMainMenu.Text = "Главное меню";
            btnMainMenu.Location = new System.Drawing.Point(100, 100);
            btnMainMenu.Click += new EventHandler(btnMainMenu_Click);
            this.Controls.Add(btnMainMenu);

            this.ResumeLayout(false);
        }
    }
}