using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    class QuestTab
    {
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        public QuestTab()
        {
            destinationRectangle = new Rectangle(0, 0, 448, 1080);
            sourceRectangle = new Rectangle(0, 0, 448, 1080);

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AssetsManager.tabTex, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
