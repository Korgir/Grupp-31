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
        public DebuffBleed(int durationTurns, Spell spell, Character target)
            : base(true, durationTurns, spell, target)
        {
        }

        public override void OnTick()
        {
            base.OnTick();

            int damage = Archive.randomizer.Next(Spell.Caster.physicalDamageMin, Spell.Caster.physicalDamageMax) / 5;
            if (damage > 0)
            {
                Target.Damage(damage, Character.DamageType.Physical);

                Spell.damageNumbers.Add(new DamageNumber(Archive.textureDictionary["bleed"], Target.Position, damage.ToString(), Color.Red, 1.5f));
            }
        }
    }
}
