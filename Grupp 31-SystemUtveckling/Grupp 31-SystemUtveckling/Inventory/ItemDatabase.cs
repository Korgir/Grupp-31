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
            items["redSword"] = new Item(Archive.textureDictionary["redSwordInventory"], "RedSword", 0, Item.ItemType.MainHand, 10, 6, 1);
            items["steelSword"] = new Item(Archive.textureDictionary["steelSwordInventory"], "SteelSword", 1, Item.ItemType.MainHand, 110, 70, 1);
        }
    }
}
