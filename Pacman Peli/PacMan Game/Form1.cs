using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan_Game
{
    public partial class Game : Form
    {
        bool goup, godown, goleft, goright, isGameOver;

        int score, playerSpeed, redGhostSpeed, yellowGHostSpeed, pinkGhostX, pinkGhostY;

        public Game()
        {
            InitializeComponent();

            resetGame();
        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            //when key is pressed it is true
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if(e.KeyCode == Keys.Right)
            {
                goright = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            //when key is released it will turn to false again
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }

            //Next if loop is for reset game with ENTER
            if(e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void mainGameTimer(object sender, EventArgs e)
        {
            txtScore.Text = "Score: " + score;

            //these if booleans will change picture with the direction you press (up, down, left, right)
            if(goleft == true) //pacman change gif picture with direction to left
            {
                PacMan.Left -= playerSpeed;
                PacMan.Image = Properties.Resources.left; //"left" is the name of gif image
            }
            if(goright == true) //pacman change gif picture with direction to right
            {
                PacMan.Left += playerSpeed;
                PacMan.Image = Properties.Resources.right; //"right" is the name of gif image
            }
            if(goup == true) //packman change gif picture with direction to up
            {
                PacMan.Top -= playerSpeed;
                PacMan.Image = Properties.Resources.Up; //"Up" is the name of gif image
            }
            if(godown == true)
            {
                PacMan.Top += playerSpeed;
                PacMan.Image = Properties.Resources.down; //"down" is the name of gif image
            }

            //if loop for PacMan teleportation from left side of the screen to the right and vice versa
            if (PacMan.Left < -15) //teleporting right when moving left
            {
                PacMan.Left = 857;
            }
            if (PacMan.Left > 857) //teleporting left when moving right
            {
                PacMan.Left = -15;
            }

            //same as previous, only this one is teleports UP and DOWN
            if(PacMan.Top < 161) //teleporting down by moving up
            {
                PacMan.Top = 590;
            }
            if(PacMan.Top > 590) //teleporting up by moving down
            {
                PacMan.Top = 161;
            }

            //foreach loop for game mechanism
            foreach(Control x in this.Controls)
            {
                //this if loop is for coins
                if(x is PictureBox)
                {
                    if((string)x.Tag == "coin" && x.Visible ==true) //"&& x.Visible ==true" will provide to continue getting score after eating a coin, by removing it and staying on top of coin spot, you get infinity of score
                    {
                        if(PacMan.Bounds.IntersectsWith(x.Bounds))
                        {
                            score += 1;
                            x.Visible = false;
                        }
                    }
                }
                //wall mechanism, do not touch the wall or game over
                if((string)x.Tag == "wall")
                {
                    if(PacMan.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver(" You must not touch the walls! You lost!"); //game over message when you touch wall
                    }

                    //if loop for pink ghost to bounce walls
                    if(pinkGhost.Bounds.IntersectsWith(x.Bounds))
                    {
                        pinkGhostX = -pinkGhostX;
                    }
                }
                //ghosts mechanism, do not touch the ghost or game over
                if((string)x.Tag == "ghost")
                {
                    if(PacMan.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameOver(" You must not touch the ghosts! You lost!"); //game over message when you touch any ghost
                    }
                }
            }

            //moving ghosts
            redGhost.Left += redGhostSpeed;
            //if red ghost touch wall will bounce back (moving left and right)
            if(redGhost.Bounds.IntersectsWith(pictureBox2.Bounds) || redGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                redGhostSpeed = -redGhostSpeed;
            }

            yellowGhost.Left -= yellowGHostSpeed;
            //same thing with yellow ghost
            if(yellowGhost.Bounds.IntersectsWith(pictureBox4.Bounds) || yellowGhost.Bounds.IntersectsWith(pictureBox5.Bounds))
            {
                yellowGHostSpeed = -yellowGHostSpeed;
            }

            pinkGhost.Left -= pinkGhostX; //movement left and right
            pinkGhost.Top -= pinkGhostY; //movement up and down

            //pink ghost bounceing in game area. 1st if loop is for up and down and 2nd if loop for left and right
            if(pinkGhost.Top < 160 || pinkGhost.Top > 585)
            {
                pinkGhostY = -pinkGhostY;
            }
            
            if(pinkGhost.Left < 0 || pinkGhost.Left > 850)
            {
                pinkGhostX = -pinkGhostX;
            }

            //game over loop
            if (score == 57)
            {
                //message if you win
                gameOver(" You won!");
            }
        }

        private void resetGame()
        {
            txtScore.Text = "0";
            score = 0;

            //here is the speed for PacMan and Ghosts
            playerSpeed = 7;
            redGhostSpeed = 5;
            yellowGHostSpeed = 5;
            pinkGhostX = 5;
            pinkGhostY = 5;
            //pink ghost is moving any direction, that's why there is X and Y

            isGameOver = false;

            //here is the starting position (LEFT and TOP) for PacMan and Ghosts. They must be fixed
            PacMan.Left = 83;
            PacMan.Top = 230;

            redGhost.Left = 530;
            redGhost.Top = 230;

            yellowGhost.Left = 450;
            yellowGhost.Top = 500;

            pinkGhost.Left = 650;
            pinkGhost.Top = 400;

            //this "foreach" loop is for coins. If pacman have eaten coin it will hide this coin insted of removing it
            foreach(Control x in this.Controls) 
            {
                if(x is PictureBox)
                {
                    x.Visible = true;
                }
            }

            gameTimer.Start();
        }

        private void gameOver(string message) //shows message when game is over
        { //when game is over it stops the game and will show you message
            isGameOver = true;

            gameTimer.Stop();

            txtScore.Text += Environment.NewLine + message;
            //to show score at the end change previous line to:  txtScore.Text += Environment.NewLine + "Your Score: " + score + message;
        }
    }
}
