using space_jump;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace space_jump
{
    public partial class FrmJump : Form
    {
        string[] valid_number = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        int number;
        Graphics g; //declare a graphics object called g
        // declare space for an array of 7 objects called asteroid 
        Asteroid[] asteroids = new Asteroid[12];
        Random xspeed = new Random();
        Mario mario1 = new Mario();
        Star Star = new Star();
        Heart Heart = new Heart();
       private bool left, right, Up, Down, jumping;
        string move;
        int score, lives;
        Rectangle starRec = new Rectangle(0, 0, 15, 17);
        Image star = Properties.Resources.Star1;
        Random rand = new Random();
        Rectangle heartRec = new Rectangle(0, 0, 16, 16);
        Image heart = Properties.Resources.Heart1;
        int gravity = 5;

        public FrmJump()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic, null, PnlGame, new object[] { true });
            for (int i = 0; i < 11; i++)
            {
                int y = 10 + (i * 75);
                asteroids[i] = new Asteroid(y);
            }
        }


        private void FrmJump_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { Up = true; }
            if (e.KeyData == Keys.Down) { Down = true; }
            if (e.KeyData == Keys.Space)  {  jumping = true; gravity = -5;}
            if (starRec.IntersectsWith(mario1.marioRec)) 
            {
                TmrStar.Enabled = true;
                starRec.X = rand.Next(800);
                starRec.Y = rand.Next(800);
                TmrStar.Enabled = false;
                score += 5;//add 5 to the score
                lblScore.Text = score.ToString();// display the score
                CheckScore();
            }
            if (heartRec.IntersectsWith(mario1.marioRec))
            {
                TmrHeart.Enabled = true;
                heartRec.X = rand.Next(800);
                heartRec.Y = rand.Next(800);
                TmrHeart.Enabled = false;
                lives += 1;//add 1 to lives 
                TxtLives.Text = lives.ToString();// display number of lives
                CheckLives();
            }

        }

        private void FrmJump_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { Up = false; }
            if (e.KeyData == Keys.Down) { Down = false; }
            if (e.KeyData == Keys.Space) {jumping = false; gravity = 5;}
        }

        private void FrmJump_Load(object sender, EventArgs e)
        {
           
            MessageBox.Show("Use the left, right, up and down arrow keys to move Mario around space. \n But beware of the asteroids rocketing towards you! \n Each time you dodge an asteroid a point is gained but every time you hit one a life is lost. \n If a star is caught 5 points will be added, and if a heart is caught a life will be added. \n \n Enter your Name (excluding spaces or numbers) and pick a number between 5 and 10 as your number of lives \n Click Start to begin", "Game Instructions");
            TxtName.Focus();
            TmrMario.Enabled = false;
            TmrStroid.Enabled = false;
        }

        private void MnuStart_Click_1(object sender, EventArgs e)
        {
            score = 0;
            lblScore.Text = score.ToString();
            lives = int.Parse(TxtLives.Text);// pass lives entered from textbox to lives variable
            TmrStroid.Enabled = true;
            TmrMario.Enabled = true;
            TxtName.Enabled = false;
            TxtLives.Enabled = false;
            TmrStar.Enabled = false;
            TmrHeart.Enabled = false;
        }

        private void MnuStop_Click_1(object sender, EventArgs e)
        {
            TmrMario.Enabled = false;
            TmrStroid.Enabled = false;
            TmrStar.Enabled = false;
        }

        private void TmrStroid_Tick_1(object sender, EventArgs e)
        {
            // score = 0;
            for (int i = 0; i < 11; i++)
            {
                asteroids[i].MoveAsteroid();

                if (mario1.marioRec.IntersectsWith(asteroids[i].asteroidRec))
                {
                    //reset planet[i] back to side of panel
                    asteroids[i].x = 15; // set  y value of asteroidRec
                    lives -= 1;// lose a life
                    TxtLives.Text = lives.ToString();// display number of lives
                    CheckLives();
                }
                //if a asteroid reaches the edge of the Game Area reposition it at the left
                if (asteroids[i].x >= PnlGame.Height)
                {
                    score += 1;//update the score
                    lblScore.Text = score.ToString();// display score
                    asteroids[i].x = 15;
                    CheckScore();

                }
                // score += asteroid[i].score;// get score from asteroid class (in moveAsteroid method)
                //lblScore.Text = score.ToString();// display score

            }

            PnlGame.Invalidate();//makes the paint event fire to redraw the panel
            if (Up) //if up key pressed 
            {
                if (mario1.y < 10)
                    //check to see if mario within 10 of up side
                    if (mario1.y < 10)//check to see if mario within 10 of top
                    {
                        mario1.y = 10;
                        //if it is < 10 away "bounce" it (set position at 10)
                    }
                    else
                    {
                        mario1.y -= 5;
                        //else move 5 up
                    }
            }
            if (Down) //if down key pressed 
            {
                if (mario1.y < 10)
                    //check to see if mario within 10 of up side
                    if (mario1.y < 10)//check to see if mario within 10 of top
                    {
                        mario1.y = 10;
                        //if it is < 10 away "bounce" it (set position at 10)
                    }
                    else
                    {
                        mario1.y += 5;
                        //else move 5 down
                    }
            }
        }

        private void TmrStar_Tick(object sender, EventArgs e)
        {
            
        }

        private void TxtLives_TextChanged(object sender, EventArgs e)
        {
            if (!valid_number.Contains(TxtLives.Text))
            {
                MessageBox.Show("Please enter a number from 5 to 10 only", "Error");
                TxtLives.Clear();//clear the textbox
                TxtLives.Focus();//cursor back in textbox
            }
            else
            {
                //convert string in textbox to a number
                number = int.Parse(TxtLives.Text);
                //Display number in second textbox
                TxtLives.Text = number.ToString();
            }
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the graphics used to paint on the panel control
            g = e.Graphics;
            //call the Asteroid class's DrawAsteroid method to draw the image asreroid
            for (int i = 0; i < 11; i++)
            {
                // generate a random number from 5 to 20 and put it in rndmspeed
                int rndmspeed = xspeed.Next(5, 20);
                asteroids[i].x += rndmspeed;

                //call the Asteroid class's drawAsteroid method to draw the images
                asteroids[i].DrawAsteroid(g);

            }
            mario1.DrawMario(g);
           
         

            g.DrawImage(star, starRec);
            g.DrawImage(heart, heartRec);
        }

        private void TmrHeart_Tick(object sender, EventArgs e)
        {
      
        }

        private void TmrMario_Tick_1(object sender, EventArgs e)
        {
            if (right) // if right arrow key pressed
            {
                move = "right";
                mario1.MoveMario(move);
            }
            if (left) // if left arrow key pressed
            {
                move = "left";
                mario1.MoveMario(move);
            }
            if (Down) // if down arrow key pressed
            {
                move = "Down";
                mario1.MoveMario(move);
            }
            if (Up) // if up arrow key pressed
            {
                move = "Up";
                mario1.MoveMario(move);
            }

            Invalidate();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

            string context = TxtName.Text;
            bool isletter = true;
            //for loop checks for letters as characters are entered 
            for (int i = 0; i < context.Length; i++)
            {
                if (!char.IsLetter(context[i]))//if current character not a letter
                {
                    isletter = false;//make isletter false
                    break; // exit the for loop
                }
            }
            //if not a letter clear the textbox and focus on it
            // to enter name again
            if (isletter == false)
            {
                TxtName.Clear();
                TxtName.Focus();
            }
            else
            {
                MnuStart.Enabled = true;
            }
        }

        private void CheckLives()
        {
            if (lives == 0)
            {
                TmrStroid.Enabled = false;
                TmrMario.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

        private void CheckScore()
        {
            if (score > 20)
            {
                TmrStroid.Interval = 10;
                TmrMario.Interval = 39;
            }
            if (score > 40)
            {
                TmrStroid.Interval = 18;
                TmrMario.Interval = 39;
            }
            if (score > 60)
            {
                TmrStroid.Interval = 16;
                TmrMario.Interval = 39;
            }
            if (score > 80)
            {
                TmrStroid.Interval = 14;
                TmrMario.Interval = 39;
            }
            if (score > 100)
            {
                TmrStroid.Interval = 12;
                TmrMario.Interval = 39;
            }
            if (score > 120)
            {
                TmrStroid.Interval = 10;
                TmrMario.Interval = 39;
            }
            if (score > 140)
            {
                TmrStroid.Interval = 8;
                TmrMario.Interval = 39;
            }
            if (score > 160)
            {
                TmrStroid.Interval = 6;
                TmrMario.Interval = 39;
            }
            if (score > 180)
            {
                TmrStroid.Interval = 4;
                TmrMario.Interval = 39;
            }
            if (score > 200)
            {
                TmrStroid.Interval = 2;
                TmrMario.Interval = 39;
            }
        }

    }
}
