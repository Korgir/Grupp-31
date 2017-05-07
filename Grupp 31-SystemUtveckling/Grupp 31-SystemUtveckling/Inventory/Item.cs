using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public class Item
    {
        public Texture2D itemTexture;
        private string itemName;
        private int itemID;
        private int powerMax;
        private int powerMin;
        private int attackSpeed;
        public ItemType itemType;
        public enum ItemType { MainHand = 7, Head = 0, Chest = 1, Legs = 2, Hands = 6, Finger = 5, Neck = 4, Feet = 3, OffHand = 8, Quest = 10, Consumables = 11}


        public Item(Texture2D itemTexture, string itemName, int itemID, ItemType type, int powerMax, int powerMin, int attackSpeed)
        {
            this.itemTexture = itemTexture;
            this.itemName = itemName;
            this.itemID = itemID;
            this.powerMax = powerMax;
            this.powerMin = powerMin;
            this.attackSpeed = attackSpeed;
            this.itemType = type;
        }

        public void OnEquip(Character actor)
        {
            actor.speed += attackSpeed;
            actor.physicalDamageMin += powerMin;
            actor.physicalDamageMax += powerMax;
        }

        public void OnUnequip(Character actor)
        {
            actor.speed -= attackSpeed;
            actor.physicalDamageMin -= powerMin;
            actor.physicalDamageMax -= powerMax;
        }
    }
}
