using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace SudokuTheGame
{
    public partial class sudokuTheGame : Form
    {

        TextBox[,] textBoxes = new TextBox[9, 9];

        int[,] arrayGlobalValues = new int[9, 9];
        int[,,] arrayLocalValues = new int[3, 3, 9]; // 3 = x,3 = y,9 = z -> which mean that we have 9 * 3x3 arrays 

        int level;

        Random randomNumber = new Random();

        public sudokuTheGame()
        {
            InitializeComponent();
            generateGrid();
            fillGUITexts();
        }

        void fillGUITexts()
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
                    textBoxes[i, j].MaxLength = 1; //allow to put only one value to the textbox
                    textBoxes[i, j].KeyPress += new KeyPressEventHandler(checkValue);
                    //textBoxes[i, j].Text =  i.ToString() + j.ToString(); //show id on GUI equal to id in array 
                    positionX = positionX + 26;
                }
                positionY = positionY + 26;
                positionX = 0;
            }
        }

        //is checking if pressed key is digit 1-9 or delete/backspace key 
        private void checkValue(object sender, KeyPressEventArgs e)
        {
            char value = e.KeyChar;

            if (!Char.IsDigit(value) || value == 48) //numbers are from ascii table // 8 is for backspace key, 48 is for 0 key bcs in sudoku i cannot put 0 to table
            {
                e.Handled = true;
                MessageBox.Show("Mozesz wprowadzac tylko liczby!");
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
            clearTextBoxesAndArrays();
            switch (level)
            {
                case 1:
                    //MessageBox.Show("Easy");
                    generateRandomNumbForGame(70);
                    break;
                case 2:
                    //MessageBox.Show("Medium");
                    generateRandomNumbForGame(50);
                    break;
                case 3:
                    //MessageBox.Show("Hard");
                    generateRandomNumbForGame(20);
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


        //smth
        private void generateRandomNumbForGame(int amount)
        {
            int i, j;
            for (int a = 0; a < amount; a++)
            {
                i = randomNumber.Next(9);
                j = randomNumber.Next(9);
                int value = randomNumber.Next(1, 9);
                //Console.WriteLine("Random number: " + value + " step: " + a);
                
                for(int ai = 0; ai < 9 ; ai++)
                {
                    for(int aj=0; aj < 9; aj++)
                    {
                        if(ai == i && aj == j) continue;

                        if(ai == i)
                        {
                            //check x axis if exist equal value to this what was random drawn
                            if()
                            {
                                
                                ///TODO

                            }
                        }


                    }
                }
                
                textBoxes[i, j].Text = value.ToString();
                textBoxes[i, j].ReadOnly = true;
            }
        }

        private void checkValueInArray()
        {

        }


        //clearing game panel
        private void clearTextBoxesAndArrays()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j].Text = null;
                    textBoxes[i, j].ReadOnly = false;
                }
            }

            Array.Clear(arrayGlobalValues, 0, Math.Min(81, arrayGlobalValues.Length));//setting all values in array to null
            Array.Clear(arrayLocalValues, 0, Math.Min(81, arrayLocalValues.Length));//https://www.dotnetperls.com/array-clear
        }
    }
}

