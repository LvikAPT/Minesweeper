namespace Minesweeper
{
    partial class MinesweeperForm
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

        private System.Windows.Forms.Button btnInstantWin;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // btnInstantWin
            // 
            this.btnInstantWin = new System.Windows.Forms.Button();
            this.btnInstantWin.Text = "Победа!";
            this.btnInstantWin.Size = new System.Drawing.Size(100, 30);
            this.btnInstantWin.Location = new System.Drawing.Point(10, 10); // Позиция кнопки
            this.btnInstantWin.Click += new System.EventHandler(this.btnInstantWin_Click);
            this.Controls.Add(this.btnInstantWin);
            // 
            // MinesweeperForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Name = "MinesweeperForm";
            this.Text = "Сапёр";
            this.ResumeLayout(false);
        }
    }
}