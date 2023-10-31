namespace Open_The_Safe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            code = new int[3];
            random = new Random();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Submit button
            checkWin();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Start Button Click
            for (int i = 0; i < 3; i++)
            {
                code[i] = random.Next(10);
            }
            lives = 5;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            button1.Enabled = true;
            button3.Enabled = false;
            textBox2.Text = "";
            pictureBox1.Image = pictureBox1.ErrorImage;
            bet = (int)numericUpDown4.Value;
            money -= bet;
            fixMoney();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cheat Button
            string answer;
            answer = code[0] + "," + code[1] + "," + code[2];
            textBox1.Text = answer;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void checkWin()
        {
                wordle();
            if (numericUpDown1.Value == code[0] && numericUpDown2.Value == code[1] && numericUpDown3.Value == code[2])
            {
                numericUpDown2.Enabled = false;
                numericUpDown1.Enabled = false;
                numericUpDown3.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = true;
                textBox1.Text = "You Win";
                pictureBox1.Image = pictureBox1.InitialImage;
                pictureBox1.Size = new Size(256, 212);
                money += (2 * bet);
                fixMoney();
            }
            else
            {
                string turn;
                turn = numericUpDown1.Value + "," + numericUpDown2.Value + "," + numericUpDown3.Value;
                lives--;
                if (lives <= 0)
                {
                    numericUpDown2.Enabled = false;
                    numericUpDown1.Enabled = false;
                    numericUpDown3.Enabled = false;
                    button1.Enabled = false;
                    button3.Enabled = true;
                    textBox1.Text = "You LOSE!";
                }
                if ((numericUpDown1.Value == code[0] && numericUpDown2.Value == code[1]) || (numericUpDown1.Value == code[0] && numericUpDown3.Value == code[2]) || (numericUpDown3.Value == code[2] && numericUpDown2.Value == code[1]))
                {
                    turn += " - Close!";
                    pictureBox1.Image = pictureBox1.InitialImage;
                    pictureBox1.Size = new Size(125, 106);
                }
                else if (numericUpDown1.Value == code[0] || numericUpDown2.Value == code[1] || numericUpDown3.Value == code[2])
                {
                    turn += " - only one loser";
                }
                else
                {
                    turn += " - way off you loser!";
                }
                textBox2.AppendText("\r\n" + turn);
            }
        }

        private void fixMoney()
        {
            textBox3.Text = "Money: " + money;
        }

        private void wordle()
        {
            if (numericUpDown1.Value == code[0]) {
                numericUpDown1.BackColor = Color.Green;
            } else if (numericUpDown1.Value == code[1] || numericUpDown1.Value == code[2]){
                numericUpDown1.BackColor = Color.Yellow;
            } else
            {
                numericUpDown1.BackColor = Color.Red;
            }

            if (numericUpDown2.Value == code[1])
            {
                numericUpDown2.BackColor = Color.Green;
            }
            else if (numericUpDown2.Value == code[0] || numericUpDown2.Value == code[2])
            {
                numericUpDown2.BackColor = Color.Yellow;
            }
            else
            {
                numericUpDown2.BackColor = Color.Red;
            }

            if (numericUpDown3.Value == code[2])
            {
                numericUpDown3.BackColor = Color.Green;
            }
            else if (numericUpDown3.Value == code[1] || numericUpDown3.Value == code[0])
            {
                numericUpDown3.BackColor = Color.Yellow;
            }
            else
            {
                numericUpDown3.BackColor = Color.Red;
            }
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}