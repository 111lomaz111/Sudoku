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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sudokuTheGame));
            this.panelGame = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bttStartGame = new System.Windows.Forms.Button();
            this.cbLevels = new System.Windows.Forms.ComboBox();
            this.bttSolveGame = new System.Windows.Forms.Button();
            this.bttSaveGame = new System.Windows.Forms.Button();
            this.bttLoadSaveGame = new System.Windows.Forms.Button();
            this.bttTakeScreenshot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Transparent;
            this.panelGame.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelGame.ForeColor = System.Drawing.SystemColors.Control;
            this.panelGame.Location = new System.Drawing.Point(220, 12);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(230, 230);
            this.panelGame.TabIndex = 3;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "WYBIERZ POZIOM";
            // 
            // bttStartGame
            // 
            this.bttStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttStartGame.Location = new System.Drawing.Point(139, 10);
            this.bttStartGame.Name = "bttStartGame";
            this.bttStartGame.Size = new System.Drawing.Size(75, 22);
            this.bttStartGame.TabIndex = 4;
            this.bttStartGame.Text = "START!";
            this.bttStartGame.UseVisualStyleBackColor = true;
            this.bttStartGame.Click += new System.EventHandler(this.bttStartGame_Click);
            // 
            // cbLevels
            // 
            this.cbLevels.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cbLevels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLevels.Location = new System.Drawing.Point(12, 38);
            this.cbLevels.Name = "cbLevels";
            this.cbLevels.Size = new System.Drawing.Size(121, 21);
            this.cbLevels.TabIndex = 5;
            this.cbLevels.SelectedIndexChanged += new System.EventHandler(this.cbLevels_SelectedIndexChanged);
            // 
            // bttSolveGame
            // 
            this.bttSolveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttSolveGame.Location = new System.Drawing.Point(139, 38);
            this.bttSolveGame.Name = "bttSolveGame";
            this.bttSolveGame.Size = new System.Drawing.Size(75, 23);
            this.bttSolveGame.TabIndex = 6;
            this.bttSolveGame.Text = "ROZWIAZ";
            this.bttSolveGame.UseVisualStyleBackColor = true;
            this.bttSolveGame.Click += new System.EventHandler(this.bttSolveGame_Click);
            // 
            // bttSaveGame
            // 
            this.bttSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttSaveGame.Location = new System.Drawing.Point(139, 96);
            this.bttSaveGame.Name = "bttSaveGame";
            this.bttSaveGame.Size = new System.Drawing.Size(75, 23);
            this.bttSaveGame.TabIndex = 7;
            this.bttSaveGame.Text = "ZAPISZ";
            this.bttSaveGame.UseVisualStyleBackColor = true;
            this.bttSaveGame.Click += new System.EventHandler(this.bttSaveGame_Click);
            // 
            // bttLoadSaveGame
            // 
            this.bttLoadSaveGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttLoadSaveGame.Location = new System.Drawing.Point(139, 67);
            this.bttLoadSaveGame.Name = "bttLoadSaveGame";
            this.bttLoadSaveGame.Size = new System.Drawing.Size(75, 23);
            this.bttLoadSaveGame.TabIndex = 8;
            this.bttLoadSaveGame.Text = "WCZYTAJ";
            this.bttLoadSaveGame.UseVisualStyleBackColor = true;
            this.bttLoadSaveGame.Click += new System.EventHandler(this.bttLoadSaveGame_Click);
            // 
            // bttTakeScreenshot
            // 
            this.bttTakeScreenshot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttTakeScreenshot.Location = new System.Drawing.Point(139, 125);
            this.bttTakeScreenshot.Name = "bttTakeScreenshot";
            this.bttTakeScreenshot.Size = new System.Drawing.Size(75, 23);
            this.bttTakeScreenshot.TabIndex = 0;
            this.bttTakeScreenshot.Text = "ZDJECIE";
            this.bttTakeScreenshot.UseVisualStyleBackColor = true;
            this.bttTakeScreenshot.Click += new System.EventHandler(this.button1_Click);
            // 
            // sudokuTheGame
            // 
            this.AcceptButton = this.bttStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(460, 254);
            this.Controls.Add(this.bttTakeScreenshot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bttLoadSaveGame);
            this.Controls.Add(this.bttSaveGame);
            this.Controls.Add(this.bttSolveGame);
            this.Controls.Add(this.cbLevels);
            this.Controls.Add(this.bttStartGame);
            this.Controls.Add(this.panelGame);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Name = "sudokuTheGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku the Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button bttStartGame;
        private System.Windows.Forms.ComboBox cbLevels;
        private System.Windows.Forms.Button bttSolveGame;
        private System.Windows.Forms.Button bttSaveGame;
        private System.Windows.Forms.Button bttLoadSaveGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bttTakeScreenshot;
    }
}

