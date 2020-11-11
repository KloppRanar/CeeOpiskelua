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
        bool against_computer = false; //boolean to play againt AI
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
            if ((p1.Text == "1. Mängija") || (p2.Text == "2. Mängija"))
            {
                MessageBox.Show("Määritle 1. Mängija & 2. Mängija nimed enne kui alustad mängimist! \n \n Kirjutades 2. Mängija nimeks suurte tähtedega ai(AI) saad mängida arvuti vastu!");
            }
            else
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

                label2.Focus();
                checkForWinner();
            }

            //check to see if playing against computer and if it's O's turn
            if ((!turn) && (against_computer))
            {
            computer_make_move();
            }
        }

        private void computer_make_move()
        {
            //priority 1:  get tick tac toe
            //priority 2:  block x tic tac toe
            //priority 3:  go for corner space
            //priority 4:  pick open space

            Button move = null;

            //look for tic tac toe opportunities
            move = look_for_win_or_block("O"); //look for win
            if (move == null)
            {
                move = look_for_win_or_block("X"); //look for block
                if (move == null)
                {
                    move = look_for_corner();
                    if (move == null)
                    {
                        move = look_for_open_space();
                    }
                }
            }

            move.PerformClick();
        }

        private Button look_for_open_space()
        {
            Console.WriteLine("Looking for open space");
            Button b = null;
            foreach (Control c in Controls) // This is Arbitrary function what means that is not 100% random!
            {
                b = c as Button; //try to cast in control as button if possible (File, Help, Player names, score, board itself) or return null at the end
                if (b != null) //making sure that b is not null, what means we are looking for buttons
                {
                    if (b.Text == "") //if b.Text is empty that means button is not selected as a move jet
                        return b; // and will return as button
                }
            }
            return null;
        }

        private Button look_for_corner()
        {
            Console.WriteLine("Looking for corner");
            if (A1.Text == "O")
            {
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (A3.Text == "O")
            {
                if (A1.Text == "")
                    return A1;
                if (C3.Text == "")
                    return C3;
                if (C1.Text == "")
                    return C1;
            }

            if (C3.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C1.Text == "")
                    return C1;
            }

            if (C1.Text == "O")
            {
                if (A1.Text == "")
                    return A3;
                if (A3.Text == "")
                    return A3;
                if (C3.Text == "")
                    return C3;
            }

            if (A1.Text == "")
                return A1;
            if (A3.Text == "")
                return A3;
            if (C1.Text == "")
                return C1;
            if (C3.Text == "")
                return C3;

            return null;
        }

        private Button look_for_win_or_block(string mark)
        {
            Console.WriteLine("Looking for win or block:  " + mark);
            //HORIZONTAL TESTS
            if ((A1.Text == mark) && (A2.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A2.Text == mark) && (A3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (A3.Text == mark) && (A2.Text == ""))
                return A2;

            if ((B1.Text == mark) && (B2.Text == mark) && (B3.Text == ""))
                return B3;
            if ((B2.Text == mark) && (B3.Text == mark) && (B1.Text == ""))
                return B1;
            if ((B1.Text == mark) && (B3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((C1.Text == mark) && (C2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((C2.Text == mark) && (C3.Text == mark) && (C1.Text == ""))
                return C1;
            if ((C1.Text == mark) && (C3.Text == mark) && (C2.Text == ""))
                return C2;

            //VERTICAL TESTS
            if ((A1.Text == mark) && (B1.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B1.Text == mark) && (C1.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C1.Text == mark) && (B1.Text == ""))
                return B1;

            if ((A2.Text == mark) && (B2.Text == mark) && (C2.Text == ""))
                return C2;
            if ((B2.Text == mark) && (C2.Text == mark) && (A2.Text == ""))
                return A2;
            if ((A2.Text == mark) && (C2.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B3.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B3.Text == mark) && (C3.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C3.Text == mark) && (B3.Text == ""))
                return B3;

            //DIAGONAL TESTS
            if ((A1.Text == mark) && (B2.Text == mark) && (C3.Text == ""))
                return C3;
            if ((B2.Text == mark) && (C3.Text == mark) && (A1.Text == ""))
                return A1;
            if ((A1.Text == mark) && (C3.Text == mark) && (B2.Text == ""))
                return B2;

            if ((A3.Text == mark) && (B2.Text == mark) && (C1.Text == ""))
                return C1;
            if ((B2.Text == mark) && (C1.Text == mark) && (A3.Text == ""))
                return A3;
            if ((A3.Text == mark) && (C1.Text == mark) && (B2.Text == ""))
                return B2;

            return null;
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
            setPlayerDefaultsToolStripMenuItem.PerformClick();
        }

        private void p2_TextChanged(object sender, EventArgs e)
        {
            if (p2.Text.ToUpper() == "AI") // change player2 name to "ai -> AI" with capital letter ONLY will give you AI as opponent
            {
                against_computer = true;
            }
            else
            {
                against_computer = false;
            }
        }

        private void setPlayerDefaultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p1.Text = "1. Mängija";
            p2.Text = "AI";
        }
    }
}
