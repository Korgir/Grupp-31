using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Grupp_31_SystemUtveckling
{
    class InventorySystem
    {
        InventorySlot[,] invSlot;
        InventorySlot inPlayerHand;
        List<Item> inventory;
        Item itemInHand;
        bool ItemInHand;
        int xNumberOfSlots;
        int yNumberOfSlots;
        int totalInventorySlots;
        protected Vector2 position;

        public InventorySystem(Vector2 position)
        {
            this.position = position;
            xNumberOfSlots = 6;
            yNumberOfSlots = 11;
            totalInventorySlots = xNumberOfSlots * yNumberOfSlots;
            invSlot = new InventorySlot[xNumberOfSlots, yNumberOfSlots];
            inventory = new List<Item>();
            itemInHand = null;
            ItemInHand = false;
            CreateTestInventory();
            CreateTestItem();
            inPlayerHand = new InventorySlot(-1, -1, -1, -1);
        }
        void CreateTestInventory()
        {
            for (int i = 0; i < xNumberOfSlots; i++)
            {
                for (int j = 0; j < yNumberOfSlots; j++)
                {
                    invSlot[i, j] = new InventorySlot(i, j, (int)position.X + i * 64 + 32, (int)position.Y + j * 64 + 64);
                }
            }
        }
        void CreateTestItem()
        {
            Item redItem = (ItemDatabase.items[0]);
            bool breakOut = false;
            for (int i = 0; i < xNumberOfSlots; i++)
            {
                for (int j = 0; j < yNumberOfSlots; j++)
                {
                    if (invSlot[i, j].InventoryFull == false)
                    {
                        invSlot[i, j].Item = redItem;
                        invSlot[i, j].InventoryFull = true;
                        breakOut = true;
                        break;
                    }
                }
                if (breakOut == true) break;
            }

        }
        public void Update()
        {
            if (KeyMouseReader.KeyPressed(Keys.Space))
            {
                Item redItem = (ItemDatabase.items[1]); ;
                bool breakOut = false;
                for (int i = 0; i < xNumberOfSlots; i++)
                {
                    for (int j = 0; j < yNumberOfSlots; j++)
                    {
                        if (invSlot[i, j].InventoryFull == false)
                        {
                            invSlot[i, j].Item = redItem;
                            invSlot[i, j].InventoryFull = true;
                            breakOut = true;
                            break;
                        }
                    }
                    if (breakOut == true) break;
                }
            }
            if (KeyMouseReader.LeftClick())
            {
                if (ItemInHand != true)
                {
                    for (int i = 0; i < xNumberOfSlots; i++)
                    {
                        for (int j = 0; j < yNumberOfSlots; j++)
                        {
                            if (new Rectangle(invSlot[i, j].GraphicLocationX, invSlot[i, j].GraphicLocationY, 64, 64).Contains(KeyMouseReader.mouseState.Position))
                            {
                                if (invSlot[i, j].Item == null) break;
                                itemInHand = inPlayerHand.Item;
                                inPlayerHand.Item = invSlot[i, j].Item;
                                invSlot[i, j].Item = itemInHand;
                                ItemInHand = true;
                                if (invSlot[i, j].Item == null) invSlot[i, j].InventoryFull = false;
                                else invSlot[i, j].InventoryFull = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < xNumberOfSlots; i++)
                    {
                        for (int j = 0; j < yNumberOfSlots; j++)
                        {
                            if (new Rectangle(invSlot[i, j].GraphicLocationX, invSlot[i, j].GraphicLocationY, 64, 64).Contains(KeyMouseReader.mouseState.Position))
                            {
                                itemInHand = inPlayerHand.Item;
                                inPlayerHand.Item = invSlot[i, j].Item;
                                invSlot[i, j].Item = itemInHand;
                                if (inPlayerHand.Item == null)
                                {
                                    ItemInHand = false;
                                }
                                if (invSlot[i, j].Item == null) invSlot[i, j].InventoryFull = false;
                                else invSlot[i, j].InventoryFull = true;
                            }
                        }
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < xNumberOfSlots; x++)
            {
                for (int y = 0; y < yNumberOfSlots; y++)
                {
                    if (invSlot[x, y].Item != null)
                    {
                        spriteBatch.Draw(invSlot[x, y].Item.ItemTexture, new Rectangle(invSlot[x, y].GraphicLocationX, invSlot[x, y].GraphicLocationY, 64, 64), Color.White);
                    }

                }
            }
            if (ItemInHand == true)
            {
                spriteBatch.Draw(inPlayerHand.Item.ItemTexture, new Rectangle(KeyMouseReader.mouseState.Position.X - 32, KeyMouseReader.mouseState.Position.Y - 32, 64, 64), Color.White);
            }
        }
    }
}
