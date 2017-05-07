using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public abstract class Buff
    {
        public bool debuff;
        public int durationTurns;

        public Spell Spell { get; private set; }
        public Character Target { get; private set; }

        public bool removable;

        public Buff(bool debuff, int durationTurns, Spell spell, Character target)
        {
            this.debuff = debuff;
            this.durationTurns = durationTurns;

            Spell = spell;
            Target = target;

            removable = false;
        }

        public virtual void OnTick()
        {
            durationTurns--;
            if (durationTurns <= 0)
            {
                OnFinish();
            }
        }

        public virtual void OnFinish()
        {
            removable = true;
        }
    }
}
