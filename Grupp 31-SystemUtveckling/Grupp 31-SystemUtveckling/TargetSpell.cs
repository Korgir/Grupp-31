using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    abstract class TargetSpell : Spell
    {
        public Character Target { get; private set; }

        public TargetSpell(Character caster, Character target) : base(caster)
        {
            this.Target = target;
        }

        public abstract void OnHit();
    }
}
