using Microsoft.Xna.Framework;
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
        public Texture2D texture;
        public Texture2D textureOutline;
        protected Vector2 position;
        public Rectangle hitbox;

        public bool alive;
        public bool playerControlled;

        public string name;
        public int health, maxHealth;
        public int speed;
        public int armor;
        public int physicalDamageMin, physicalDamageMax;
        public int magicAmplification;
        public int mana, maxMana;
        public int manaRegeneration;
        public int hitChance;
        public int action;
        public int spellToCast;
        public List<Spell> spells;
        // To Do - Add List<Item> equippedItems when class is implemented

        public bool drawOutline;
        public Color outlineColor;

        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                position = value;
                hitbox = new Rectangle((int)position.X - texture.Width / 2, 
                    (int)position.Y - texture.Height / 2, texture.Width, texture.Height);
            }
        }

        public enum DamageType { Physical=0, Magical=1 };

        public Character(Texture2D texture, Texture2D textureOutline, Vector2 position, bool playerControlled, string name,int health, int speed, int armor, 
            int physicalDamageMin, int physicalDamageMax, int magicAmplification, int mana, 
            int manaRegeneration, int hitChance)
        {
            this.texture = texture;
            this.textureOutline = textureOutline;
            this.position = position;
            hitbox = new Rectangle((int)position.X - texture.Width / 2, (int)position.Y - texture.Height / 2, 
                texture.Width, texture.Height);

            alive = true;
            this.playerControlled = playerControlled;

            this.name = name;
            this.health = health;
            maxHealth = health;
            this.speed = speed;
            this.armor = armor;
            this.physicalDamageMin = physicalDamageMin;
            this.physicalDamageMax = physicalDamageMax;
            this.magicAmplification = magicAmplification;
            this.mana = mana;
            maxMana = mana;
            this.manaRegeneration = manaRegeneration;
            this.hitChance = hitChance;

            action = -1;
            spellToCast = -1;

            spells = new List<Spell>();
            spells.Add(new Spells.SpellStab(this, null, TargetSpell.TargetTeam.Enemy));
            spells.Add(new Spells.SpellFireball(this, null, TargetSpell.TargetTeam.Enemy));

            drawOutline = false;
            outlineColor = Color.White;
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

            Console.WriteLine(name + " takes " + totalDamage + " points of damage."); // Text Combat
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
            Console.WriteLine(name + " has died."); // Text Combat
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
            if (drawOutline)
            {
                spriteBatch.Draw(textureOutline, position, null, outlineColor, 0.0f,
                    new Vector2(textureOutline.Width / 2, textureOutline.Height / 2), 1.0f, SpriteEffects.None, 0);
            }

            if (alive)
            {
                spriteBatch.Draw(texture, position, null, Color.White, 0.0f, 
                    new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);
            }
            else
            {
                spriteBatch.Draw(texture, position, null, Color.Red, 0.0f,
                    new Vector2(texture.Width / 2, texture.Height / 2), 1.0f, SpriteEffects.None, 0);
            }
        }
    }
}
