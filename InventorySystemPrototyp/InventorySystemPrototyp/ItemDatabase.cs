using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    public static class ItemDatabase
    {
      static public List<Item> items = new List<Item>();

         public static void LoadItemDatabase()
        {
            items.Add(new Item(AssetsManager.redSwordTex, "RedSword", 0, Item.ItemType.Weapon, 10, 6, 1));
            items.Add(new Item(AssetsManager.steelSwordTex, "SteelSword", 1, Item.ItemType.Weapon, 11, 7, 1));
        }
    }
}
