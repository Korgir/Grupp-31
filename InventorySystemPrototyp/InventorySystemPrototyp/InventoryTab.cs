using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    class InventoryTab
    {
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        InventorySystem inventorySystem;

        public InventoryTab()
        {
            destinationRectangle = new Rectangle(0, 0, 448, 1080);
            sourceRectangle = new Rectangle(896, 0, 448, 1080);
            inventorySystem = new InventorySystem();

        }
        public void Update(GameTime gameTime)
        {
            inventorySystem.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetsManager.tabTex, destinationRectangle, sourceRectangle, Color.White);
            inventorySystem.Draw(spriteBatch);
        }
    }
}
