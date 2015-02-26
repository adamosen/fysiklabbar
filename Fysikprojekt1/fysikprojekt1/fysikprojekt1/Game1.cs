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

namespace Fysikprojekt1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont spritefont;
        Texture2D pokeboll;
        Form1 form;
        Line line;
        public List<Line>lines = new List<Line>();

        public List<Ball> balls = new List<Ball>();   

        string xvalstring;
        string yvalstring;
        string anglevalstring;
        string v0xstring;
        string v0ystring;
        string timestring;
        float v0yvalue;

        float pixeltometer;

        float xvalue;
        float yvalue;
        float anglevalue;
        float v0xvalue;
        
        float vvalue;
        float timevalue;

        int timeint;

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
            spritefont = Content.Load<SpriteFont>(@"SpriteFont1");
            pokeboll = Content.Load<Texture2D>(@"pokeboll");
            pixeltometer = 100;
            lines.Add(new Line(400,300,1000,300));
            lines.Add(new Line(0,50,500,300));
           
            //line = new Line(new Vector2(0,200), new Vector2(300,300));
        }

        protected override void UnloadContent()
        {
        }

        public void Spawn()
        {
            balls.Add(new Ball(pokeboll, xvalue, yvalue, vvalue, timeint, v0xvalue, v0yvalue));


        }

        
       
        protected override void Update(GameTime gameTime)
        {
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            float x;
            if (form.GetXValue(out x))
            {
                this.xvalue = x;
            }
            float y;
            if (form.GetYValue(out y))
            {
                this.yvalue = y;
            }
            float a;
            if (form.GetAngleValue(out a))
            {
                this.anglevalue = a;
            }
            //float vx;
            //if (form.GetVelXValue(out vx))
            //{
            //    this.v0xvalue = vx;
            //}
            //float vy;
            //if (form.GetVelYValue(out vy))
            //{
            //    this.v0yvalue = vy;
            //}
            float v;
            if (form.GetVelValue(out v))
            {
                this.vvalue = v;
            }
            float v0Y;
            if (form.GetVelYValue(out v0Y))
            {
                this.v0yvalue = v0Y;
            }
            float v0X;
            if (form.GetVelXValue(out v0X))
            {
                this.v0xvalue = v0X;
            }
            
            xvalstring = xvalue.ToString();
            yvalstring = yvalue.ToString();
            anglevalstring = anglevalue.ToString();
            v0xstring = vvalue.ToString();

            timeint = (int)gameTime.ElapsedGameTime.TotalSeconds;
            
            timevalue = (float)gameTime.ElapsedGameTime.TotalSeconds;



            foreach (Ball b in balls)
            {
                b.Update(gameTime);

                foreach(Line i in lines)
                {
                    if (b.DetectlineCollision(i))
                    {
                        //Console.WriteLine("colisi");
                        //b.velocity.Y *= -1;
                        //b.position.Y = b.prevPos;

                        b.velocity.Y = 0;
                        //b.inAir = false;
                        
                        //b.position.Y --;
                        //b.acceleration = 0;
                    }
                    //else
                    //    b.inAir = true;
                }
            }

            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.DrawString(spritefont,"X-Value: " + xvalstring, Vector2.Zero, Color.Red);
            spriteBatch.DrawString(spritefont, "Y-Value: " + yvalstring, new Vector2(0, 20), Color.Red);
            spriteBatch.DrawString(spritefont, "Angle-Value: " + anglevalstring, new Vector2(0, 40), Color.Red);
            spriteBatch.DrawString(spritefont, "V-Value: " + v0xstring, new Vector2(0, 60), Color.Red);

            foreach (Ball b in balls)
            {
                b.Draw(spriteBatch);
            }

            foreach(Line l in lines)
            {
                l.Draw(spriteBatch);
            }

            //line.Draw(spriteBatch);

            base.Draw(gameTime);
            spriteBatch.End();
        }
    }
}
