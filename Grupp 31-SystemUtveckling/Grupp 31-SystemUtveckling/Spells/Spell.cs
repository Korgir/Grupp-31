using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    abstract class Spell
    {
        public Texture2D iconTexture;
        public int manaCost;
        public bool playingAnimation;
        public List<DamageNumber> damageNumbers;

        public Character Caster { get; private set; }

        public Spell(Character caster)
        {
            this.Caster = caster;
            manaCost = 0;
            playingAnimation = false;
            iconTexture = Archive.textureDictionary["iconEmpty"];
            damageNumbers = new List<DamageNumber>();
        }

        public abstract void CastSpell();

        public virtual void Update(GameTime gameTime)
        {
            for (int i = damageNumbers.Count()-1; i >= 0; i--)
            {
                damageNumbers[i].Update(gameTime);
                if (damageNumbers[i].transparancy == 0)
                {
                    damageNumbers.RemoveAt(i);
                }
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void DrawUI(SpriteBatch spriteBatch)
        {
            foreach (DamageNumber d in damageNumbers)
            {
                d.Draw(spriteBatch);
            }
        }
    }
}
