using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace space_jump
{
    class Asteroid
    {
        // declare fields to use in the class
        public int x, y, width, height;//variables for the rectangle
        public Image asteroidImage;//variable for the Asteroid's image
        Random xspeed = new Random();
        public Rectangle asteroidRec;//variable for a rectangle to place our image in
        //Create a constructor (initialises the values of the fields)
        public Asteroid(int spacing)
        {
            y =spacing;
            x = 30;
            width = 17;
            height = 17;
            //asteroidImage contains the asteroid1.png image
            asteroidImage = Properties.Resources.asteroid1;
            asteroidRec = new Rectangle(x, y, width, height);
        }
        // Methods for the asteroid class
        public void DrawAsteroid(Graphics g)
        {
            asteroidRec = new Rectangle(x, y, width, height);
            g.DrawImage(asteroidImage, asteroidRec);
            
        }
        public void MoveAsteroid()
        {
            asteroidRec.Location = new Point(x, y);
        }

    }
}