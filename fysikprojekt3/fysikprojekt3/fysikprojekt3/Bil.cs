using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fysikprojekt3
{

    public class Bil
    {
        Texture2D tex;
        Vector2 pos;
        float radius, anglespeed,mass,period,angle,CenpetForce,turn,Fn,speed,gravity,ypos,xpos;
        public float fks;
        public float v;
        Game1 game;
        SpriteFont font1;
        Vector2 textpos;
        bool drawtext;
        int pixelMeter = 100;
        float frictionvalue;

        public Bil(Texture2D tex, float xpos, float ypos,float radius,Game1 game,SpriteFont font1,Vector2 textpos)
        {
            this.textpos = textpos;
            this.font1 = font1;
            this.game = game;
            this.ypos = ypos;
            this.xpos = xpos;
            this.tex = tex;
            this.radius = radius;
            //this.v = velocity;

            
            this.period = (2*(float)Math.PI*radius)/anglespeed;
            this.mass = 3;
            this.gravity = 9.8f ;
            //this.fks = 0.8f;
          

            
            //anglespeed = (float)((2 * Math.PI )/ period);



            this.Fn = mass * gravity;

            this.CenpetForce = mass * radius * anglespeed * anglespeed;
            //this.v = (float)Math.Sqrt(fks*gravity*radius);


        }
       public void Update(GameTime gametime, float delta, float velocity, float friction)
        {
            this.frictionvalue = friction;
            v = velocity;
            anglespeed = velocity / radius;
                angle += anglespeed * delta;
            
                pos = new Vector2(xpos, ypos) - new Vector2(radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle));

            //if (fks * gravity < (velocity * velocity) / radius)
            //{

            //    drawtext = true;

            //}

                if ((v*v)/(gravity*radius) > frictionvalue)
                {

                    drawtext = true;

                }
            else
                drawtext = false;

        }

       public void Draw(SpriteBatch spriteBatch)
       {
           if (drawtext == false)
           { 
            spriteBatch.Draw(tex, pos, new Rectangle(0, 0, tex.Width, tex.Height), Color.White, angle, new Vector2(tex.Width / 2, tex.Height / 2), 0.1f, 0, 0);
           }
              

               if (drawtext == true)
               {
                    spriteBatch.DrawString(font1,"FoR SNABB!",textpos,Color.Red);
               }

              
           //spriteBatch.DrawString(font, "Enemies Killed: " + enemiesKilled.ToString(), new Vector2(120, 720), Color.Blue);
       }
       //public static void DrawLine(this SpriteBatch spriteBatch, float x1, float y1, float x2, float y2, Color color, float thickness = 1f)
       //{
       //    x1 = 0;
       //    y1 = 0;
       //    x2 = 100;
       //    y2 = 100;
       //}

    }
}
