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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Vector2 vs1;
        int level=0;
        SpriteFont sf;
        Paddle p1 = new Paddle();
        Paddle p2 = new Paddle();
        Ball ball_c = new Ball();
        SoundEffect se;
        SoundEffect se2;
      public  double speed;
      bool f = false;
        public Game1()
        {

            graphics = new GraphicsDeviceManager(this);
           // graphics.IsFullScreen = false;
            

            Content.RootDirectory = "Content";
             
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            vs1 = new Vector2(0, 0);
            p1.player_one = new Rectangle(10,90,25,100);
            p2.player_two = new Rectangle(760, 200, 25, 100);
            ball_c.ball = new Rectangle(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2,20,20);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            sf = Content.Load<SpriteFont>("Font/font");
            p1.texture = Content.Load<Texture2D>("Photo/1_Player");
            p2.texture = Content.Load<Texture2D>("Photo/2_Player");
            ball_c.texture=Content.Load<Texture2D>("Photo/ball");
            se = Content.Load<SoundEffect>("Sound/feeler release");
            se2 = Content.Load<SoundEffect>("Sound/next level");
            //ball_c.loadcontent();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit

            KeyboardState key = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed||key.IsKeyDown(Keys.Escape))
                
                this.Exit();

            // TODO: Add your update logic here

            p1.update(gameTime);
          //  p2.update1(gameTime);

            p2.player_two.Location = new Point(graphics.PreferredBackBufferWidth - (p2.player_two.Width + p2.player_two.Width / 2), ball_c.ball.Location.Y - p2.player_two.Height / 2);


            ball_c.update(gameTime);

          if(ball_c.ball.Intersects(p1.player_one))
          {
              ball_c.move_right=true;
              ball_c.ball_speed += 0.4f;
             // se.Play();
          }
          if (ball_c.ball.Intersects(p2.player_two))
          {
              ball_c.move_right = false;
              ball_c.ball_speed += 0.4f;
            //  se.Play();
          }
          if (p1.player_one.Y < 0) p1.player_one.Y = 0;
          if (p2.player_two.Y < 0) p2.player_two.Y = 0;
          if (p1.player_one.Y > graphics.PreferredBackBufferHeight - p1.player_one.Height) p1.player_one.Y = graphics.PreferredBackBufferHeight - p1.player_one.Height;
          if (p2.player_two.Y > graphics.PreferredBackBufferHeight - p2.player_two.Height) p2.player_two.Y = graphics.PreferredBackBufferHeight - p2.player_two.Height;

          if (f)
          {
              SuppressDraw();
              //spriteBatch.DrawString(sf, "Winner ", new Vector2(100, 200), Color.Red);
          }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gold);

            spriteBatch.Begin();

            speed = Math.Round(ball_c.ball_speed, 2);
            switch ((int)speed)
            {
                case 10: level = 1; break;
                case 12: level =2; break;
                case 18: level = 3; break;
                case 32: level = 4; break;
                case 42: level = 5;break;
            }
            

            p1.Draw(spriteBatch);
            p2.Draw1(spriteBatch);
            ball_c.Draw(spriteBatch);
          //  if (ball_c.score1.Equals("2"))
            //{
              //  f = true;
                //spriteBatch.DrawString(sf, "Congratulation,You are win ", new Vector2(graphics.PreferredBackBufferWidth / 2-70, 60), Color.Red);
               

            //}
            if (ball_c.score2.Equals("15"))
            {
                f = true;
                //spriteBatch.DrawString(sf, "Computer is win ,Try again later", new Vector2(graphics.PreferredBackBufferWidth / 2 - 70, 60), Color.Red);
                spriteBatch.DrawString(sf, "Your Ball_Speed was " + speed, new Vector2(graphics.PreferredBackBufferWidth / 2 - 70, 100), Color.Red);
               // this.EndDraw();
               // this.EndRun();
            }
           // spriteBatch.DrawString(sf, ball_c.score1, vs1, Color.White);
          //  spriteBatch.DrawString(sf, "Player1_Score " + ball_c.score1, new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(sf, "AI_Score " + ball_c.score2, new Vector2(620, 0), Color.Black);

          //  spriteBatch.DrawString(sf, "Created by Waled_Saleh" , new Vector2(0, 450), Color.Red);
            spriteBatch.DrawString(sf, "Ball_Speed "+ speed, new Vector2(graphics.PreferredBackBufferWidth/2, 0), Color.Red);
            spriteBatch.DrawString(sf, "Level " + level, new Vector2(250, 0), Color.Red);


            spriteBatch.End();
           

            base.Draw(gameTime);
        }
    }
}
