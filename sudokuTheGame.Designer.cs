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
            this.bttStartGame = new System.Windows.Forms.Button();
            this.cbLevels = new System.Windows.Forms.ComboBox();
            this.bttSolveGame = new System.Windows.Forms.Button();
            this.bttSaveGame = new System.Windows.Forms.Button();
            this.bttLoadSaveGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelGame
            // 
            this.panelGame.BackColor = System.Drawing.Color.Transparent;
            this.panelGame.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panelGame.ForeColor = System.Drawing.SystemColors.Control;
            this.panelGame.Location = new System.Drawing.Point(220, 12);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(250, 250);
            this.panelGame.TabIndex = 3;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // bttStartGame
            // 
            this.bttStartGame.Location = new System.Drawing.Point(139, 12);
            this.bttStartGame.Name = "bttStartGame";
            this.bttStartGame.Size = new System.Drawing.Size(75, 21);
            this.bttStartGame.TabIndex = 4;
            this.bttStartGame.Text = "Start!";
            this.bttStartGame.UseVisualStyleBackColor = true;
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
            this.cbLevels.SelectedIndexChanged += new System.EventHandler(this.cbLevels_SelectedIndexChanged);
            // 
            // bttSolveGame
            // 
            this.bttSolveGame.Location = new System.Drawing.Point(139, 39);
            this.bttSolveGame.Name = "bttSolveGame";
            this.bttSolveGame.Size = new System.Drawing.Size(75, 23);
            this.bttSolveGame.TabIndex = 6;
            this.bttSolveGame.Text = "Rozwiaz";
            this.bttSolveGame.UseVisualStyleBackColor = true;
            this.bttSolveGame.Click += new System.EventHandler(this.bttSolveGame_Click);
            // 
            // bttSaveGame
            // 
            this.bttSaveGame.Location = new System.Drawing.Point(139, 97);
            this.bttSaveGame.Name = "bttSaveGame";
            this.bttSaveGame.Size = new System.Drawing.Size(75, 23);
            this.bttSaveGame.TabIndex = 7;
            this.bttSaveGame.Text = "Zapisz";
            this.bttSaveGame.UseVisualStyleBackColor = true;
            this.bttSaveGame.Click += new System.EventHandler(this.bttSaveGame_Click);
            // 
            // bttLoadSaveGame
            // 
            this.bttLoadSaveGame.Location = new System.Drawing.Point(139, 68);
            this.bttLoadSaveGame.Name = "bttLoadSaveGame";
            this.bttLoadSaveGame.Size = new System.Drawing.Size(75, 23);
            this.bttLoadSaveGame.TabIndex = 8;
            this.bttLoadSaveGame.Text = "Wczytaj";
            this.bttLoadSaveGame.UseVisualStyleBackColor = true;
            this.bttLoadSaveGame.Click += new System.EventHandler(this.bttLoadSaveGame_Click);
            // 
            // sudokuTheGame
            // 
            this.AcceptButton = this.bttStartGame;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(484, 276);
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

        }

        #endregion

        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button bttStartGame;
        private System.Windows.Forms.ComboBox cbLevels;
        private System.Windows.Forms.Button bttSolveGame;
        private System.Windows.Forms.Button bttSaveGame;
        private System.Windows.Forms.Button bttLoadSaveGame;
    }
}

