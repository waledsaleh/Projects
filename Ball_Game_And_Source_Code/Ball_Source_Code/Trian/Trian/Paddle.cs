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
    class Paddle
    {
        public Texture2D texture;
        public int speed;
        public Vector2 position;
        public int width;
        public int heigh;
        public PlayerIndex player;
        public KeyboardState input,sec;

      public  Rectangle player_one,player_two;

        public Paddle()
        {
            texture = null;
            speed = 2;
            position = Vector2.Zero;
            width = 35;
            heigh = 200;
            player = PlayerIndex.One;
            player_one = Rectangle.Empty;
            player_two = Rectangle.Empty;
        }
        public void update(GameTime gametime)
        {
            input = Keyboard.GetState();
            if (input.IsKeyDown(Keys.Up))
            {
                if (speed == 66)
                {
                    speed = 3;
                    player_one.Y -= speed * (int)gametime.ElapsedGameTime.TotalMilliseconds;
                }
                else 
                   // speed = 3;
                    player_one.Y -= speed * (int)gametime.ElapsedGameTime.TotalMilliseconds;
                
            }
            if (input.IsKeyDown(Keys.Down))
            {
                 if (speed == 66)
                {
                    speed = 3;
                    player_one.Y += speed * (int)gametime.ElapsedGameTime.TotalMilliseconds;
                }
                else 
                   // speed = 3;
                    player_one.Y += speed * (int)gametime.ElapsedGameTime.TotalMilliseconds;
                
               // player_one.Y += speed * (int)gametime.ElapsedGameTime.TotalMilliseconds;
            }


        }
        public void update1(GameTime gametime1)
        {
            sec = Keyboard.GetState();
            if (sec.IsKeyDown(Keys.W))
                player_two.Y -= speed * (int)gametime1.ElapsedGameTime.TotalMilliseconds;
            if (sec.IsKeyDown(Keys.S))
                player_two.Y += speed * (int)gametime1.ElapsedGameTime.TotalMilliseconds;


        }
        public void Draw(SpriteBatch spritebatch)
        {

            spritebatch.Draw(texture, player_one, Color.Black);
        }

        public void Draw1(SpriteBatch spritebatch)
        {

            spritebatch.Draw(texture, player_two, Color.Red);
        }
    }
}
