using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class ItemEntity : Entity
    {
        public Item containedItem;

        public ItemEntity(Texture2D texture, Vector2 position, Item containedItem) : base (texture, position)
        {
            this.containedItem = containedItem;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
