using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Dialog
    {
        SpriteFont font;
        List<string>[] dialogLines;
        int currentLine;
        bool finished;
        public Quest givingQuest;
        enum DialogState { Giving, InProgress, HandingIn }
        int dialogState;

        public Dialog()
        {
            font = Archive.fontDictionary["dialogFont"];
            dialogLines = new List<string>[3];
            for (int i = 0; i < 3; i++)
            {
                dialogLines[i] = new List<string>();
            }
            currentLine = 0;
            finished = false;
            givingQuest = null;
            dialogState = (int)DialogState.Giving;
        }

        public void AddLinePickupQuest(string text)
        {
            dialogLines[0].Add(text);
        }

        public void AddLineQuestInProgress(string text)
        {
            dialogLines[1].Add(text);
        }

        public void AddLineHandingInQuest(string text)
        {
            dialogLines[2].Add(text);
        }

        public void Update(Map map)
        {
            if (!map.tabManager.questTab.questSystem.HaveQuest(givingQuest))
            {
                dialogState = (int)DialogState.Giving;
            }
            else if (!map.tabManager.questTab.questSystem.TurnInQuest(givingQuest))
            {
                dialogState = (int)DialogState.InProgress;
            }
            else if (map.tabManager.questTab.questSystem.TurnInQuest(givingQuest))
            {
                dialogState = (int)DialogState.HandingIn;
            }

            if (KeyMouseReader.KeyPressed(Keybinds.binds["talk"]) && !finished)
            {
                currentLine++;
                if (currentLine >= dialogLines[dialogState].Count())
                {
                    currentLine = 0;
                    finished = true;
                    if (givingQuest != null)
                    {
                        map.tabManager.questTab.questSystem.AddQuest(givingQuest);
                        if (map.tabManager.questTab.questSystem.TurnInQuest(givingQuest))
                        {
                            if (map.tabManager.inventoryTab.inventorySystem.AddItem(givingQuest.reward))
                            {
                                map.tabManager.questTab.questSystem.RemoveQuest(givingQuest);
                            }
                        }
                    }
                }
            }
        }

        public void StopTalking()
        {
            currentLine = 0;
            finished = false;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            if (!finished)
            {
                spriteBatch.DrawString(font, dialogLines[dialogState][currentLine], position, Color.White, 0.0f,
                    font.MeasureString(dialogLines[dialogState][currentLine]) / 2, 1.0f, SpriteEffects.None, 0);
            }
        }
    }
}
