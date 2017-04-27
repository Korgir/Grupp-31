using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    class InventorySlot
    {
        private int gridNumberX;
        private int gridNumberY;
        private int graphicLocationX;
        private int graphicLocationY;
        private bool inventoryFull;
        private Item item;

        public InventorySlot(int gridNumberX, int gridNumberY, int graphicLocationX, int graphicLocationY)
        {
            this.gridNumberX = gridNumberX;
            this.gridNumberY = gridNumberY;
            this.graphicLocationX = graphicLocationX;
            this.graphicLocationY = graphicLocationY;
            item = null;
            inventoryFull = false;
        }
        public int GridNumberX
        {
            set { gridNumberX = value; }
            get { return gridNumberX; }
        }
        public int GridNumberY
        {
            set { gridNumberY = value; }
            get { return gridNumberY; }
        }
        public int GraphicLocationX
        {
            set { graphicLocationX = value; }
            get { return graphicLocationX; }
        }
        public int GraphicLocationY
        {
            set { graphicLocationY = value; }
            get { return graphicLocationY; }
        }
        public bool InventoryFull
        {
            set { inventoryFull = value; }
            get { return inventoryFull; }
        }
        public Item Item
        {
            set { item = value; }
            get { return item; }
        }
    }
}
