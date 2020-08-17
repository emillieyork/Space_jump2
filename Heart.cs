using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_jump
{
    class Heart
    {
        //declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image Heart22;//variable for the hearts image
        Random xspeed = new Random();
        public Rectangle heartRec;//variable for a rectangle to place 
        //create a constructor (initialises the value of the feilds)

        public Heart (int spacing)
        {
            x = 10;
            y = spacing;
            width = 20;
            height = 20;
            // Heart2 contains the pnlgame.png image
            Heart22 = Properties.Resources.Heart1;
            heartRec = new Rectangle(x, y, width, height);
            
        }
        //method for the Heart class

        public void DrawHeart(Graphics g)
        {
            heartRec = new Rectangle(x, y, width, height);
            g.DrawImage(Heart22, heartRec);

        }
    }
}
