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
            // MinesweeperForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Name = "MinesweeperForm";
            this.Text = "Сапёр";
            this.ResumeLayout(false);
        }
    }
}