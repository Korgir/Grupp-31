﻿using Microsoft.Xna.Framework.Content;
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

        public static void Initialize(ContentManager Content)
        {
            // Order alphabetically
            // textureDictionary["name"] = Content.Load<Texture2D>("name_in_content_manager");
            // ex. textureDictionary["tile_stone"] = Content.Load<Texture2D>("Tiles\tile_stone");
            textureDictionary["uiCombat"] = Content.Load<Texture2D>("combatUITemplate");
            textureDictionary["owlbearCombat"] = Content.Load<Texture2D>("Enemies\\enemyCombatTest");
            textureDictionary["owlbearCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\enemyCombatTestOutline");
            textureDictionary["playerPlaceholder"] = Content.Load<Texture2D>("cool bild transparent");
            textureDictionary["resourceBarFrame"] = Content.Load<Texture2D>("resourceBarFrame");
            textureDictionary["resourceBarFilling"] = Content.Load<Texture2D>("resourceBarFilling");
            textureDictionary["tile"] = Content.Load<Texture2D>("Tile");
            textureDictionary["tileDoor"] = Content.Load<Texture2D>("TileDoor");
            textureDictionary["warriorCombat"] = Content.Load<Texture2D>("Enemies\\playerCombatTest");
            textureDictionary["warriorCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\playerCombatTestOutline");

            fontDictionary["defaultFont"] = Content.Load<SpriteFont>("font");
        }
    }
}
