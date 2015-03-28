using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
   public class Snake
    {
       private int x, y, width, height;
       private SolidBrush brush; // color of snake
       private Rectangle[] snakerec;

       public Rectangle[] SnakeRec
       {
           get{return snakerec;}

       }

       public Snake() // constructor to initialize fields
       {
           snakerec = new Rectangle[3];
           brush = new SolidBrush(Color.Black);

           x = 20;
           y = 0;
           width = 10;
           height = 10;
           for (int i = 0; i < snakerec.Length; i++)
           {
               snakerec[i] = new Rectangle(x, y, width, height);// initialize position of snake
               x -= 10;

           }

       }

       public void drawsnake(Graphics paper) // draw snake on form
       {
           foreach(Rectangle z in snakerec)
           {
               paper.FillRectangle(brush, z);
           }
       }

       public void drawsnake()
       {
           for (int i = snakerec.Length - 1; i > 0; i--) // print rec
           {
               snakerec[i] = snakerec[i - 1];

           }

       }
       public void movedown()
       {
           drawsnake();
           snakerec[0].Y += 10; // if user move down increase y-axis

       }
       public void moveup()
       {
           drawsnake();
           snakerec[0].Y -= 10;// if user move up decrease y-axis

       }
       public void moveright()
       {
           drawsnake();
           snakerec[0].X += 10;// if user move right increase x-axis

       }
       public void moveleft()
       {
           drawsnake();
           snakerec[0].X -= 10;// if user move left decrease x-axis

       }
       public void largesnake()
       {
           List<Rectangle> rec = snakerec.ToList();
          rec.Add(new Rectangle(snakerec[snakerec.Length-1].X,snakerec[snakerec.Length-1].Y,width,height)); // increaseing tail of snake 
           snakerec=rec.ToArray();

       }



    }
}
