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

namespace Fysikprojekt2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        Form1 form;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font1;
        Texture2D texture;
        float fsvalue;
        float fkvalue;

        double massvalue;

        double angle;
        Vector2 spawn;

        public List<Box> boxes = new List<Box>();   

        String fvaluestring;
        String avaluestring;

        int pixelMeterRatio = 10;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
            form = new Form1(this);
            form.Show();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font1 = Content.Load<SpriteFont>(@"SpriteFont1");
            texture = Content.Load<Texture2D>(@"boxtext");
            spawn = new Vector2(2, 2);

        }

        protected override void UnloadContent()
        {
          
        }

        protected override void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            float x;
            if (form.GetXValue(out x))
            {
                this.fsvalue = x;
            }
            float y;
            if (form.GetAValue(out y))
            {
                this.angle = y;
            }
            float z;
            if (form.GetFValue(out z))
            {
                this.fkvalue = z;
            }
            float m;
            if (form.GetMValue(out m))
            {
                this.massvalue = m;
            }

            foreach (Box b in boxes)
            {
                b.Update(delta, fkvalue);
            }

            fvaluestring = fsvalue.ToString();
            avaluestring = angle.ToString();

            base.Update(gameTime);
        }
        public void Spawn()
        {
            boxes.Add(new Box(texture, spawn, fsvalue, angle, massvalue));
        }
        public void DeSpawn()
        {
            boxes.Clear();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.DrawString(font1, "Friction value: " + fvaluestring, Vector2.Zero, Color.Red);
            spriteBatch.DrawString(font1, "Angle value: " + avaluestring, new Vector2(0, 20), Color.Red);
            spriteBatch.DrawString(font1, "Acceleration: " + Box.acceleration, new Vector2(0, 40), Color.Red);
            spriteBatch.End();


            spriteBatch.Begin(SpriteSortMode.Deferred,
               BlendState.AlphaBlend,
               SamplerState.LinearWrap,
               DepthStencilState.None,
               RasterizerState.CullCounterClockwise,
               null,
               Matrix.CreateScale(pixelMeterRatio, pixelMeterRatio, 1f));
            
            foreach (Box b in boxes)
            {
                b.Draw(spriteBatch);
            }
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
