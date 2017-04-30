using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class DebuffStun : Buff
    {
        public DebuffStun(int durationTurns, Spell spell, Character target)
            : base(true, durationTurns, spell, target)
        {
        }

        public override void OnTick()
        {
            base.OnTick();

            Target.action = 0;
            Spell.damageNumbers.Add(new DamageNumber(Archive.textureDictionary["stun"], Target.Position, "Stunned", Color.LightBlue, 2.0f));
        }
    }
}
