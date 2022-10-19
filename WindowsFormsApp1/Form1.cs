using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Windows.Input;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string userchoice, enemychoice;
        string[] choices= { "Rock", "Paper", "Scissor" };
        int unchoice;
        int enchoice;
        int result;

        public Form1()
        {
            InitializeComponent();
            soundBGM();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = (Properties.Resources.uRock);
            pictureBox2.Image = (Properties.Resources.eRock);
        }


        private void soundBGM() {

        }
        private void win() {
            label2.ForeColor = System.Drawing.Color.LightGreen;
            label2.Text = "You won!";
            label3.Text = "YOU: "+choices[unchoice]+"           Enemy: " + choices[enchoice];
        }
        private void lose() {
            label2.ForeColor = System.Drawing.Color.LightCoral;
            label2.Text = "You Lose!";
            label3.Text = "YOU:"+choices[enchoice] + "           Enemy: " + choices[unchoice];
        }
        private void draw()
        {
            label2.ForeColor = System.Drawing.Color.LightYellow;
            label2.Text = "It's a Draw!";
            label3.Text = "YOU: "+choices[unchoice] + "          Enemy: " + choices[enchoice];
        }


        private void enemyChoice() {
            Random random = new Random();
            int rand = random.Next(3);
            string[] rpc = { "Rock", "Paper", "Scissor" };
            enemychoice = rpc[rand];
            enchoice = rand;
            
            if (rand == 0)
            {
                pictureBox2.Image = (Properties.Resources.eRock);
            }
            else if (rand == 1) {
                pictureBox2.Image = (Properties.Resources.ePaper);
            }
            else
            {
                pictureBox2.Image = (Properties.Resources.eScissors);
            }

        }
        private int calcWinner(int p1, int p2) {
            int results;
            if ((p1 + 1) % 3 == p2)
            {
                //return "Enemy Won";
                results = 0;
                return results;
            }
            else if (p1 == p2)
            {
                //return "It is a draw";
                results = 1;
                return results;
            }
            else
            {
                //return "You Won!";
                results = 2;
                return results;
            }

        }
        private void tellresults() {
            result = calcWinner(unchoice, enchoice);
            if (result == 0)
            {
                lose();
            }
            else if (result == 1) {
                draw();
            } else{
                win();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            enemyChoice();
           
            unchoice = 0;
            calcWinner(unchoice, enchoice);
            tellresults();
            pictureBox1.Image = (Properties.Resources.uRock);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            enemyChoice(); 
            unchoice = 1;
            calcWinner(unchoice, enchoice);
            tellresults();
            pictureBox1.Image = (Properties.Resources.uPaper);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"Resources\uRock.png";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int rand = random.Next(3);
            pictureBox2.Image= imageList1.Images[rand];
        }







        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enemyChoice();
            unchoice = 2;
            calcWinner(unchoice, enchoice);
            tellresults();
            pictureBox1.Image = (Properties.Resources.uScissors2);
        }
    }
}
