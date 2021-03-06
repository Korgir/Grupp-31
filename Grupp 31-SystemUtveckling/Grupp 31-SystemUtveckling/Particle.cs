﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Grupp_31_SystemUtveckling
{
    public class Particle
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public float angle;
        public float angularVelocity;
        public Color color;
        public float size;
        public float timeToLiveSeconds;

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity, float angle, 
            float angularVelocity, Color color, float size, float timeToLiveSeconds)
        {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            this.angle = angle;
            this.angularVelocity = angularVelocity;
            this.color = color;
            this.size = size;
            this.timeToLiveSeconds = timeToLiveSeconds;
        }

        public void Update(GameTime gameTime)
        {
            timeToLiveSeconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += velocity;
            angle += angularVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);

            spriteBatch.Draw(texture, position, sourceRectangle, color, angle, origin, size, SpriteEffects.None, 0f);
        }

    }
}
