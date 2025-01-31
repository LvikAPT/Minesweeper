﻿using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    partial class MainMenuForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Button btnMedium;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnImposible;
        private System.Windows.Forms.Button btnExit; 

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
            this.btnImposible = new System.Windows.Forms.Button(); // Инициализация кнопки для одной клетки
            this.btnExit = new System.Windows.Forms.Button(); // Инициализация кнопки выхода
            this.SuspendLayout();

            // 
            // btnEasy
            // 
            this.btnEasy.Size = new System.Drawing.Size(120, 60); // Изменение размера кнопки
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "Легкий";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);

            // 
            // btnMedium
            // 
            this.btnMedium.Size = new System.Drawing.Size(120, 60); // Изменение размера кнопки
            this.btnMedium.TabIndex = 1;
            this.btnMedium.Text = "Средний";
            this.btnMedium.UseVisualStyleBackColor = true;
            this.btnMedium.Click += new System.EventHandler(this.btnMedium_Click);

            // 
            // btnHard
            // 
            this.btnHard.Size = new System.Drawing.Size(120, 60); // Изменение размера кнопки
            this.btnHard.TabIndex = 2;
            this.btnHard.Text = "Сложный";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);

            // 
            // btnOneCell
            // 
            this.btnImposible.Size = new System.Drawing.Size(120, 60); // Изменение размера кнопки
            this.btnImposible.TabIndex = 3;
            this.btnImposible.Text = "1 Клетка";
            this.btnImposible.UseVisualStyleBackColor = true;
            this.btnImposible.Click += new System.EventHandler(this.btnImposible_Click);

            // 
            // btnExit
            // 
            this.btnExit.Size = new System.Drawing.Size(120, 60); // Изменение размера кнопки
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "→"; // Стрелочка для выхода
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // 
            // MainMenuForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.btnEasy);
            this.Controls.Add(this.btnMedium);
            this.Controls.Add(this.btnHard);
            this.Controls.Add(this.btnImposible);
            this.Controls.Add(this.btnExit);

            // Центрируем кнопки
            int buttonWidth = 120; // Ширина кнопок
            int buttonHeight = 60; // Высота кнопок
            int spacing = 20; // расстояние между кнопками

            this.btnEasy.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, (this.ClientSize.Height - buttonHeight * 5 - spacing * 4) / 2);
            this.btnMedium.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, this.btnEasy.Location.Y + buttonHeight + spacing);
            this.btnHard.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, this.btnMedium.Location.Y + buttonHeight + spacing);
            this.btnImposible.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, this.btnHard.Location.Y + buttonHeight + spacing);
            this.btnExit.Location = new System.Drawing.Point((this.ClientSize.Width - buttonWidth) / 2, this.btnImposible.Location.Y + buttonHeight + spacing);

            this.Name = "MainMenuForm";
            this.Text = "Меню";
            this.ResumeLayout(false);
        }
    }
}