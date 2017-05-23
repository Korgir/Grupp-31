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

        private int physicalDamageMax;
        private int physicalDamageMin;
        private int maxHealth;
        private int speed;
        private int armor;
        private int magicAmplification;
        private int maxMana;
        private int manaRegeneration;
        private int hitChance;

        public ItemType itemType;
        public enum ItemType { MainHand = 7, Head = 0, Chest = 1, Legs = 2, Hands = 6, Finger = 5, Neck = 4, Feet = 3, OffHand = 8, Quest = 10, Consumables = 11}

        public int ID;

        public Item(Texture2D itemTexture, string itemName, int itemID, ItemType type, 
            int maxHealth, int speed, int armor, int physicalDamageMin, int physicalDamageMax,
            int magicAmplification, int maxMana, int manaRegeneration, int hitChance)
        {
            this.itemTexture = itemTexture;
            this.itemName = itemName;
            this.ID = itemID;
            
            this.maxHealth = maxHealth;
            this.speed = speed;
            this.armor = armor;
            this.physicalDamageMin = physicalDamageMin;
            this.physicalDamageMax = physicalDamageMax;
            this.magicAmplification = magicAmplification;
            this.maxMana = maxMana;
            this.manaRegeneration = manaRegeneration;
            this.hitChance = hitChance;

            this.itemType = type;
        }

        public void OnEquip(Character actor)
        {
            float hpPercent = (float)actor.health / (float)actor.maxHealth;

            actor.maxHealth += this.maxHealth;
            actor.speed += this.speed;
            actor.armor += this.armor;
            actor.physicalDamageMin += this.physicalDamageMin;
            actor.physicalDamageMax += this.physicalDamageMax;
            actor.magicAmplification += this.magicAmplification;
            actor.maxMana += this.maxMana;
            actor.manaRegeneration += this.manaRegeneration;
            actor.hitChance += this.hitChance;

            actor.health = (int)((float)actor.maxHealth * hpPercent);
        }

        public void OnUnequip(Character actor)
        {
            float hpPercent = (float)actor.health / (float)actor.maxHealth;

            actor.maxHealth -= this.maxHealth;
            actor.speed -= this.speed;
            actor.armor -= this.armor;
            actor.physicalDamageMin -= this.physicalDamageMin;
            actor.physicalDamageMax -= this.physicalDamageMax;
            actor.magicAmplification -= this.magicAmplification;
            actor.maxMana -= this.maxMana;
            actor.manaRegeneration -= this.manaRegeneration;
            actor.hitChance -= this.hitChance;

            actor.health = (int)((float)actor.maxHealth * hpPercent);
        }
    }
}
