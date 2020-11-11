using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = player X turn; false = player  Y turn
        int turn_count = 0;
        //static String player1, player2; //code for >>>Form1_Load<<< (At the end of program)
        public Form1()
        {
            InitializeComponent();
        }
        /*  //Code for setting player name before playing
        public static void setPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }
        */
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tere Mängija! \n \n 1. Võitmiseks tuleb sul saada esimesena täis horisontaalselt, vertikaalselt või diogonaalselt 3 järjestikust ruutu \n \n 2. I mängija on alati X ja II mängija alati O \n \n 3. Nautige mängimist!", "Reeglid");
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            { 
                b.Text = "X";
            }
            else
            { 
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            bool there_is_a_winner = false;

            //horizontal check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            { 
                there_is_a_winner = true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            { 
                there_is_a_winner = true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            { 
                there_is_a_winner = true;
            }

            //vertical check
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            { 
                there_is_a_winner = true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            { 
                there_is_a_winner = true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            { 
                there_is_a_winner = true;
            }

            //diagonal check
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            { 
                there_is_a_winner = true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
            { 
                there_is_a_winner = true;
            }

            if (there_is_a_winner) //start checkForWinner
            {
                disableButtons();

                String winner = "";
                if (turn)
                {
                    winner = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();

                }
                MessageBox.Show("Mängija " + winner + " võitis sellel korral!", "Suured õnnitlused!");
            }
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();

                    MessageBox.Show("Sellel korral puudub võitja, kuulutan välja viigi! Proovige uuesti", "Viiiiik!");
                }
            }

        }//end checkForWinner

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                Button b = (Button)c;
                c.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

                foreach (Control c in Controls)
                {
                    try
                    {
                        Button b = (Button)c;
                        c.Enabled = true;
                        b.Text = "";
                    }
                    catch { }
                }
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            { 
                if(turn)
                { 
                    b.Text = "X";
                }
                else
                { 
                    b.Text = "O";
                }
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            x_win_count.Text = "0";
            draw_count.Text = "0";
            o_win_count.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*  //Code for form to choose names BEFORE game, where you cannot change names!
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label3.Text = player2;
            */
        }
    }
}
