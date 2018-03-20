using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SudokuTheGame
{
    public partial class sudokuTheGame : Form
    {
        TextBox[,] textBoxes = new TextBox[9, 9];

        int level;

        Random randomNumber = new Random();

        public sudokuTheGame()
        {
            InitializeComponent();
            generateGrid();
            guiTextes();
        }

        void guiTextes()
        {
            //add list to combo box for choose level
            cbLevels.Items.Add("Łatwy");
            cbLevels.Items.Add("Średni");
            cbLevels.Items.Add("Trudny");
        }

        private void generateGrid()
        {
            int positionX = 0;
            int positionY = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j] = new TextBox();
                    panel.Controls.Add(textBoxes[i, j]);
                    textBoxes[i, j].Width = 20;
                    textBoxes[i, j].Top = positionY;
                    textBoxes[i, j].Left = positionX;
                    textBoxes[i, j].TextAlign = HorizontalAlignment.Center;
                    //textBoxes[i, j].Text =  i.ToString() + j.ToString(); //show id equal to id in array on GUI
                    positionX = positionX + 26;
                }
                positionY = positionY + 26;
                positionX = 0;
            }
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 4);
            g.DrawLine(p, 75, 0, 75, 228);
            g.DrawLine(p, 153, 0, 153, 228);
            g.DrawLine(p, 0, 75, 228, 75);
            g.DrawLine(p, 0, 153, 228, 153);
        }

        private void bttStartGame_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
            switch (level)
            {
                case 1:
                    //MessageBox.Show("Easy");
                    fillTextBoxes(70);
                    break;
                case 2:
                    //MessageBox.Show("Medium");
                    fillTextBoxes(50);
                    break;
                case 3:
                    //MessageBox.Show("Hard");
                    fillTextBoxes(20);
                    break;
                default:
                    MessageBox.Show("Wybierz poziom trudności!");
                    break;
            }
        }

        private void cbLevels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLevels.SelectedIndex == 0)
            {
                level = 1;//easy level
            }
            else if (cbLevels.SelectedIndex == 1)
            {
                level = 2;//medium level
            }
            else if (cbLevels.SelectedIndex == 2)
            {
                level = 3;//hard level
            }
            else return;
        }

        private void fillTextBoxes(int amount)
        {
            int i, j;
            for (int a = 0; a < amount; a++)
            {
                i = randomNumber.Next(9);
                j = randomNumber.Next(9);
                textBoxes[i, j].Text = randomNumber.Next(1, 9).ToString();
                textBoxes[i, j].ReadOnly = true;
            }
        }

        //setting the value to null for every textbox to clear them after the last one game 
        private void clearTextBoxes()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j].Text = null;
                    textBoxes[i, j].ReadOnly = false;
                }
            }
        }
    }
}

