using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    abstract class Spell
    {
        private int manaCost;

        public Character Caster { get; private set; }

        public Spell(Character caster)
        {
            this.Caster = caster;
        }

        public abstract void CastSpell();
    }
}
