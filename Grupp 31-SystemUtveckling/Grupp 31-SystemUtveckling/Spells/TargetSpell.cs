using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    abstract class TargetSpell : Spell
    {
        public Character target;

        public TargetSpell(Character caster, Character target) : base(caster)
        {
            this.target = target;
        }

        public abstract void OnHit();
    }
}
