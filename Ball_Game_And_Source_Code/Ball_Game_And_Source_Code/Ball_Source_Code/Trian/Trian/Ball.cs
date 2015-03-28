using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Trian
{
    class Ball:Microsoft.Xna.Framework.Game
    {
        public Texture2D texture;
        public int speed;
       // public Vector2 position;
        public Rectangle ball;

      //  SpriteFont sf;
        public int player1_score=0, player2_score=0;

       public string score1,score2;
       SpriteFont sf;
       

        public float ball_speed;
        public int width;
        public int heigh;
        public bool move_up, move_right;
        GraphicsDeviceManager graphics;
        public Ball()
        {
            graphics = new GraphicsDeviceManager(this);
          
           
            ball_speed = 4.0f;
            texture = null;
            speed = 6;
            width = 20;
            heigh = 30;
            score1 = "";  
            move_right = false;
            move_up = true;
            score2 = "";
             
            ball = Rectangle.Empty;
        }
     
        public void Draw(SpriteBatch spritebatch)
        {
           // spritebatch.DrawString(sf, score1, vs, Color.White);

            spritebatch.Draw(texture, ball, Color.Gold);
          //  spritebatch.DrawString(sf, "Player1_Score " + score1, new Vector2(0, 0), Color.White); 
        }
        public void update(GameTime gametime)
        {
            if (move_right)
            {
                ball.X += (int)ball_speed;
               // ball_speed += 0.1f;
            }
            else
            {
                ball.X -= (int)ball_speed;
               
            }

            if (move_up)
            {
                ball.Y -= (int)ball_speed;
               
            }
            else
            {
                ball.Y += (int)ball_speed;
               
            }

            if (ball.Y < 0) move_up = false;
            if (ball.Y > graphics.PreferredBackBufferHeight - ball.Height) move_up = true;
            if (ball.X > graphics.PreferredBackBufferWidth-ball.Width)
            {
                player1_score++;
                score1 =  player1_score.ToString();
                move_right = false;
               // ball_speed += 0.4f;
            }
            if (ball.X < 0)
            {
                player2_score++;
                score2 = player2_score.ToString();
                move_right = true;
              //  ball_speed += 0.4f;
            }
           

        }
       
    }
}
