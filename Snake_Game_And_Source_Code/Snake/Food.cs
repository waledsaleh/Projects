using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Snake
{
   public class Food
    {
           private int x, y, width, heigth;
       private SolidBrush brush;
       public Rectangle foodrec;

       public Food(Random rn)
       {
           x = rn.Next(0, 29) * 10;
           y = rn.Next(0, 29) * 10;
 brush = new SolidBrush(Color.Black);

           width = 10;
           heigth = 10;
          

           foodrec = new Rectangle(x, y, width, heigth);

       }
       public void foodlocation(Random rn) // location
       {
           x = rn.Next(0, 29) * 10;
           y = rn.Next(0, 29) * 10;

       }
       public void drawfood(Graphics paper) // draw food on form
       {

           foodrec.X = x;
           foodrec.Y = y;
           paper.FillRectangle(brush, foodrec);

       }

    }
}
