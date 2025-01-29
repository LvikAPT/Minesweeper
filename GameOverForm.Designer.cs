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
            this.BackColor = System.Drawing.Color.LightCoral;

            // Кнопка для возврата в главное меню
            Button btnMainMenu = new Button();
            btnMainMenu.Text = "Главное меню";
            btnMainMenu.Location = new System.Drawing.Point(100, 100);
            btnMainMenu.Click += new EventHandler(btnMainMenu_Click);
            btnMainMenu.BackColor = System.Drawing.Color.White;
            btnMainMenu.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(btnMainMenu);

            this.ResumeLayout(false);
        }
    }
}