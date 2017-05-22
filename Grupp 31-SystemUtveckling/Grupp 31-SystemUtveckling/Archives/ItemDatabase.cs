using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public static class ItemDatabase
    {
        static public Dictionary<string, Item> items = new Dictionary<string, Item>();

        public static void Initialize()
        {
            items["weaponT1"] = new Item(Archive.textureDictionary["brownWeapon"], "Bronze Scythe", 1, Item.ItemType.MainHand,
                0, 1, 0, 7, 10, 0, 0, 0, 0);
            items["weaponT2"] = new Item(Archive.textureDictionary["grayWeapon"], "Iron Scythe", 2, Item.ItemType.MainHand,
                0, 5, 0, 12, 15, 0, 0, 0, 0);
            items["weaponT3"] = new Item(Archive.textureDictionary["greenWeapon"], "Emerald Scythe", 3, Item.ItemType.MainHand,
                0, 9, 0, 17, 20, 0, 0, 0, 0);
            items["weaponT4"] = new Item(Archive.textureDictionary["redWeapon"], "Ruby Scythe", 4, Item.ItemType.MainHand,
                0, 13, 0, 22, 25, 0, 0, 0, 0);

            items["armorT1"] = new Item(Archive.textureDictionary["grayArmor"], "Iron Scythe", 5, Item.ItemType.Chest,
                10, 0, 2, 0, 0, 0, 0, 0, 0);
            items["armorT2"] = new Item(Archive.textureDictionary["greenArmor"], "Emerald Scythe", 6, Item.ItemType.Chest,
                30, 0, 5, 0, 0, 0, 0, 0, 0);
            items["armorT3"] = new Item(Archive.textureDictionary["blueArmor"], "Sapphire Scythe", 7, Item.ItemType.Chest,
                90, 0, 8, 0, 0, 0, 0, 0, 0);
            items["armorT4"] = new Item(Archive.textureDictionary["redArmor"], "Ruby Scythe", 8, Item.ItemType.Chest,
                180, 0, 13, 0, 0, 0, 0, 0, 0);

            items["bootsT1"] = new Item(Archive.textureDictionary["grayBoots"], "Iron Boots", 9, Item.ItemType.Feet,
                0, 20, 1, 0, 0, 0, 0, 0, 0);
            items["bootsT2"] = new Item(Archive.textureDictionary["greenBoots"], "Emerald Boots", 10, Item.ItemType.Feet,
                0, 40, 2, 0, 0, 0, 0, 0, 0);
            items["bootsT3"] = new Item(Archive.textureDictionary["blueBoots"], "Sapphire Boots", 11, Item.ItemType.Feet,
                0, 60, 3, 0, 0, 0, 0, 0, 0);
            items["bootsT4"] = new Item(Archive.textureDictionary["redBoots"], "Ruby Boots", 12, Item.ItemType.Feet,
                0, 80, 4, 0, 0, 0, 0, 0, 0);

            items["glovesT1"] = new Item(Archive.textureDictionary["grayGloves"], "Iron Gloves", 13, Item.ItemType.Hands,
                0, 0, 0, 5, 5, 0, 0, 0, 0);
            items["glovesT2"] = new Item(Archive.textureDictionary["greenGloves"], "Emerald Gloves", 14, Item.ItemType.Hands,
                0, 0, 0, 10, 10, 0, 0, 0, 0);
            items["glovesT3"] = new Item(Archive.textureDictionary["blueGloves"], "Sapphire Gloves", 15, Item.ItemType.Hands,
                0, 0, 0, 15, 15, 0, 0, 0, 0);
            items["glovesT4"] = new Item(Archive.textureDictionary["redGloves"], "Ruby Gloves", 16, Item.ItemType.Hands,
                0, 0, 0, 20, 20, 0, 0, 0, 0);

            items["helmT1"] = new Item(Archive.textureDictionary["grayHelm"], "Iron Helm", 17, Item.ItemType.Head,
                3, 0, 1, 0, 0, 0, 0, 0, 0);
            items["helmT2"] = new Item(Archive.textureDictionary["greenHelm"], "Emerald Helm", 18, Item.ItemType.Head,
                6, 0, 2, 0, 0, 0, 0, 0, 0);
            items["helmT3"] = new Item(Archive.textureDictionary["blueHelm"], "Sapphire Helm", 19, Item.ItemType.Head,
                9, 0, 3, 0, 0, 0, 0, 0, 0);
            items["helmT4"] = new Item(Archive.textureDictionary["redHelm"], "Ruby Helm", 20, Item.ItemType.Head,
                12, 0, 4, 0, 0, 0, 0, 0, 0);

            items["legsT1"] = new Item(Archive.textureDictionary["grayLegs"], "Iron Legs", 21, Item.ItemType.Legs,
                10, 0, 0, 0, 0, 0, 0, 0, 0);
            items["legsT2"] = new Item(Archive.textureDictionary["greenLegs"], "Emerald Legs", 22, Item.ItemType.Legs,
                30, 0, 0, 0, 0, 0, 0, 0, 0);
            items["legsT3"] = new Item(Archive.textureDictionary["blueLegs"], "Sapphire Legs", 23, Item.ItemType.Legs,
                90, 0, 0, 0, 0, 0, 0, 0, 0);
            items["legsT4"] = new Item(Archive.textureDictionary["redLegs"], "Ruby Legs", 24, Item.ItemType.Legs,
                180, 0, 0, 0, 0, 0, 0, 0, 0);

            // Quest items
            items["furniture"] = new Item(Archive.textureDictionary["keyInventory"], "QuestItem", 999, Item.ItemType.Quest,
                0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
}
