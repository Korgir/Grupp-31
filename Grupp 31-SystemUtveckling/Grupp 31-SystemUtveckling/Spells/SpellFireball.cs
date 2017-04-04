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
        private int damagePerMagicAmplification = 10;

        public SpellFireball(Character caster, Character target, TargetTeam targetTeam) 
            : base(caster, target, targetTeam)
        {
        }

        public override void CastSpell()
        {
            // Play animation
            OnHit();
        }

        public override void OnHit()
        {
            int damage = Archive.randomizer.Next(damageMin, damageMax) 
                + Caster.magicAmplification * damagePerMagicAmplification;
            target.Damage(damage, Character.DamageType.Magical);
        }
    }
}
