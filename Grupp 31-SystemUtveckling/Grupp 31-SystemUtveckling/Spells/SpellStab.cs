using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling.Spells
{
    class SpellStab : TargetSpell
    {
        public SpellStab(Character caster, Character target, TargetTeam targetTeam) : base(caster, target, targetTeam)
        {
        }

        public override void CastSpell()
        {
            // Play animation
            OnHit();
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
    }
}
