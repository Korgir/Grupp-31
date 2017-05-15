using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class QuestSystem
    {
        public Vector2 position;
        public List<Quest> quests;

        public QuestSystem(Vector2 position)
        {
            this.position = position;
            quests = new List<Quest>();
        }

        public bool AddQuest(Quest quest)
        {
            foreach (Quest q in quests)
            {
                if (q.ID == quest.ID)
                    return false;
            }
            quests.Add(quest);
            return true;
        }

        public bool RemoveQuest(Quest quest)
        {
            foreach (Quest q in quests)
            {
                if (q.ID == quest.ID)
                {
                    quests.Remove(q);
                    return true;
                }
            }
            return false;
        }

        public bool TurnInQuest(Quest quest)
        {
            foreach (Quest q in quests)
            {
                if (q.ID == quest.ID && q.Completed)
                    return true;
            }
            return false;
        }

        public bool HaveQuest(Quest quest)
        {
            foreach (Quest q in quests)
            {
                if (q.ID == quest.ID)
                    return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 tempPosition = position;
            foreach (Quest q in quests)
            {
                q.Draw(spriteBatch, tempPosition);
                tempPosition.Y += q.Height;
            }
        }
    }
}
