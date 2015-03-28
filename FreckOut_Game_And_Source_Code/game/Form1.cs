using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace game
{

    /****************************
     * 
     * ALL GAME elements should be called here not in blocks!
     * 
     * 
     * * * */
    public partial class Form1 : Form
    {

        public block[,] blocks = new block[10, 10];
        PictureBox pb;

        rectangle g = new rectangle();

        public int score = 0; // score is here

        Graphics r;
        Ball b = new Ball();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            g.mouse(e.X);
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            r = e.Graphics;

            g.drawrec(r);
            b.drawrec(r);
            drawblock(r);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            this.Invalidate();

            b.moveball();
            ball_collision();
            b.hitball(g.rec);
            hitrec();

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            initBlocks();

            //pb = new PictureBox();
            //pb.Parent = this;
            //pb.Dock = DockStyle.Fill;
            //pb.BackColor = Color.SkyBlue;
        }


        public void ball_collision()
        {
            if (b.ball.X < 0 || b.ball.X > this.Width - 50)
            {
                b.xspeed *= -1;
            }

            if (b.ball.Y < 0)
            {
                b.yspeed *= -1;
            }
        }

        public void hitrec()
        {

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (b.ball.IntersectsWith(blocks[i, j].brick))
                    {
                        b.yspeed = -b.yspeed;

                        score++;
                        textBox1.Text = ""+score;

                        blocks[i, j].isIntersected = true;
                        blocks[i, j].brick = new Rectangle(0, 0, 0, 0);
                        if (score == 100)
                        {
                            MessageBox.Show("Game Over"); // end of the game
                            textBox1.Text = "";
                            Application.Exit(); //kill Application
                        }
                    }

                }


            }

        }

        public void drawblock(Graphics r)
        {


            SolidBrush brush = new SolidBrush(Color.Red);
            SolidBrush brush2 = new SolidBrush(Color.Yellow);


            Rectangle nothing = new Rectangle(0, 0, 0, 0);
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    if (blocks[i, j].isIntersected != true)
                    {
                        blocks[i, j].isIntersected = false;

                        if (i < 2) brush = new SolidBrush(Color.Red);
                        else if (i >= 2 & i < 4) brush2 = new SolidBrush(Color.Orange);
                        else if (i >= 4 & i < 6) brush = new SolidBrush(Color.Yellow);
                        else if (i >= 6 & i < 8) brush2 = new SolidBrush(Color.Green);
                        else brush = new SolidBrush(Color.Cyan);
                        r.FillRectangle(brush, blocks[i, j].brick);

                        Pen p = new Pen(Color.Blue, 1.0f);
                        r.DrawRectangle(p, blocks[i, j].brick);

                    }

                }


            }
        }
        public void initBlocks()
        {
            int BlockX = 20;
            int BlockY = 70;
            int BlockW = 70;
            int BlockH = 20;

            int BRICK_SEP = 2;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    blocks[i, j] = new block();
                    blocks[i, j].isIntersected = false;

                    blocks[i, j].brick = new Rectangle(BlockX, BlockY, BlockW, BlockH);

                    BlockX += BlockW + BlockH;

                }


                BlockX = 20;
                BlockY += BlockH + BRICK_SEP;

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e) // button for clear the previous score
        {
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Leave(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }



        

    }
}

