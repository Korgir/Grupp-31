using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Projectile
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 destination;
        public float speed;
        public bool haveReachedDestination;


        public Projectile(Texture2D texture, Vector2 position, Vector2 destination, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.destination = destination;
            this.speed = speed;

            haveReachedDestination = false;
        }

        public void Update(GameTime gameTime)
        {
            Vector2 direction = destination - position;
            direction.Normalize();

            this.position += direction * speed;

            if (Vector2.Distance(position, destination) < speed)
            {
                haveReachedDestination = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0f, 
                new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);
        }
    }
}
