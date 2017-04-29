using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    abstract class Buff
    {
        public bool debuff;
        public int durationTurns;

        public Buff(bool debuff, int durationTurns)
        {

            this.debuff = debuff;
            this.durationTurns = durationTurns;
        }

        public abstract void OnTick();
        public abstract void OnFinish();
    }
}
