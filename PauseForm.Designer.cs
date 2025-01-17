namespace Minesweeper
{
    partial class PauseForm
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
            // PauseForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Name = "PauseForm";
            this.Text = "Пауза";

            // Кнопка продолжить
            Button btnContinue = new Button();
            btnContinue.Text = "Продолжить";
            btnContinue.Location = new System.Drawing.Point(50, 50);
            btnContinue.Click += new EventHandler(btnContinue_Click);
            this.Controls.Add(btnContinue);

            // Кнопка выход
            Button btnExit = new Button();
            btnExit.Text = "Выход";
            btnExit.Location = new System.Drawing.Point(50, 100);
            btnExit.Click += new EventHandler(btnExit_Click);
            this.Controls.Add(btnExit);

            // Кнопка в главное меню
            Button btnMainMenu = new Button();
            btnMainMenu.Text = "Главное меню";
            btnMainMenu.Location = new System.Drawing.Point(150, 50);
            btnMainMenu.Click += new EventHandler(btnMainMenu_Click);
            this.Controls.Add(btnMainMenu);

            this.ResumeLayout(false);
        }
    }
}