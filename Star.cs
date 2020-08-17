using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace space_jump
{
    class Star
    {
        //declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image Star2;//variable for the stars image
        Random xspeed = new Random();
        public Rectangle starRec;//variable for a rectangle to place 
        //create a constructor (initialises the value of the feilds)

        public Star(int spacing)
        {
            x = 10;
            y = spacing;
            width = 20;
            height = 20;
            // Star2 contains the pnlgame.png image
            Star2 = Properties.Resources.Star1;
           starRec = new Rectangle(x, y, width, height);

        }
        //method for the star class

        public void DrawStar(Graphics g)
        {
            starRec = new Rectangle(x, y, width, height);
            g.DrawImage(Star2, starRec);

        }
    }
}
