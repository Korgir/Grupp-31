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
        public static Random randomizer = new Random();
        public static int tileSize = 32;

        public static void Initialize(ContentManager Content)
        {
            // Order alphabetically and placed under corresponding category
            // textureDictionary["name"] = Content.Load<Texture2D>("name_in_content_manager");
            // ex. textureDictionary["tile_stone"] = Content.Load<Texture2D>("Tiles\tile_stone");

            // Misc textures
            textureDictionary["button"] = Content.Load<Texture2D>("button");
            textureDictionary["combatScenary"] = Content.Load<Texture2D>("combatScenary");
            textureDictionary["menuBackground"] = Content.Load<Texture2D>("menuBackground");
            textureDictionary["menuHeader"] = Content.Load<Texture2D>("menuHeader");
            textureDictionary["owlbearCombat"] = Content.Load<Texture2D>("Enemies\\daggerShadowBeastCombat");
            textureDictionary["owlbearCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\daggerShadowBeastCombatOutline");
            textureDictionary["playerPlaceholder"] = Content.Load<Texture2D>("CharacterSpriteSheet");
            textureDictionary["resourceBarFilling"] = Content.Load<Texture2D>("resourceBarFilling");
            textureDictionary["resourceBarFrame"] = Content.Load<Texture2D>("resourceBarFrame");
            textureDictionary["tileDoor"] = Content.Load<Texture2D>("TileDoor");
            textureDictionary["uiCombat"] = Content.Load<Texture2D>("combatUITemplate"); 
            textureDictionary["uiWorld"] = Content.Load<Texture2D>("UIBasePlaceholder");
            textureDictionary["warriorCombat"] = Content.Load<Texture2D>("Enemies\\reaperCombat");
            textureDictionary["warriorCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\reaperCombatOutline");
            textureDictionary["whitePixel"] = Content.Load<Texture2D>("whitePixel");

            // Floor tiles
            textureDictionary["dungeonFloor1"] = Content.Load<Texture2D>("Tiles\\Floor\\floor1");
            textureDictionary["dungeonFloor2"] = Content.Load<Texture2D>("Tiles\\Floor\\floor2");
            textureDictionary["dungeonFloor3"] = Content.Load<Texture2D>("Tiles\\Floor\\floor3");
            textureDictionary["dungeonFloor4"] = Content.Load<Texture2D>("Tiles\\Floor\\floor4");
            textureDictionary["dungeonFloor5"] = Content.Load<Texture2D>("Tiles\\Floor\\floor5");
            textureDictionary["dungeonFloor6"] = Content.Load<Texture2D>("Tiles\\Floor\\floor6");
            textureDictionary["grass"] = Content.Load<Texture2D>("Tiles\\Floor\\grass");
            textureDictionary["plank"] = Content.Load<Texture2D>("Tiles\\Floor\\plank");
            textureDictionary["road"] = Content.Load<Texture2D>("Tiles\\Floor\\road");

            // Wall tiles
            textureDictionary["dungeonWall1"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide1");
            textureDictionary["dungeonWall2"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide2");
            textureDictionary["dungeonWall3"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide3");
            textureDictionary["dungeonWall4"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide4");
            textureDictionary["dungeonWall5"] = Content.Load<Texture2D>("Tiles\\Wall\\wallTop1");
            textureDictionary["dungeonWall6"] = Content.Load<Texture2D>("Tiles\\Wall\\wallTop2");

            // Fonts
            fontDictionary["defaultFont"] = Content.Load<SpriteFont>("font");
        }
    }
}
