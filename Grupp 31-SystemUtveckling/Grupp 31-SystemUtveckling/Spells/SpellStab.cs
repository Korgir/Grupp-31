using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grupp_31_SystemUtveckling.Spells
{
    class SpellStab : TargetSpell
    {
        List<Animation> animations;

        public SpellStab(Character caster, Character target, TargetTeam targetTeam) : base(caster, target, targetTeam)
        {
            animations = new List<Animation>();
        }

        public override void CastSpell()
        {
            animations.Add(new Animation(Archive.textureDictionary["slash"], 4, 1, 0.05f, true, true));
        }

        public override void OnHit()
        {
            if (Archive.randomizer.Next(1, 100) < Caster.hitChance)
            {
                // To Do - For each item equipped run item.OnAttack()
                int damage = Archive.randomizer.Next(Caster.physicalDamageMin, Caster.physicalDamageMax);
                target.Damage(damage, Character.DamageType.Physical);
            }
        }

        public override void Update(GameTime gameTime)
        {
            for (int i = animations.Count() - 1; i >= 0; i--)
            {
                if (!animations[i].playing)
                {
                    animations.RemoveAt(i);
                    OnHit();
                }
                else
                {
                    animations[i].Update(gameTime);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Animation a in animations)
            {
                a.Draw(spriteBatch, target.Position);
            }
        }
    }
}
