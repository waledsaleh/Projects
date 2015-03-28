using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Random randFood = new Random();

        Graphics paper;
        Snake snakes = new Snake();
        Food food;
        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;
        int score = 0;
        bool start = false;
        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
          
            paper = e.Graphics;
            food.drawfood(paper);
            snakes.drawsnake(paper);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // movements of snake by user
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                label1.Hide();
                start = true;
                down = false;
                up = false;
                left = false;
                right = true;
            }
            if (start)
            {
                if (e.KeyData == Keys.Down && up == false)
                {
                    down = true;
                    up = false;
                    right = false;
                    left = false;
                }
                if (e.KeyData == Keys.Up && down == false)
                {
                    down = false;
                    up = true;
                    right = false;
                    left = false;
                }
                if (e.KeyData == Keys.Left && right == false)
                {
                    down = false;
                    up = false;
                    right = false;
                    left = true;
                }
                if (e.KeyData == Keys.Right && left == false)
                {
                    down = false;
                    up = false;
                    right = true;
                    left = false;
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
          if (down) { snakes.movedown(); }
            if (up) { snakes.moveup(); }
            if (right) { snakes.moveright(); }
            if (left) { snakes.moveleft(); }
            this.Invalidate();
            collision();
            for (int i = 0; i < snakes.SnakeRec.Length; i++)
            {
                if (snakes.SnakeRec[i].IntersectsWith(food.foodrec))
                {
                    score += 1;
                    snakes.largesnake();
                    food.foodlocation(randFood);
                }
            }
        }

        public void collision() // if snake hit 1 from 4 walls 
        {
            for (int i = 1; i < snakes.SnakeRec.Length; i++)
            {
                if (snakes.SnakeRec[0].IntersectsWith(snakes.SnakeRec[1]))
                {
                    restart();
                }
            }
            if (snakes.SnakeRec[0].X < 0 || snakes.SnakeRec[0].X > 290)
            {
                restart();

            }
            if (snakes.SnakeRec[0].Y < 0 || snakes.SnakeRec[0].Y > 290)
            {
                restart();
            }



        }

        public void restart() //restart game if user failed
        {
            timer1.Enabled = false;
            MessageBox.Show("GAME OVER");
            MessageBox.Show("Press Space key to play again");
            score = 0;
           
            snakes = new Snake();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
