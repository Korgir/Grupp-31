using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Grupp_31_SystemUtveckling
{
    class SpellStab : TargetSpell
    {
        List<Animation> animations;

        public SpellStab(Character caster, Character target, TargetTeam targetTeam) : base(caster, target, targetTeam)
        {
            animations = new List<Animation>();
            iconTexture = Archive.textureDictionary["iconScythe"];
        }

        public override void CastSpell()
        {
            animations.Add(new Animation(Archive.textureDictionary["slash"], 4, 1, 0.05f, true, true));
            playingAnimation = true;
        }

        public override void OnHit()
        {
            playingAnimation = false;
            if (Archive.randomizer.Next(1, 100) < Caster.hitChance)
            {
                // To Do - For each item equipped run item.OnAttack()
                int damage = Archive.randomizer.Next(Caster.PhysicalDamageMin, Caster.PhysicalDamageMax);
                target.Damage(damage, Character.DamageType.Physical);

                damageNumbers.Add(new DamageNumber(Archive.textureDictionary["physical"], target.Position, damage.ToString(), Color.Orange, 1.5f));

                target.buffs.Add(new DebuffBleed(3, this, target));
            }
            else
            {
                damageNumbers.Add(new DamageNumber(Archive.textureDictionary["miss"], target.Position, "Miss", Color.White, 1.5f));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

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
