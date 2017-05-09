using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Objective
    {
        public int progress;
        public int goal;
        protected string description;

        public string Description
        {
            get { return (progress + "/" + goal + "  " + description); }
            set { description = value; }
        }

        public bool Completed
        {
            get
            {
                if (progress >= goal)
                    return true;
                return false;
            }
            private set { }
        }

        public Objective(int goal, string description)
        {
            progress = 0;
            this.goal = goal;
            this.description = description;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Color color = Color.Black;
            if (Completed)
            {
                color = Color.Yellow;
            }
            spriteBatch.DrawString(Archive.fontDictionary["objectiveDescription"], Description, position, color);
        }
    }
}
