using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    public class Item
    {
        private Texture2D itemTexture;
        private string itemName;
        private int itemID;
        private int powerMax;
        private int powerMin;
        private int attackSpeed;
        private ItemType itemType;
        public enum ItemType { Weapon, Helmet, BodyArmor, PantsArmor, Gloves, Ring, Amulet, Boots, DualWeapon, QuestItem, Consumables}


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
        public Texture2D ItemTexture
        {
            set { itemTexture = value; }
            get { return itemTexture; }
        }
        public string ItemName
        {
            set { itemName = value; }
            get { return itemName; }
        }
        public int ItemID
        {
            set { itemID = value; }
            get { return itemID; }
        }
        public int PowerMax
        {
            set { powerMax = value; }
            get { return powerMax; }
        }
        public int PowerMin
        {
            set { powerMin = value; }
            get { return powerMin; }
        }
        public int AttackSpeed
        {
            set { attackSpeed = value; }
            get { return attackSpeed; }
        }
    }
}
