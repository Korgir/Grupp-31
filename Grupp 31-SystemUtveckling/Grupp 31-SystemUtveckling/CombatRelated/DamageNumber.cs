using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public class DamageNumber
    {
        protected SpriteFont font;
        protected Texture2D texture;
        protected Vector2 position;
        protected Vector2 velocity;
        protected string text;
        protected Color color;
        protected float timeToLiveSeconds;
        public float transparancy;

        public DamageNumber(Texture2D texture, Vector2 position, string text, Color color, float timeToLiveSeconds)
        {
            font = Archive.fontDictionary["infoFont"];
            this.texture = texture;
            this.position = position;
            velocity = new Vector2((float)Archive.randomizer.Next(-20, 20), (float)Archive.randomizer.Next(-150, -100));
            this.text = text;
            this.color = color;
            this.timeToLiveSeconds = timeToLiveSeconds;
            transparancy = 1f;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            timeToLiveSeconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timeToLiveSeconds < 0.5f)
            {
                transparancy = timeToLiveSeconds * 2;
                if (timeToLiveSeconds < 0)
                {
                    transparancy = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            float xOffset = -(font.MeasureString(text).X / 2) - 32;
            Vector2 iconPosition = new Vector2(position.X + xOffset, position.Y);

            spriteBatch.Draw(texture, iconPosition, null, new Color(color, transparancy), 0f, 
                new Vector2(texture.Width/2, texture.Height/2), 1.0f, SpriteEffects.None, 0);
            spriteBatch.DrawString(font, text, position, new Color(color, transparancy), 0f, 
                new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2), 1.0f, SpriteEffects.None, 0);
        }
    }
}
