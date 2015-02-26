using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fysikprojekt1
{
    public class Ball
    {
        Texture2D balltexture;

        float xvalue;
        float yvalue;
        float anglevalue;
        float v0xvalue;
        float v0yvalue;
        public bool inAir = true;
       

        float radius;

        public Vector2 position;

    
        float v0;
        float v0x;
        float v0y;
        //float angle;

        float pixeltometer;

        public Vector2 velocity;
       

        public float acceleration;
        public float time;

        int timeint;
        float center;
        public float prevPos;
        
        public float distanceFall;
        

        public Ball(Texture2D tempTex, float x0, float y0, float v0, int temptime, float v0x, float v0y)
        {
            this.radius = tempTex.Width / 2;
            this.xvalue = x0;
            this.yvalue = y0;
            this.v0x = v0x;
            this.v0y = v0y;
            //this.anglevalue = angle;
            this.v0 = v0;
            //this.angle = angle;
            this.acceleration = (float)98;
            this.balltexture = tempTex;
            this.timeint = temptime;
            this.time = 0;
            this.pixeltometer = 100;
            this.distanceFall = velocity.Y * time;
            
        

        }

        public bool DetectlineCollision(Line line)
        {
            float dst = DistanceFromPointToLineSegment(position,line.start, line.end);
            if (dst <= radius)
            {
                return true;   
            }
            return false;
        }

        private static float DistanceFromPointToLineSegment(Vector2 point, Vector2 anchor, Vector2 end)
        {
            Vector2 d = end - anchor;
            float length = d.Length();
            if (d == Vector2.Zero) return (point - anchor).Length();
            d.Normalize();
            float intersect = Vector2.Dot((point - anchor), d);
            if (intersect < 0) return (point - anchor).Length();
            if (intersect > length) return (point - end).Length();
            return (point - (anchor + d * intersect)).Length();
        }



        public void Update(GameTime gameTime)
        {
            velocity = new Vector2(0, v0y - acceleration * time);
            
            this.time += (float)gameTime.ElapsedGameTime.TotalSeconds;

            //v0x = v0 * (float)Math.Cos((angle * Math.PI) / 180) * pixeltometer;
            //v0y = v0 * (float)Math.Sin((angle * Math.PI) / 180) * pixeltometer;

            if (inAir == true)
            {

                position.X = v0x * time + xvalue * pixeltometer;
                position.Y = v0y * time + yvalue * pixeltometer + (acceleration * time * time) / 2;

                //position.X = xvalue * pixeltometer;
                //position.Y = yvalue * pixeltometer + (acceleration * time * time) / 2;


            }
            //velocity.X = v0x
            //prevPos = position.Y;
        }

        

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(balltexture, position, Color.White);
        
        }


        

    }
}
