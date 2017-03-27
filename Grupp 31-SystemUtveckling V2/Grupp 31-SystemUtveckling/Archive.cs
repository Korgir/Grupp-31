using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    static class Archive
    {
        public static Dictionary<string, Texture2D> textureDictionary = new Dictionary<string, Texture2D>();
        public static Dictionary<string, SpriteFont> fontDictionary = new Dictionary<string, SpriteFont>();

        public static void Initialize(ContentManager Content)
        {
            // Order alphabetically
            // textureDictionary["name"] = Content.Load<Texture2D>("name_in_content_manager");
            // ex. textureDictionary["tile_stone"] = Content.Load<Texture2D>("Tiles\tile_stone");
            textureDictionary["owlbearCombat"] = Content.Load<Texture2D>("enemyCombatTest");
            textureDictionary["resourceBarFrame"] = Content.Load<Texture2D>("resourceBarFrame");
            textureDictionary["resourceBarFilling"] = Content.Load<Texture2D>("resourceBarFilling");
            textureDictionary["Tile"] = Content.Load<Texture2D>("grassTex");
            textureDictionary["warriorCombat"] = Content.Load<Texture2D>("playerCombatTest");
            textureDictionary["PlayerPlaceholder"] = Content.Load<Texture2D>("cool bild transparent");
            
            fontDictionary["defaultFont"] = Content.Load<SpriteFont>("font");
        }
    }
}
