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

        public Character Caster { get; private set; }

        public Spell(Character caster)
        {
            this.Caster = caster;
            manaCost = 0;
            playingAnimation = false;
            iconTexture = Archive.textureDictionary["iconEmpty"];
        }

        public abstract void CastSpell();

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
