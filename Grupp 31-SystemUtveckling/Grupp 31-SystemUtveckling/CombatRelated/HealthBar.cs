using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    static class HealthBar
    {
        public static void Draw(SpriteBatch spriteBatch, Character character, Color color)
        {
            Texture2D frame = Archive.textureDictionary["resourceBarFrame"];
            Texture2D filling = Archive.textureDictionary["resourceBarFilling"];

            float percentageHealth = (float)character.health / (float)character.maxHealth;
            int offset = 10;
            Vector2 position = character.Position - new Vector2(0, character.texture.Height / 2 + frame.Height / 2 + offset);

            Rectangle visibleHealth = new Rectangle(0, 0, (int)(filling.Width * percentageHealth), filling.Height);
            spriteBatch.Draw(frame, position, null, Color.White, 0.0f, new Vector2(frame.Width / 2, frame.Height / 2), 1.0f, SpriteEffects.None, 0);
            spriteBatch.Draw(filling, position, visibleHealth, color, 0.0f, new Vector2(filling.Width / 2, filling.Height / 2), 1.0f, SpriteEffects.None, 0);

            string healthText = character.health + " / " + character.maxHealth;
        }
    }
}
