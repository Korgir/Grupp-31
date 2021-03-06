﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Quest
    {
        protected string title;
        public List<Objective> objectives;
        public Item reward;

        public int ID;

        public bool Completed
        {
            get
            {
                foreach (Objective o in objectives)
                {
                    if (!o.Completed)
                        return false;
                }

                return true;
            }
            private set { }
        }

        public float Height
        {
            get
            {
                float value = Archive.fontDictionary["questTitle"].MeasureString("I").Y;
                value += Archive.fontDictionary["objectiveDescription"].MeasureString("I").Y * objectives.Count();
                return value;
            }
            private set { }
        }

        public Quest(int ID, string title, Item reward)
        {
            this.ID = ID;
            this.title = title;
            this.reward = reward;
            
            objectives = new List<Objective>();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Color color = Color.Black;
            if (Completed)
            {
                color = Color.Yellow;
            }
            spriteBatch.DrawString(Archive.fontDictionary["questTitle"], title, position, color);
            for (int i = 0; i < objectives.Count(); i++)
            {
                Objective o = objectives[i];
                Vector2 newPosition = position;
                newPosition.Y += Archive.fontDictionary["questTitle"].MeasureString(title).Y + 
                    Archive.fontDictionary["objectiveDescription"].MeasureString(o.Description).Y * i;
                o.Draw(spriteBatch, newPosition);
            }
        }
    }
}
