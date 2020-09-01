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
        public Image star;//variable for the stars image
        public Rectangle starRec;//variable for a rectangle to place 
        //create a constructor (initialises the value of the feilds)

        public Star()
        {
            x = 384;
            y = 400;
            width = 20;
            height = 20;
            // Heart2 contains the pnlgame.png image
            star = Properties.Resources.Heart1;
            starRec = new Rectangle(x, y, width, height);

        }
        //method for the Heart class

        public void DrawStar(Graphics g)
        {
            g.DrawImage(star, starRec);

        }
    }
}
