using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class DebuffBleed : Buff
    {
        protected int minDamage;
        protected int maxDamage;

        public DebuffBleed(int durationTurns, Spell spell, Character target)
            : base(true, durationTurns, spell, target)
        {
            minDamage = Spell.Caster.PhysicalDamageMin / 5;
            maxDamage = Spell.Caster.PhysicalDamageMax / 5;
        }

        public override void OnTick()
        {
            base.OnTick();

            int damage = Archive.randomizer.Next(minDamage, maxDamage);
            if (damage > 0)
            {
                Target.Damage(damage, Character.DamageType.Physical);

                Spell.damageNumbers.Add(new DamageNumber(Archive.textureDictionary["bleed"], Target.Position, damage.ToString(), Color.Red, 1.5f));
            }
        }
    }
}
