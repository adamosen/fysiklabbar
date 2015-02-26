using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using C3.XNA;

namespace Fysikprojekt1
{
     public class Line
    {
        public Vector2 start, end;
       
        
        public Line(float x1,float y1,float x2,float y2)
        {
            this.start = new Vector2(x1,y1);
            this.end = new Vector2(x2,y2);
        }

        public Vector2 GetNormal()
        {
            var len = (end - start).Length();
            float dx = (end.X - start.X) / len;
            float dy = (end.Y - start.Y) / len;

            //(-dy, dx) and (dy, -dx)
            if (dx < 0)
            {
                return new Vector2(dy, -dx);
            }
            else
            {
                return new Vector2(-dy, dx);
            }
        }

        public void Draw(SpriteBatch batch)
        {
            batch.DrawLine(start,end,Color.Red,5f);
            
        }

    }
}
