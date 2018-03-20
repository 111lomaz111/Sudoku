namespace SudokuTheGame
{
    partial class sudokuTheGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel = new System.Windows.Forms.Panel();
            this.bttStartGame = new System.Windows.Forms.Button();
            this.cbLevels = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(220, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(250, 250);
            this.panel.TabIndex = 3;
            this.panel.UseWaitCursor = true;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // bttStartGame
            // 
            this.bttStartGame.Location = new System.Drawing.Point(139, 12);
            this.bttStartGame.Name = "bttStartGame";
            this.bttStartGame.Size = new System.Drawing.Size(75, 23);
            this.bttStartGame.TabIndex = 4;
            this.bttStartGame.Text = "Start!";
            this.bttStartGame.UseVisualStyleBackColor = true;
            this.bttStartGame.UseWaitCursor = true;
            this.bttStartGame.Click += new System.EventHandler(this.bttStartGame_Click);
            // 
            // cbLevels
            // 
            this.cbLevels.FormattingEnabled = true;
            this.cbLevels.Location = new System.Drawing.Point(12, 12);
            this.cbLevels.Name = "cbLevels";
            this.cbLevels.Size = new System.Drawing.Size(121, 21);
            this.cbLevels.TabIndex = 5;
            this.cbLevels.Text = "Wybierz poziom gry!";
            this.cbLevels.UseWaitCursor = true;
            this.cbLevels.SelectedIndexChanged += new System.EventHandler(this.cbLevels_SelectedIndexChanged);
            // 
            // sudokuTheGame
            // 
            this.AcceptButton = this.bttStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 276);
            this.Controls.Add(this.cbLevels);
            this.Controls.Add(this.bttStartGame);
            this.Controls.Add(this.panel);
            this.Name = "sudokuTheGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku the Game";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button bttStartGame;
        private System.Windows.Forms.ComboBox cbLevels;
    }
}

