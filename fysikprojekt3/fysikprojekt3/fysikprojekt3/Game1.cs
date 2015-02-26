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

namespace fysikprojekt3
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Form1 form;
        Texture2D cartex;
        //Bil bil;
        List<Bil> bilar = new List<Bil>();
        float speed,delta;
        float velocity1,velocity2,friction,friction2;
        int pixelMeter;
        int pixelMeterRatio;
        float friktionvalue;

        // ( ͡° ͜ʖ ͡°)

        public Game1()

        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            form = new Form1(this);
            form.Show();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 1200;
            graphics.ApplyChanges();
            spriteBatch = new SpriteBatch(GraphicsDevice);
            cartex = Content.Load<Texture2D>("cartex");
            SpriteFont font = Content.Load<SpriteFont>("font1");
            //bil = new Bil(cartex, 300, 400);
            pixelMeter = 1;
            this.pixelMeterRatio = 10;
            bilar.Add(new Bil(cartex, 30 , 30 , 10 , this, font, new Vector2(30 , 30 )));
            bilar.Add(new Bil(cartex, 90, 30 , 20 , this, font, new Vector2(90 , 30 )));

          


        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //if (Keyboard.GetState().IsKeyDown(Keys.F))
            //{
            //    form = new Form1(this);
            //    form.Show();
            //}

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;





            //bil.Update(gameTime, delta);


            foreach (Bil b in bilar)
            {
                if (form.GetFriction(out friction))
                {
                    this.friktionvalue = friction;


                }


                if (form.GetSpeedValue1(out velocity1))
                {
                    bilar[0].v = velocity1;

                }

                if (form.GetSpeedValue2(out velocity2))
                {
                    bilar[1].v = velocity2;

                }

                bilar[0].Update(gameTime, delta, velocity1, friktionvalue);
                bilar[1].Update(gameTime, delta, velocity2, friktionvalue);
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //bil.Draw(spriteBatch);

           

            spriteBatch.End();


            spriteBatch.Begin(SpriteSortMode.Deferred,
               BlendState.AlphaBlend,
               SamplerState.LinearClamp,
               DepthStencilState.None,
               RasterizerState.CullCounterClockwise,
               null,
               Matrix.CreateScale(pixelMeterRatio, pixelMeterRatio, 0.01f));
            foreach (Bil b in bilar)
            {
                b.Draw(spriteBatch);
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
