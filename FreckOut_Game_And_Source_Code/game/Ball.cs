using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
namespace game
{
    public class Ball
    {
        rectangle rect = new rectangle();
        public int x, y, width, hight;
        private Image ball_image;
        public Rectangle ball;
        public int xspeed, yspeed;
        private Random ranspeed = new Random();
        public Rectangle Balll
        {
            get { return ball; }
        }
        public Ball()
        {
            x = 0; y =300; width = 8; hight = 8;
            ball_image = game.Properties.Resources.Ball;
            ball = new Rectangle(x, y, width, hight);
            xspeed = 9;// ranspeed.Next(3, 10);
            yspeed = 9;//ranspeed.Next(3, 5);

        }
        public void drawrec(Graphics r)
        {
            r.DrawImage(ball_image, ball);

        }
        public void moveball()
        {
            ball.X += xspeed;
            ball.Y += yspeed;
        }


   

        
        public void hitball(Rectangle hrect)
        {
            if (ball.IntersectsWith(hrect))
            {
                yspeed *= -1;
                xspeed+=5;
                Console.Beep();
            }
            

        }
    }
}