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

        public SpellFireball(Character caster, Character target, TargetTeam targetTeam) 
            : base(caster, target, targetTeam)
        {
            projectiles = new List<Projectile>();

            texture = Archive.textureDictionary["fireball"];
        }

        public override void CastSpell()
        {
            projectiles.Add(new Projectile(texture, Caster.Position, target.Position, speed));
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
                projectiles[i].Update(gameTime);
                projectiles[i].speed *= 1 + 5 * (float)gameTime.ElapsedGameTime.TotalSeconds;


                if (projectiles[i].haveReachedDestination)
                {
                    projectiles.RemoveAt(i);
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
        }
    }
}
