using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling.Spells
{
    class SpellFireball : TargetSpell
    {
        private int damageMin = 10;
        private int damageMax = 15;
        private int damagePerMagicAmplification = 2;
        private float speed = 5f;

        Texture2D texture;
        List<Projectile> projectiles;
        Particle templateParticle;
        List<ParticleEngine> particles;

        public SpellFireball(Character caster, Character target, TargetTeam targetTeam) 
            : base(caster, target, targetTeam)
        {
            iconTexture = Archive.textureDictionary["iconFireball"];

            projectiles = new List<Projectile>();
            particles = new List<ParticleEngine>();
            texture = Archive.textureDictionary["fireball"];
            templateParticle = new Particle(Archive.textureDictionary["fireball"], Vector2.Zero, Vector2.Zero, 0f, 0.3f, Color.White, 0.1f, 10000);
        }

        public override void CastSpell()
        {
            projectiles.Add(new Projectile(texture, Caster.Position, target.Position, speed));
            particles.Add(new ParticleEngine(Vector2.Zero, templateParticle));
            playingAnimation = true;
        }

        public override void OnHit()
        {
            playingAnimation = false;

            int damage = Archive.randomizer.Next(damageMin, damageMax) 
                + Caster.magicAmplification * damagePerMagicAmplification;
            target.Damage(damage, Character.DamageType.Magical);
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = projectiles.Count() -1; i >= 0; i--)
            {
                particles[i].EmitterLocation = projectiles[i].position;
                particles[i].Update();
                projectiles[i].Update(gameTime);
                projectiles[i].speed *= 1 + 5 * (float)gameTime.ElapsedGameTime.TotalSeconds;


                if (projectiles[i].haveReachedDestination)
                {
                    projectiles.RemoveAt(i);
                    particles.RemoveAt(i);
                    OnHit();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }
            foreach (ParticleEngine p in particles)
            {
                p.Draw(spriteBatch);
            }
        }
    }
}
