namespace Minesweeper
{
    partial class MainMenuForm
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
            this.btnEasy = new System.Windows.Forms.Button();
            this.btnMedium = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btnEasy
            // 
            this.btnEasy.Size = new System.Drawing.Size(100, 30);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "Легкий";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);

            // 
            // btnMedium
            // 
            this.btnMedium.Size = new System.Drawing.Size(100, 30);
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "Средний";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);

            // 
            // btnHard
            // 
            this.btnHard.Size = new System.Drawing.Size(100, 30);
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "Сложный";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);

            // 
            // MainMenuForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnEasy);

            // Центрируем кнопки
            int buttonWidth = 100;
            int buttonHeight = 30;
            int spacing = 10; // расстояние между кнопками

            this.btnEasy.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, (this.ClientSize.Height - (buttonHeight * 3 + spacing * 2)) / 2);
            this.btnMedium.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, this.btnEasy.Location.Y + buttonHeight + spacing);
            this.btnHard.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, this.btnMedium.Location.Y + buttonHeight + spacing);

            this.Name = "MainMenuForm";
            this.Text = "Меню";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
    }
}