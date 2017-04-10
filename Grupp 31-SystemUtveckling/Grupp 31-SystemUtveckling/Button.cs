using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Button
    {
        protected Rectangle hitBox;
        protected Texture2D texture;
        protected SpriteFont font;
        protected string text;

        public Button(Rectangle hitBox, Texture2D texture, SpriteFont font, string text)
        {
            this.hitBox = hitBox;
            this.texture = texture;
            this.font = font;
            this.text = text;
        }

        public bool IsClicked()
        {
            if (hitBox.Contains(KeyMouseReader.mousePosition))
            {
                if (KeyMouseReader.LeftClick())
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, hitBox, Color.White);
            Vector2 fontPosition = new Vector2(hitBox.X + (hitBox.Width / 2) - (font.MeasureString(text).X / 2), 
                hitBox.Y + (hitBox.Height / 2) - (font.MeasureString(text).Y / 2));
            spriteBatch.DrawString(font, text, fontPosition, Color.Black);
        }
    }
}
