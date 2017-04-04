using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    abstract class TargetSpell : Spell
    {
        public enum TargetTeam { Both = 0, Friendly = 1, Enemy = 2 };

        public Character target;
        public TargetTeam targetTeam;

        public TargetSpell(Character caster, Character target, TargetTeam targetTeam) : base(caster)
        {
            this.target = target;
            this.targetTeam = targetTeam;
        }

        public abstract void OnHit();
    }
}
