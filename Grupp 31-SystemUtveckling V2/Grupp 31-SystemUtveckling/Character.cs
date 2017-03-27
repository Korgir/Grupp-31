﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Character
    {
        protected Texture2D texture;
        public Vector2 position;

        public bool alive;
        public bool playerControlled;

        public int health, maxHealth;
        public int speed;
        public int armor;
        public int physicalDamageMin, physicalDamageMax;
        public int magicAmplification;
        public int mana, maxMana;
        public int manaRegeneration;
        public int hitChance;
        public int action;
        // To Do - Add List<Spell> Spells when the class is implemented

        public enum DamageType { Physical=0, Magical=1 };

        public Character(Texture2D texture, Vector2 position, bool playerControlled, int health, int speed, int armor, 
            int physicalDamageMin, int physicalDamageMax, int magicAmplification, int mana, 
            int manaRegeneration, int hitChance)
        {
            this.texture = texture;
            this.position = position;

            this.alive = true;
            this.playerControlled = playerControlled;

            this.health = health;
            this.maxHealth = health;
            this.speed = speed;
            this.armor = armor;
            this.physicalDamageMin = physicalDamageMin;
            this.physicalDamageMax = physicalDamageMax;
            this.mana = mana;
            this.maxMana = mana;
            this.manaRegeneration = manaRegeneration;
            this.hitChance = hitChance;
            this.action = 0;
        }

        public void OnNewTurn()
        {
            RegenerateMana();
        }

        public bool RegenerateMana()
        {
            if (mana >= maxMana)
            {
                return false;
            }

            mana += manaRegeneration;
            if (mana > maxMana)
            {
                mana = maxMana;
            }
            return true;
        }

        public bool Damage(int value, DamageType type)
        {
            int totalDamage = value;

            if (type == DamageType.Physical)
            {
                float armorModifier = 0.06f;
                totalDamage -= (int)(totalDamage * (((float)armor * armorModifier) / (1f + (float)armor * armorModifier)));
            }

            if (health <= 0)
            {
                return false;
            }

            health -= totalDamage;
            if (health <= 0)
            {
                Kill();
            }

            if (totalDamage > 0)
            {
                return true;
            }
            return false;
        }

        public bool Kill()
        {
            if (!alive)
            {
                return false;
            }

            health = 0;
            alive = false;

            return true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);
        }
    }
}