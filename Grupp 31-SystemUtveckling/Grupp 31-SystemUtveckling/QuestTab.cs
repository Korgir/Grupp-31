using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class QuestTab
    {
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;

        public QuestTab(Vector2 position)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 448, 1080);
            sourceRectangle = new Rectangle(0, 0, 448, 1080);

        }
        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Archive.textureDictionary["tabs"], destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
