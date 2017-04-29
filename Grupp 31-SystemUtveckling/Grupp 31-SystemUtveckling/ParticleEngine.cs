using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Grupp_31_SystemUtveckling
{
    public class ParticleEngine
    {
        private Random random;
        public Vector2 emitterLocation;
        private List<Particle> particles;
        private Particle templetParticle;
        protected Color particleColor;
        protected int intensity;

        public enum ParticleType { Smoke }
        protected ParticleType type;

        public ParticleEngine(Vector2 location, ParticleType type, Color particleColor, int intensity)
        {
            emitterLocation = location;
            
            this.particles = new List<Particle>();
            random = new Random();
            this.type = type;
            this.particleColor = particleColor;
            this.intensity = intensity;
        }
       
        private Particle GenerateParticle()
        {
            Texture2D texture;
            Vector2 velocity;
            float angularVelocity;
            float size;
            float ttl;

            if ( type == ParticleType.Smoke)
            {
                texture = Archive.textureDictionary["smokeParticle" + Archive.randomizer.Next(0, 5)];
                velocity = new Vector2(Archive.randomizer.Next(-5, 5), Archive.randomizer.Next(-5, 5));
                angularVelocity = (float)MathHelper.ToRadians(Archive.randomizer.Next(-5, 5));
                size = (float)Archive.randomizer.Next(10, 30) / 100f;
                ttl = 0.3f;
                return new Particle(texture, emitterLocation, velocity, 0.0f, angularVelocity, particleColor, size, ttl);
            }

            return null;
        }

        public void EmittParticles()
        {
            for (int i = 0; i < intensity; i++)
            {
                particles.Add(GenerateParticle());
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update(gameTime);
                if (particles[particle].timeToLiveSeconds <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }

    }
}
