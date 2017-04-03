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
        public Texture2D texture;
        public Vector2 position;
        protected float rotation;
        protected Vector2 destination;
        protected Vector2 direction;
        protected float speed = 250.0f;
        protected bool moving = false;

        protected Rectangle spriteRectangle;
        protected Rectangle objectRectangle;

        public List<Character> team;

        public Entity(Texture2D texture, Vector2 position, Rectangle spriteRectangle, Rectangle objectRectangle)
        {
            this.texture = texture;
            this.position = position;
            this.spriteRectangle = spriteRectangle;
            this.objectRectangle = objectRectangle;

            this.team = new List<Character>();
        }

        public void Move(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            objectRectangle.X = (int)position.X;
            objectRectangle.Y = (int)position.Y;
            if (Vector2.Distance(position, destination) < 1)
            {
                position = destination;
                objectRectangle.X = (int)position.X;
                objectRectangle.Y = (int)position.Y;
                moving = false;
            }
        }

        public void ChangePos(Vector2 newPos)
        {
            position = newPos;
            moving = false;
            objectRectangle.X = (int)position.X;
            objectRectangle.Y = (int)position.Y;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
