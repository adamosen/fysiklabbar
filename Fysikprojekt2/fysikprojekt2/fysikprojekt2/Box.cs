using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Fysikprojekt2
{
    public class Box
    {
        Texture2D texture;

        Vector2 position;
        Vector2 direction;
        Vector2 velocity;

        public static double acceleration;

        double gravityforce;
        double normalforce;
        double frictionstaticforce;
        double frictionforce;
        double frictionmaxforce;
        double ffk;
        double mass;
        double frictionkinetic;
        double angle;

        Rectangle boxrec;

        public Box(Texture2D tempTex, Vector2 tempPos, float tempF, double angle,  double tempMass) 
        {
            this.position = tempPos;
            this.texture = tempTex;
            this.frictionstaticforce = tempF;

            this.angle = angle; ;
            this.mass = tempMass * 9.8;
            this.boxrec = new Rectangle(0, 0, 1, 1);
            this.gravityforce = 9.8;
            this.direction = new Vector2((float)Math.Cos(MathHelper.ToRadians((float)angle)), (float)Math.Sin(MathHelper.ToRadians((float)angle)));
        }

        public void Update(float delta, float tempfk)
        {
            this.frictionkinetic = tempfk;
            this.normalforce = Math.Cos(angle*Math.PI/180) * mass;

            this.frictionmaxforce = frictionstaticforce * normalforce;

            //kolla upp
            this.frictionforce = this.mass * Math.Sin(angle * Math.PI / 180);

            if (frictionforce > frictionmaxforce)
            {
                this.ffk = frictionkinetic * normalforce;

                Box.acceleration = (mass * Math.Sin(angle * Math.PI / 180) - ffk) / (mass / gravityforce);

                velocity.X += (float)acceleration * (float)delta;
                velocity.Y += (float)acceleration * (float)delta;

                this.position.X += velocity.X * (float)delta * direction.X;
                this.position.Y += velocity.Y * (float)delta * direction.Y;
            }
            if (velocity.X <= 0 && velocity.Y <= 0)
            {
                acceleration = 0;
                velocity.X = 0;
                velocity.Y = 0;
            }
            

            

            
        }

        public void Draw(SpriteBatch batch)
        {
           // batch.Draw(texture, boxrec, Color.White);
            batch.Draw(texture, position, null, Color.White, 0, Vector2.Zero, 0.2f , SpriteEffects.None, 0);
            
           


        }
    }
}
