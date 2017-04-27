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
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> particles;
        private List<Texture2D> textures;
        private Particle templetParticle;

        public ParticleEngine(Vector2 location, Particle templetParticle)
        {
            EmitterLocation = location;
            
            this.particles = new List<Particle>();
            random = new Random();
            this.templetParticle = templetParticle;
        }

       
        private Particle GenerateParticle()
        {
            Texture2D texture = templetParticle.texture;
            Vector2 position = EmitterLocation;
            Vector2 velocity = templetParticle.velocity;
            float angle = templetParticle.angle;
            float angularVelocity = templetParticle.angularVelocity;
            Color color = templetParticle.color;
            float size = templetParticle.size;
            int ttl = templetParticle.TTL;
            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Update()
        {
            int total = 10;
            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateParticle());
            }
            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
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
