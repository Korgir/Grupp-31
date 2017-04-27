using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemPrototyp
{
    class TabManager
    {
        Rectangle characterButton;
        Rectangle inventoryButton;
        Rectangle questLogButton;
        CharacterTab charTab;
        InventoryTab invTab;
        QuestTab qlogTab;


        enum TabState { CharacterTab, InventoryTab, QuestLogTab };
        TabState tabState;

        public TabManager()
        {
            charTab = new CharacterTab();
            invTab = new InventoryTab();
            qlogTab = new QuestTab();
            tabState = TabState.CharacterTab;
            inventoryButton = new Rectangle(128, 896, 96, 128);
            characterButton = new Rectangle(32, 896, 96, 128);
            questLogButton = new Rectangle(224, 896, 96, 128);
            
        }
        public void Update(GameTime gameTime)
        {
            switch (tabState)
            {
                case (TabState.CharacterTab):
                    charTab.Update(gameTime);
                    if (KeyMouseReader.LeftClick())
                    {
                        if (inventoryButton.Contains(new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y)))
                        {
                            tabState = TabState.InventoryTab;
                        }
                        if (questLogButton.Contains(new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y)))
                        {
                            tabState = TabState.QuestLogTab;
                        }
                    }
                    break;
                case (TabState.InventoryTab):
                    invTab.Update(gameTime);
                    if (KeyMouseReader.LeftClick())
                    {
                        if (questLogButton.Contains(new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y)))
                        {
                            tabState = TabState.QuestLogTab;
                        }
                        if (characterButton.Contains(new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y)))
                        {
                            tabState = TabState.CharacterTab;
                        }
                    }
                    break;
                case (TabState.QuestLogTab):
                    qlogTab.Update(gameTime);
                    if (KeyMouseReader.LeftClick())
                    {
                        if (inventoryButton.Contains(new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y)))
                        {
                            tabState = TabState.InventoryTab;
                        }
                        if (characterButton.Contains(new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y)))
                        {
                            tabState = TabState.CharacterTab;
                        }
                    }
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (tabState)
            {
                case (TabState.CharacterTab):
                    charTab.Draw(spriteBatch);
                    break;
                case (TabState.InventoryTab):
                    invTab.Draw(spriteBatch);
                    break;
                case (TabState.QuestLogTab):
                    qlogTab.Draw(spriteBatch);
                    break;
            }
        }
    }
}
