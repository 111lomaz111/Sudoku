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
        int blockedValue = 0;
        private bool isSolving, editedByUser;

        Random randomNumber = new Random();

        #region getters/setters

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
#if DEBUG
            bttDEBUG.Visible = true;
#endif
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

        //is checking if pressed key is digit 1-9
        private void checkEnteredValue(object sendedObject, KeyPressEventArgs e)
        {
            e.Handled = false;
            setEditedByUser(false);

            TextBox sendedTextBox = (TextBox)sendedObject;

            if (!Char.IsDigit(e.KeyChar) || e.KeyChar == 48) //numbers are from ascii table, 48 is for number 0
            {
                e.Handled = true;
                MessageBox.Show("Mozesz wprowadzac tylko liczby za zakresu 1-9!");
            }
            else
            {
                int value = int.Parse(e.KeyChar.ToString());
                int i = int.Parse(sendedTextBox.Name[0].ToString());
                int j = int.Parse(sendedTextBox.Name[1].ToString());

                if(isValueRepeating(i, j, value))
                {
                    e.Handled = true;
                }
                else
                {
                    Console.WriteLine("Index of this textbox is " + i + "," + j);
                    setEditedByUser(true);
                    addValueToTBAndArray(i, j, value, 0);
                }
            }
        }

        private bool isValueRepeating(int i, int j, int value)
        {
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
                                return true;
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
                                return true;
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
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        //it`s adding value (generated randomly/entered by user) to text box and array 
        private void addValueToTBAndArray(int i, int j, int value, int step)
        {
            textBoxes[i, j].Text = value.ToString();
            arrayGlobalValues[i, j] = value;

            if (getEditedByUser() == false) textBoxes[i, j].Enabled = false;
            if (getIsSolving() == true) textBoxes[i, j].Enabled = true;

            Console.WriteLine("Entered number: " + value  + " to textbox ID: " + i + "," + j + " step: " + step);
        }

        //smth
        private void generateRandomNumbForGame(int amount)
        {
            int i, j, value, a;

            for (a = 0; a < amount; a++)
            {
                i = randomNumber.Next(9);
                j = randomNumber.Next(9);
                value = randomNumber.Next(1, 9);
                Console.WriteLine("Randomly rolled number is: " + value);                

                if (!isValueRepeating(i, j, value) && string.IsNullOrWhiteSpace(textBoxes[i, j].Text))
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
            Array.Clear(arrayGlobalValues, 0, arrayGlobalValues.Length);//setting all values in array to null            
        }

        private void clearEnabledFields()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (textBoxes[i, j].Enabled == true)
                    {
                        textBoxes[i, j].Text = null;
                    }
                    else return;
                }
            }
        }

        private void gameSolver(int startI, int startJ, int startValue)
        {
            int value = startValue;
            int steps;

            setIsSolving(true);

            for (int i = startI; i < 9; ++i)
            {
                for (int j = startJ; j < 9; ++j)
                {
                    if (textBoxes[i, j].Enabled == true)
                    {
                        steps = 0;
                        do
                        {
                            steps++;
                            value++;

                            if (value > 9) value = 1;

                            if (!isValueRepeating(i, j, value) && value != blockedValue)
                            {
                                addValueToTBAndArray(i, j, value, 0);
                                blockedValue = 0;
                                MessageBox.Show("DONE");
                                break;
                            }

                            if (steps > 8)
                            {
                                do
                                {
                                    j--;

                                    if (j < 0)
                                    {
                                        j = 8;
                                        if (i > 0) i--;
                                        else i = 0;
                                    }

                                    if (textBoxes[i, j].Enabled == true)
                                    {
                                        if (!String.IsNullOrWhiteSpace(textBoxes[i, j].Text)) blockedValue = int.Parse(textBoxes[i, j].Text);
                                        else blockedValue = 0;

                                        textBoxes[i, j].Text = null;

                                        Console.WriteLine("Steps: " + steps);
                                        gameSolver(i, j, blockedValue);
                                    }
                                }
                                while (textBoxes[i, j].Enabled == false);
                            }
                        }
                        while (String.IsNullOrWhiteSpace(textBoxes[i, j].Text));
                    }
                }
            }
        }


        /* // THIS IS SOME KIND OF JOKE REPAIR IT!!!

        private void gameSolver(int otherI, int otherJ, int startValue)
        {
            int steps;
            int value = startValue;

            setIsSolving(true);
            {
                for (int i = otherI; i < 9; i++)
                {
                    for (int j = otherJ; j < 9; j++)
                    {
                        if (String.IsNullOrWhiteSpace(textBoxes[i, j].Text.ToString()) || textBoxes[i, j].Enabled)
                        {
                            Console.WriteLine("Name of empty/editable textbox: " + i + "," + j);
                            steps = 0;
                            do
                            {
                                steps++;
                                value++;
                                if (value > 9) value = 1;

                                if (!isValueRepeating(i, j, value))
                                {
                                    addValueToTBAndArray(i, j, value, 0);
                                    MessageBox.Show("DONE");
                                    if (j < 9) j++;
                                    else if (j == 9)
                                    {
                                        j = 0;
                                        i++;
                                    }
                                    else if (i == 9 && j == 9)
                                    {
                                        MessageBox.Show("OVER");
                                        return;
                                    }
                                    gameSolver(i, j, value);
                                    break;
                                }

                                if (steps > 9)
                                {
                                    startValue = value;

                                    if (j == 0 && i >= 0)
                                    {
                                        j = 8;
                                        if (i > 0) i--;
                                    }
                                    else if (j > 0) j--;

                                    value = int.Parse(textBoxes[i, j].Text.ToString());
                                    textBoxes[i, j].Text = null;

                                    gameSolver(i, j, value);
                                }
                            }
                            while (String.IsNullOrWhiteSpace(textBoxes[i, j].Text.ToString()));
                        }
                        else
                        {
                            if (j < 9) j++;
                            else if (j == 9)
                            {
                                j = 0;
                                i++;
                            }
                            else if (i >= 9 && j >= 9)
                            {
                                MessageBox.Show("IT`S OVER");
                                return;
                            }
                        }
                    }
                }
            }
        }
        */

        #region load/save game

        private void saveGameToFile()
        {
            using (var sw = new StreamWriter("mojagra.stg"))
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
                string input = File.ReadAllText("mojagra.stg");
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

                            if (value != 0)
                            {
                                if (!isValueRepeating(i, j, value) && value.ToString().Length == 1)
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
#if DEBUG
                MessageBox.Show("BLAD: " + ex);
#else
                MessageBox.Show("Niema pliku mySaveGame.stg bądz jest źle sformatowany!\n" +
                    "Możesz używać tylko LICZB z zakresu 1-9,\n" +
                    "oraz musisz rozdzielać je spacją!");
#endif
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
            gameSolver(0,0,0);
        }

        private void bttDEBUG_MouseClick(object sender, MouseEventArgs e)
        {
            clearEnabledFields();
        }
        #endregion



        private void takeScreenShot()
        {
            Bitmap bmp = new Bitmap(panelGame.Width, panelGame.Height);
            panelGame.BackColor = Color.White;
            panelGame.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
            panelGame.BackColor = Color.Transparent;
            bmp.Save("MojaGra.bmp");
        }
    }
}

