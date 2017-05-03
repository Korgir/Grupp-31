using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class InventoryTab
    {
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        public InventorySystem inventorySystem;

        public InventoryTab(Vector2 position, TabManager tabManager)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 448, 1080);
            sourceRectangle = new Rectangle(896, 0, 448, 1080);
            inventorySystem = new InventorySystem(position, tabManager);

        }
        public void Update(GameTime gameTime)
        {
            inventorySystem.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Archive.textureDictionary["tabs"], destinationRectangle, sourceRectangle, Color.White);
            inventorySystem.Draw(spriteBatch);
        }
    }
}
