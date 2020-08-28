using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace space_jump
{
        class Mario
        {
            // declare fields to use in the class
            public int x, y, width, height;//variables for the rectangle
            public Image mario1;//variable for Mario's image
            public Rectangle marioRec;//variable for a rectangle to place our image in
            //Create a constructor (initialises the values of the fields)
            public Mario()
            {
                x = 900;
                y = 360;
                width = 40;
                height = 60;
                mario1 = Properties.Resources.Mario1;
                marioRec = new Rectangle(x, y, width, height);
            }
            //methods
            public void DrawMario(Graphics g)
            {

                g.DrawImage(mario1, marioRec);
            }
            public void MoveMario(string move)
            {
                marioRec.Location = new Point(x, y);

                if (move == "right")
                {
                    if (marioRec.Location.X > 10) // is mario within 50 of right side
                    {


                        x += 5;
                        marioRec.Location = new Point(x, y);
                    }

                }

                if (move == "left")
                {
                    if (marioRec.Location.X < 10) // is mario within 10 of left side
                    {

                        x = 10;
                        marioRec.Location = new Point(x, y);
                    }
                    else
                    {
                        x -= 5;
                        marioRec.Location = new Point(x, y);
                    }

                }
                if (move == "Down")
                {
                    if (marioRec.Location.X < 10) // is mario within 10 of bottom
                    {

                        y = 10;
                        marioRec.Location = new Point(x, y);
                    }
                    else
                    {
                        y += 5;
                        marioRec.Location = new Point(x, y);
                    }

                }
                if (move == "Up")
                {
                    if (marioRec.Location.Y > 10) // is mario within 10 of top
                    {
                        y -= 5;
                        marioRec.Location = new Point(x, y);
                    }
                }

            }
        }
    }

