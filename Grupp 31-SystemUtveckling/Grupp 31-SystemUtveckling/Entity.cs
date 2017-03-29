using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Entity
    {
        public Texture2D tex;
        public Vector2 pos;
        protected float rotation;
        protected Vector2 destination;
        protected Vector2 direction;
        protected float speed = 250.0f;
        protected bool moving = false;

        protected Rectangle sprRec;
        protected Rectangle objRec;


        public Entity(Texture2D tex, Vector2 pos, Rectangle sprRec, Rectangle objRec)
        {
            this.tex = tex;
            this.pos = pos;
            this.sprRec = sprRec;
            this.objRec = objRec;

            destination = pos;
            direction = Vector2.Zero;
        }

        public void move(GameTime gameTime)
        {
            pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            objRec.X = (int)pos.X;
            objRec.Y = (int)pos.Y;
            if (Vector2.Distance(pos, destination) < 1)
            {
                pos = destination;
                objRec.X = (int)pos.X;
                objRec.Y = (int)pos.Y;
                moving = false;

            }
        }

        public void changePos(Vector2 newPos)
        {
            pos = newPos;
            moving = false;
            objRec.X = (int)pos.X;
            objRec.Y = (int)pos.Y;
        }

        public Vector2 getPos()
        {
            return pos;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, Color.White);
        }
    }
}
