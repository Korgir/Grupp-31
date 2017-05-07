using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    public class Character
    {
        public Texture2D texture;
        public Texture2D textureOutline;
        protected Vector2 position;
        public Rectangle hitbox;

        public bool alive;
        public bool playerControlled;
        public string name;

        public int health, maxHealth;
        public int speed, temporarySpeed;
        public int armor, temporaryArmor;
        public int physicalDamageMin, physicalDamageMax,
            temporaryPhysicalDamageMin, temporaryPhysicalDamageMax;
        public int magicAmplification, temporaryMagicAmplification;
        public int mana, maxMana;
        public int manaRegeneration, temporaryManaRegeneration;
        public int hitChance, temporaryHitChance;

        public int action;
        public int spellToCast;
        public List<Spell> spells;
        public List<Buff> buffs;
        protected List<Item> equippedItems;

        public bool drawOutline;
        public Color outlineColor;

        public int Speed
        {
            get { return (speed + temporarySpeed); }
            private set { }
        }
        public int Armor
        {
            get { return (armor + temporaryArmor); }
            private set { }
        }
        public int PhysicalDamageMin
        {
            get { return (physicalDamageMin + temporaryPhysicalDamageMin); }
            private set { }
        }
        public int PhysicalDamageMax
        {
            get { return (physicalDamageMax + temporaryPhysicalDamageMax); }
            private set { }
        }
        public int MagicAmplification
        {
            get { return (magicAmplification + temporaryMagicAmplification); }
            private set { }
        }
        public int ManaRegeneration
        {
            get { return (manaRegeneration + temporaryManaRegeneration); }
            private set { }
        }
        public int HitChance
        {
            get { return (hitChance + temporaryHitChance); }
            private set { }
        }

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

            temporaryArmor = 0;
            temporaryHitChance = 0;
            temporaryMagicAmplification = 0;
            temporaryManaRegeneration = 0;
            temporaryPhysicalDamageMax = 0;
            temporaryPhysicalDamageMin = 0;
            temporarySpeed = 0;

            action = -1;
            spellToCast = -1;

            spells = new List<Spell>();
            spells.Add(new SpellStab(this, null, TargetSpell.TargetTeam.Enemy));
            spells.Add(new SpellFireball(this, null, TargetSpell.TargetTeam.Enemy));
            spells.Add(new SpellThrowGoblin(this, null, TargetSpell.TargetTeam.Enemy));

            buffs = new List<Buff>();
            equippedItems = new List<Item>();

            drawOutline = false;
            outlineColor = Color.White;
        }

        public virtual Character Clone()
        {
            Character clone = new Character(texture, textureOutline, position, playerControlled, 
                name, health, speed, armor, physicalDamageMin, physicalDamageMax, magicAmplification, 
                mana, manaRegeneration, hitChance);
            return clone;
        }

        public void EquipItem(Item item)
        {
            item.OnEquip(this);
            equippedItems.Add(item);
        }

        public void UnequipItem(Item item)
        {
            item.OnUnequip(this);
            equippedItems.Remove(item);
        }

        public void OnNewTurn()
        {
            RegenerateMana();
            TickBuffs();
        }

        public void TickBuffs()
        {
            for (int i = buffs.Count()-1; i >= 0; i--)
            {
                buffs[i].OnTick();
                if (buffs[i].removable)
                {
                    buffs.RemoveAt(i);
                }
            }
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
