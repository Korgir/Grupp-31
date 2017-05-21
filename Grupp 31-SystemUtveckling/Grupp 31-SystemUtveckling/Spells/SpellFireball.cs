using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class SpellFireball : TargetSpell
    {
        private int damageMin = 10;
        private int damageMax = 15;
        private int damagePerMagicAmplification = 2;
        private float speed = 5f;

        Texture2D texture;
        List<Projectile> projectiles;
        List<ParticleEngine> particles;

        public SpellFireball(Character caster, Character target, TargetTeam targetTeam) 
            : base(caster, target, targetTeam)
        {
            iconTexture = Archive.textureDictionary["iconFireball"];

            projectiles = new List<Projectile>();
            particles = new List<ParticleEngine>();
            texture = Archive.textureDictionary["fireball"];
            manaCost = 30;
        }

        public override void CastSpell()
        {
            projectiles.Add(new Projectile(texture, Caster.Position, target.Position, speed));
            particles.Add(new ParticleEngine(Vector2.Zero, ParticleEngine.ParticleType.Smoke, Color.Red, 5));
            playingAnimation = true;
            Archive.soundEffectDictionary["fireballCast"].Play();
        }

        public override void OnHit()
        {
            playingAnimation = false;

            int damage = Archive.randomizer.Next(damageMin, damageMax) 
                + Caster.MagicAmplification * damagePerMagicAmplification;
            target.Damage(damage, Character.DamageType.Magical);

            Vector2 position = projectiles[projectiles.Count() - 1].position;
            damageNumbers.Add(new DamageNumber(Archive.textureDictionary["magic"], position, damage.ToString(), Color.Purple, 1.5f));
            Archive.soundEffectDictionary["fireballHit"].Play();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach (ParticleEngine p in particles)
            {
                p.Update(gameTime);
            }
            
            for (int i = projectiles.Count() -1; i >= 0; i--)
            {
                particles[i].emiterLocation = projectiles[i].position;
                particles[i].EmitParticles();
                projectiles[i].Update(gameTime);
                projectiles[i].speed *= 1 + 5 * (float)gameTime.ElapsedGameTime.TotalSeconds;


                if (projectiles[i].haveReachedDestination)
                {
                    OnHit();
                    projectiles.RemoveAt(i);
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
