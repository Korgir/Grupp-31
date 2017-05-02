using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public static class ItemDatabase
    {
        static public List<Item> items = new List<Item>();

        public static void LoadItemDatabase()
        {
            items.Add(new Item(Archive.textureDictionary["redSword"], "RedSword", 0, Item.ItemType.Weapon, 10, 6, 1));
            items.Add(new Item(Archive.textureDictionary["steelSword"], "SteelSword", 1, Item.ItemType.Weapon, 11, 7, 1));
        }
    }
}
