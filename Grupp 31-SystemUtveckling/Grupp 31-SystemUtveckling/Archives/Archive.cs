using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        public static Dictionary<string, Song> songDictionary = new Dictionary<string, Song>();
        public static Dictionary<string, SoundEffect> soundEffectDictionary = new Dictionary<string, SoundEffect>();
        public static Random randomizer = new Random();
        public static int tileSize = 32;

        public static void Initialize(ContentManager Content)
        {
            // Order alphabetically and placed under corresponding category
            // textureDictionary["name"] = Content.Load<Texture2D>("name_in_content_manager");
            // ex. textureDictionary["tile_stone"] = Content.Load<Texture2D>("Tiles\tile_stone");

            // Misc textures
            textureDictionary["button"] = Content.Load<Texture2D>("button");
            textureDictionary["combatScenary"] = Content.Load<Texture2D>("ForestBattleBackground");
            textureDictionary["fireball"] = Content.Load<Texture2D>("fireball");
            textureDictionary["menuBackground"] = Content.Load<Texture2D>("menuBackground");
            textureDictionary["menuHeader"] = Content.Load<Texture2D>("menuHeader");
            textureDictionary["resourceBarFilling"] = Content.Load<Texture2D>("resourceBarFilling");
            textureDictionary["resourceBarFrame"] = Content.Load<Texture2D>("resourceBarFrame");
            textureDictionary["slash"] = Content.Load<Texture2D>("slashAnimation");
            textureDictionary["uiCombat"] = Content.Load<Texture2D>("combatUITemplate"); 
            textureDictionary["uiWorld"] = Content.Load<Texture2D>("UIBasePlaceholder");
            textureDictionary["whitePixel"] = Content.Load<Texture2D>("whitePixel");
            textureDictionary["tabs"] = Content.Load<Texture2D>("tabs");
            textureDictionary["arrowDown"] = Content.Load<Texture2D>("arrowDown");
            textureDictionary["arrowLeft"] = Content.Load<Texture2D>("arrowLeft");
            textureDictionary["arrowRight"] = Content.Load<Texture2D>("arrowRight");
            textureDictionary["arrowUp"] = Content.Load<Texture2D>("arrowUp");

            // Items
            textureDictionary["steelSwordInventory"] = Content.Load<Texture2D>("Items\\SteelSword");
            textureDictionary["redSwordInventory"] = Content.Load<Texture2D>("Items\\RedSword");
            textureDictionary["keyInventory"] = Content.Load<Texture2D>("Items\\questItem");

            // Items world
            textureDictionary["sword"] = Content.Load<Texture2D>("Items\\World\\sword");

            // Combat characters
            textureDictionary["demonDaggers"] = Content.Load<Texture2D>("Enemies\\daggerShadowBeastCombat");
            textureDictionary["demonDaggersOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\daggerShadowBeastCombatOutline");
            textureDictionary["demonSpear"] = Content.Load<Texture2D>("Enemies\\spearShadowBeastCombat");
            textureDictionary["demonSpearOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\spearShadowBeastCombatOutline");
            textureDictionary["demonMage"] = Content.Load<Texture2D>("Enemies\\thunderShadowBeastCombat");
            textureDictionary["demonMageOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\thunderShadowBeastCombatOutline");
            textureDictionary["demonWarlock"] = Content.Load<Texture2D>("Enemies\\warlockShadowBeastCombat");
            textureDictionary["demonWarlockOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\warlockShadowBeastCombatOutline");
            textureDictionary["goblinCombat"] = Content.Load<Texture2D>("Enemies\\daggerGoblinCombat");
            textureDictionary["goblinCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\daggerGoblinCombatOutline");
            textureDictionary["owlbearCombat"] = Content.Load<Texture2D>("Enemies\\daggerShadowBeastCombat");
            textureDictionary["owlbearCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\daggerShadowBeastCombatOutline");
            textureDictionary["warriorCombat"] = Content.Load<Texture2D>("Enemies\\reaperCombat");
            textureDictionary["warriorCombatOutline"] = Content.Load<Texture2D>("Enemies\\Outline\\reaperCombatOutline");

            // Icons
            textureDictionary["iconEmpty"] = Content.Load<Texture2D>("Icons\\IconEmpty");
            textureDictionary["iconFireball"] = Content.Load<Texture2D>("Icons\\IconFireball");
            textureDictionary["iconGoblin"] = Content.Load<Texture2D>("Icons\\IconGoblin");
            textureDictionary["iconPass"] = Content.Load<Texture2D>("Icons\\IconPass");
            textureDictionary["iconScythe"] = Content.Load<Texture2D>("Icons\\IconScythe");

            // Status effects
            textureDictionary["bleed"] = Content.Load<Texture2D>("StatusEffects\\bleed");
            textureDictionary["magic"] = Content.Load<Texture2D>("StatusEffects\\magic");
            textureDictionary["miss"] = Content.Load<Texture2D>("StatusEffects\\miss");
            textureDictionary["physical"] = Content.Load<Texture2D>("StatusEffects\\physical");
            textureDictionary["stun"] = Content.Load<Texture2D>("StatusEffects\\stun");

            // Particles
            for (int i = 0; i < 5; i++)
            {
                textureDictionary["smokeParticle" + i] = Content.Load<Texture2D>("Particles\\whitePuff" + i);
            }

            // Floor tiles
            textureDictionary["dungeonFloor1"] = Content.Load<Texture2D>("Tiles\\Floor\\floor1");
            textureDictionary["dungeonFloor2"] = Content.Load<Texture2D>("Tiles\\Floor\\floor2");
            textureDictionary["dungeonFloor3"] = Content.Load<Texture2D>("Tiles\\Floor\\floor3");
            textureDictionary["dungeonFloor4"] = Content.Load<Texture2D>("Tiles\\Floor\\floor4");
            textureDictionary["dungeonFloor5"] = Content.Load<Texture2D>("Tiles\\Floor\\floor5");
            textureDictionary["dungeonFloor6"] = Content.Load<Texture2D>("Tiles\\Floor\\floor6");
            textureDictionary["grass"] = Content.Load<Texture2D>("Tiles\\Floor\\grass");
            textureDictionary["plank"] = Content.Load<Texture2D>("Tiles\\Floor\\plank");
            textureDictionary["road"] = Content.Load<Texture2D>("Tiles\\Floor\\dirt");
            for (int i = 1; i <= 16; i++)
            {
                textureDictionary["grassRoad" + i] = Content.Load<Texture2D>("Tiles\\Floor\\GrassDirt\\grassDirt" + i);
            }

            // Wall tiles
            textureDictionary["dungeonWall1"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide1");
            textureDictionary["dungeonWall2"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide2");
            textureDictionary["dungeonWall3"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide3");
            textureDictionary["dungeonWall4"] = Content.Load<Texture2D>("Tiles\\Wall\\wallSide4");
            textureDictionary["dungeonWall5"] = Content.Load<Texture2D>("Tiles\\Wall\\wallTop1");
            textureDictionary["dungeonWall6"] = Content.Load<Texture2D>("Tiles\\Wall\\wallTop2");
            textureDictionary["smallTree"] = Content.Load<Texture2D>("Tiles\\Wall\\smallTree");
            textureDictionary["water"] = Content.Load<Texture2D>("Tiles\\Wall\\water");
            for (int i = 1; i <= 8; i++)
            {
                textureDictionary["waterGrass" + i] = Content.Load<Texture2D>("Tiles\\Wall\\WaterGrass\\waterGrass" + i);
            }

            // Entities
            textureDictionary["playerPlaceholder"] = Content.Load<Texture2D>("Entities\\CharacterSpriteSheet");
            for (int i = 1; i <= 2; i++)
            {
                textureDictionary["hostile" + i] = Content.Load<Texture2D>("Entities\\hostile" + i);
            }
            for (int i = 1; i <= 4; i++)
            {
                textureDictionary["npc" + i] = Content.Load<Texture2D>("Entities\\npc" + i);
            }

            // Fonts
            fontDictionary["defaultFont"] = Content.Load<SpriteFont>("font");
            fontDictionary["dialogFont"] = Content.Load<SpriteFont>("gameFont");
            fontDictionary["infoFont"] = Content.Load<SpriteFont>("infoFont");
            fontDictionary["objectiveDescription"] = Content.Load<SpriteFont>("objectiveFont");
            fontDictionary["questTitle"] = Content.Load<SpriteFont>("questFont");

            // Songs
            songDictionary["hidden"] = Content.Load<Song>("Music\\Bulywug_beatdown");
            songDictionary["dungeon"] = Content.Load<Song>("Music\\Into_the_dungeon_we_go");
            songDictionary["forest"] = Content.Load<Song>("Music\\Malice_and_forest");
            songDictionary["combat"] = Content.Load<Song>("Music\\Send_nudes");

            // Sound Effects
            soundEffectDictionary["equip"] = Content.Load<SoundEffect>("SoundEffects\\equip");
            soundEffectDictionary["fireballCast"] = Content.Load<SoundEffect>("SoundEffects\\fireball_cast");
            soundEffectDictionary["fireballHit"] = Content.Load<SoundEffect>("SoundEffects\\fireball_hit");
            soundEffectDictionary["pickUp"] = Content.Load<SoundEffect>("SoundEffects\\pick_up");
            soundEffectDictionary["swordHit"] = Content.Load<SoundEffect>("SoundEffects\\sword_hit");
            soundEffectDictionary["swordMiss"] = Content.Load<SoundEffect>("SoundEffects\\sword_miss");
            soundEffectDictionary["throwCast"] = Content.Load<SoundEffect>("SoundEffects\\throw_cast");
            soundEffectDictionary["throwHit"] = Content.Load<SoundEffect>("SoundEffects\\throw_hit");
        }
    }
}
