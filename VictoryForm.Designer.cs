namespace Minesweeper
{
    partial class VictoryForm
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
            // VictoryForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Name = "VictoryForm";
            this.Text = "Вы победили!";

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