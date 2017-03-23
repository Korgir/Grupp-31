using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Tiles
{
    public class GameObject
    {
        protected Vector2 position;
        protected Texture2D texture;
        
        public GameObject(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
