using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
namespace game
{
   public class rectangle
    {

      public int x, y, width, hight;
       private Image rec_image;
       public Rectangle rec;

       public Rectangle Rec
       {
           get { return rec; }
       }
       public rectangle()
       {
            x = 0; y = 400; width = 65; hight = 10;
            rec_image = game.Properties.Resources.rec;
            rec = new Rectangle(x,y,width,hight);
       }
       public void drawrec(Graphics r)
       {
           r.DrawImage(rec_image,rec);
       }

       public void mouse(int mx)
       {
           rec.X = mx-(rec.Width/2);
       }
    }
}
