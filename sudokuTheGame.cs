using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SudokuTheGame
{
    public partial class sudokuTheGame : Form
    {

        TextBox[,] textBoxes = new TextBox[9, 9];

        int[,] arrayGlobalValues = new int[9, 9];

        int level;

        private bool block;
        private bool editedByUser;
        private bool isSolving;

        Random randomNumber = new Random();

        #region getters/setters

        public bool getBlock()
        {
            return block;
        }

        public void setBlock(bool value)
        {
            block = value;
        }

        public bool getEditedByUser()
        {
            return editedByUser;
        }

        public void setEditedByUser(bool value)
        {
            editedByUser = value;
        }

        public bool getIsSolving()
        {
            return isSolving;
        }

        public void setIsSolving(bool value)
        {
            isSolving = value;
        }
        
        #endregion

        public sudokuTheGame()
        {
            InitializeComponent();
            generateGrid();
            fillGUITexts();
        }

        void fillGUITexts()
        {
            //add list to combo box for choose level
            cbLevels.Items.Add("Łatwy");      //easy
            cbLevels.Items.Add("Średni");    //medium
            cbLevels.Items.Add("Trudny");   //hard
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
                    panelGame.Controls.Add(textBoxes[i, j]);
                    textBoxes[i, j].Width = 20;
                    textBoxes[i, j].Top = positionY;
                    textBoxes[i, j].Left = positionX;
                    textBoxes[i, j].TextAlign = HorizontalAlignment.Center;
                    textBoxes[i, j].MaxLength = 1; //allow to put only one value to the textbox
                    textBoxes[i, j].KeyPress += new KeyPressEventHandler(checkEnteredValue);
                    textBoxes[i, j].Name = i.ToString() + j.ToString();
                    //textBoxes[i, j].Text =  i.ToString() + j.ToString(); //show id on GUI equal to id in array 
                    positionX = positionX + 26;
                }
                positionY = positionY + 26;
                positionX = 0;
;
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
                    generateRandomNumbForGame(50);
                    break;
                case 2:
                    //MessageBox.Show("Medium");
                    generateRandomNumbForGame(40);
                    break;
                case 3:
                    //MessageBox.Show("Hard");
                    generateRandomNumbForGame(30);
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

        //is checking if pressed key is digit 1-9 or delete/backspace key 
        private void checkEnteredValue(object sendedObject, KeyPressEventArgs e)
        {
            e.Handled = false;
            setEditedByUser(false);

            char value = e.KeyChar;
            TextBox sendedTextBox = (TextBox)sendedObject;

            //TODO REPAIR BACKSPACE KEY!!!

            if (!Char.IsDigit(value) || value == 48 || value == 8) //numbers are from ascii table // 8 is for backspace key, 48 is for 0 key
            {
                e.Handled = true;
                MessageBox.Show("Mozesz wprowadzac tylko liczby za zakresu 1-9!");
            }
            else
            {
                int i = int.Parse(sendedTextBox.Name[0].ToString());
                int j = int.Parse(sendedTextBox.Name[1].ToString());
                setBlock(false);

                checkIfValueIsRepeating(i, j, value);

                if(getBlock() == true)
                {
                    e.Handled = true;
                }
                else
                {
                    Console.WriteLine("Index of this textbox is " + i + "," + j);

                    checkIfValueIsRepeating(i, j, int.Parse(value.ToString()));
                    if (getBlock() == true || sendedTextBox.ReadOnly == true)
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                        setEditedByUser(true);
                        addValueToTBAndArray(i, j, int.Parse(value.ToString()), 0);
                    }
                    Console.WriteLine(arrayGlobalValues);
                }
            }
        }

        private void checkIfValueIsRepeating(int i, int j, int value)
        {
            setBlock(false);
         
            //i is for x axis and j is for y axis
            int startIPositionQuarter = 0;
            int startJPositionQuarter = 0;

            if (i < 3) startIPositionQuarter = 0;
            else if (i >= 3 && i < 6) startIPositionQuarter = 3;
            else if (i >= 6) startIPositionQuarter = 6;

            if (j < 3) startJPositionQuarter = 0;
            else if (j >= 3 && j < 6) startJPositionQuarter = 3;
            else if (j >= 6) startJPositionQuarter = 6;

            for (int ai = 0; ai < 9; ai++) //ai = array i; aj = array j
            {
                for (int aj = 0; aj < 9; aj++)
                {

                    if (ai == i && aj == j) continue;

                    //check x axis if exist equal value to this random rolled
                    if (ai == i)
                    {
                        if (!string.IsNullOrWhiteSpace(textBoxes[ai, aj].Text)) // IsNullOrWhiteSpace contains null, empty and whitespace
                        {
                            if (int.Parse(textBoxes[ai, aj].Text) == value)
                            {
                                Console.WriteLine("It`s the same value in line! i,j: " + i + "," + j + "ai,aj: " + ai + "," + aj);
                                setBlock(true);
                                break;
                            }
                        }
                    }

                    //check y axis
                    if (aj == j)
                    {
                        if (!string.IsNullOrWhiteSpace(textBoxes[ai, aj].Text))
                        {
                            if (int.Parse(textBoxes[ai, aj].Text) == value)
                            {
                                Console.WriteLine("It`s the same value in column! i,j: " + i + "," + j + "ai,aj: " + ai + "," + aj);
                                setBlock(true);
                                break;
                            }
                        }
                    }

                    //check square 3x3
                    if (ai >= startIPositionQuarter && ai < (startIPositionQuarter + 3) && aj >= startJPositionQuarter && aj < (startJPositionQuarter + 3))
                    {
                        if (!string.IsNullOrWhiteSpace(textBoxes[ai, aj].Text))
                        {
                            if (int.Parse(textBoxes[ai, aj].Text) == value)
                            {
                                Console.WriteLine("It`s the same value in square! i,j: " + i + "," + j + "ai,aj: " + ai + "," + aj);
                                setBlock(true);
                                break;
                            }
                        }
                    }
                }
            }
        }

        //it`s adding value (generated randomly/entered by user) to text box and array 
        private void addValueToTBAndArray(int i, int j, int value, int step)
        {
            textBoxes[i, j].Text = value.ToString();
            if(getEditedByUser() == false) textBoxes[i, j].Enabled = false;
            if(getIsSolving() == true) textBoxes[i, j].Enabled = true;
            arrayGlobalValues[i, j] = value;
            Console.WriteLine("Entered number: " + value  + " to textbox ID: " + i + j + " step: " + step);
        }

        //smth
        private void generateRandomNumbForGame(int amount)
        {
            int i, j, value, a;

            for (a = 0; a < amount; a++)
            {
                setBlock(false);
                i = randomNumber.Next(9);
                j = randomNumber.Next(9);
                value = randomNumber.Next(1, 9);
                Console.WriteLine("Randomly rolled number is: " + value);

                checkIfValueIsRepeating(i,j,value);

                if ((getBlock() == false && string.IsNullOrWhiteSpace(textBoxes[i, j].Text)))
                {
                    addValueToTBAndArray(i, j, value, amount);
                }
                else amount++;
            }
        }

        //clearing game panel
        private void clearTextBoxesAndArrays()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    textBoxes[i, j].Text = null;
                    textBoxes[i, j].Enabled = true;
                }
            }

            setIsSolving(false);
            setEditedByUser(false);
            Array.Clear(arrayGlobalValues, 0, arrayGlobalValues.Length);//setting all values in array to null
            
        }

        // THIS IS SOME KIND OF JOKE REPAIR IT!!!
        private void gameSolver()
        {
            int value = 1, i, j;
            int steps = 0;
            setIsSolving(true);
            {
                foreach (TextBox textBox in textBoxes)
                {
                    i = int.Parse(textBox.Name[0].ToString());
                    j = int.Parse(textBox.Name[1].ToString());

                    if (String.IsNullOrWhiteSpace(textBox.Text.ToString()) || textBoxes[i, j].Enabled == true)
                    {
                        Console.WriteLine("Name of empty textbox: " + i + "," + j);
                        steps = 0;
                        do
                        {
                            steps++;
                            checkIfValueIsRepeating(i, j, value);
                            if (getBlock() == false)
                            {
                                addValueToTBAndArray(i, j, value, 0);
                            }
                            if (value > 8) value = 1;
                            else value++;
                            if (steps > 10) break;
                        }
                        while (String.IsNullOrWhiteSpace(textBox.Text.ToString()));
                    }
                }
            }
        }

        #region load/save game

        private void saveGameToFile()
        {
            using (var sw = new StreamWriter(@"mojagra.stg"))
            {
                for(int i = 0; i <9; i++)
                {
                    for(int j = 0; j <9; j++)
                    {
                        sw.Write(arrayGlobalValues[i, j] + " ");
                    }
                    sw.Write(Environment.NewLine); // \n isn`t working DNW
                }
                sw.Flush();//clear stream writer buffer 
                sw.Close();//close stream writer
            }
        }

        private void loadSaveGame()
        {
            try
            {
                clearTextBoxesAndArrays();
                string input = File.ReadAllText(@"mojagra.stg");
                int value;
                int i = 0, j = 0;
                foreach (var row in input.Split('\n'))
                {
                    j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                       if (!string.IsNullOrWhiteSpace((col.Trim())))
                        {

                            value = int.Parse(col.Trim()); //if we will have a error with parsing, that is sign that user propably put a letter or something other then digit to text file and message box will be showed

                            setBlock(false);

                            if (value != 0)
                            {
                                checkIfValueIsRepeating(i, j, value); //here we are checking if all digits entered by user are uniqe for col,row,quad3x3 if not, it`s setting to null

                                if (getBlock() == false && value.ToString().Length == 1)
                                {
                                    addValueToTBAndArray(i, j, value, 0);
                                }
                            }
                            else
                            {
                                textBoxes[i, j].Text = null;
                            }
                            Console.WriteLine(value);
                        }
                        j++;
                    }
                    i++;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show("BLAD: " + ex);
                MessageBox.Show("Niema pliku mySaveGame.stg bądz jest źle sformatowany.\nMożesz używać tylko LICZB z zakresu 1-9");
            }
        }

        #endregion

        #region button on click void`s

        private void bttSaveGame_Click(object sender, EventArgs e)
        {
            saveGameToFile();
        }

        private void bttLoadSaveGame_Click(object sender, EventArgs e)
        {
            loadSaveGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            takeScreenShot();
        }

        private void bttSolveGame_Click(object sender, EventArgs e)
        {
            gameSolver();
        }

        #endregion

        private void takeScreenShot()
        {
            Bitmap bmp = new Bitmap(panelGame.Width, panelGame.Height);
            panelGame.BackColor = Color.White;
            panelGame.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            panelGame.BackColor = Color.Transparent;
            bmp.Save(@"MojaGra.bmp");
        }
    }
}

