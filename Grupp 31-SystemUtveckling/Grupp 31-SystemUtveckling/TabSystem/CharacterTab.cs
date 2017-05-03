using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class CharacterTab
    {
        Rectangle destinationRectangle;
        Rectangle sourceRectangle;
        public CharacterSystem characterSystem;

        public CharacterTab(Vector2 position, TabManager tabManager)
        {
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, 448, 1080);
            sourceRectangle = new Rectangle(448, 0, 448, 1080);
            characterSystem = new CharacterSystem(position, tabManager);
        }
        public void Update(GameTime gameTime)
        {
            characterSystem.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Archive.textureDictionary["tabs"], destinationRectangle, sourceRectangle, Color.White);
            characterSystem.Draw(spriteBatch);
        }
    }
}
