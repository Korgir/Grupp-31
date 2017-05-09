using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class ItemObjective : Objective
    {
        public int itemID;

        public ItemObjective(int goal, string description, int itemID)
            : base(goal, description)
        {
            this.itemID = itemID;
        }

        public void CompareItem(int itemID)
        {
            if (this.itemID == itemID)
            {
                progress++;
            }
        }
    }
}
