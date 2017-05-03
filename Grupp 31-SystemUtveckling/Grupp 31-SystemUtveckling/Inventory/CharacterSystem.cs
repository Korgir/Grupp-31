using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class CharacterSystem
    {
        InventorySlot[] equipmentSlots;
        Vector2 position;
        TabManager tabManager;

        public CharacterSystem(Vector2 position, TabManager tabManager)
        {
            this.position = position;
            this.tabManager = tabManager;
            equipmentSlots = new InventorySlot[9];
            equipmentSlots[0] = new InventorySlot(0, 0, (int)position.X + 191, (int)position.Y + 384); // Head
            equipmentSlots[1] = new InventorySlot(0, 0, (int)position.X + 191, (int)position.Y + 480); // Chest
            equipmentSlots[2] = new InventorySlot(0, 0, (int)position.X + 191, (int)position.Y + 576); // Legs
            equipmentSlots[3] = new InventorySlot(0, 0, (int)position.X + 191, (int)position.Y + 672); // Feet
            equipmentSlots[4] = new InventorySlot(0, 0, (int)position.X + 287, (int)position.Y + 416); // Neck
            equipmentSlots[5] = new InventorySlot(0, 0, (int)position.X + 287, (int)position.Y + 512); // Finger
            equipmentSlots[6] = new InventorySlot(0, 0, (int)position.X + 95, (int)position.Y + 512); // Hands
            equipmentSlots[7] = new InventorySlot(0, 0, (int)position.X + 95, (int)position.Y + 608); // Main Hand
            equipmentSlots[8] = new InventorySlot(0, 0, (int)position.X + 287, (int)position.Y + 608); // Off Hand
        }

        public bool TryEquip(Item item)
        {
            if ((int)item.itemType < 10)
            {
                if (!equipmentSlots[(int)item.itemType].InventoryFull)
                {
                    equipmentSlots[(int)item.itemType].Item = item;
                    equipmentSlots[(int)item.itemType].InventoryFull = true;
                    return true;
                }
            }
            return false;
        }

        public void Update(GameTime gameTime)
        {
            if (KeyMouseReader.RightClick())
            {
                for (int i = 0; i < equipmentSlots.Count(); i++)
                {
                    if (new Rectangle(equipmentSlots[i].GraphicLocationX, equipmentSlots[i].GraphicLocationY, 64, 64).Contains(KeyMouseReader.mouseState.Position))
                    {
                        if (equipmentSlots[i].Item == null) break;
                        if (tabManager.inventoryTab.inventorySystem.AddItem(equipmentSlots[i].Item))
                        {
                            equipmentSlots[i].Item = null;
                            equipmentSlots[i].InventoryFull = false;
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < equipmentSlots.Count(); i++)
            {
                if (equipmentSlots[i].Item != null)
                {
                    InventorySlot e = equipmentSlots[i];
                    spriteBatch.Draw(e.Item.ItemTexture, new Vector2(e.GraphicLocationX, e.GraphicLocationY), Color.White);
                }
            }
        }
    }
}
