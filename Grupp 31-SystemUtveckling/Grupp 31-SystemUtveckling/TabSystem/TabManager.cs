using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class TabManager
    {
        Button characterButton;
        Button inventoryButton;
        Button questLogButton;
        public CharacterTab characterTab;
        public InventoryTab inventoryTab;
        QuestTab questTab;


        enum TabState { CharacterTab, InventoryTab, QuestLogTab };
        TabState tabState;

        public TabManager()
        {
            Vector2 position = new Vector2(1472, 0);
            characterTab = new CharacterTab(position, this);
            inventoryTab = new InventoryTab(position, this);
            questTab = new QuestTab(position);
            tabState = TabState.CharacterTab;
            characterButton = new Button(new Rectangle((int)position.X + 32, (int)position.Y + 896, 96, 128), Archive.textureDictionary["whitePixel"], Archive.fontDictionary["defaultFont"], "", Keybinds.binds["characterTab"]);
            inventoryButton = new Button(new Rectangle((int)position.X + 128, (int)position.Y + 896, 96, 128), Archive.textureDictionary["whitePixel"], Archive.fontDictionary["defaultFont"], "", Keybinds.binds["inventoryTab"]);
            questLogButton =  new Button(new Rectangle((int)position.X + 224, (int)position.Y + 896, 96, 128), Archive.textureDictionary["whitePixel"], Archive.fontDictionary["defaultFont"], "", Keybinds.binds["questTab"]);
            
        }
        public void Update(GameTime gameTime)
        {
            switch (tabState)
            {
                case (TabState.CharacterTab):
                    characterTab.Update(gameTime);
                    if (inventoryButton.IsClicked())
                    {
                        tabState = TabState.InventoryTab;
                    }
                    if (questLogButton.IsClicked())
                    {
                        tabState = TabState.QuestLogTab;
                    }
                    break;
                case (TabState.InventoryTab):
                    inventoryTab.Update(gameTime);
                    if (questLogButton.IsClicked())
                    {
                        tabState = TabState.QuestLogTab;
                    }
                    if (characterButton.IsClicked())
                    {
                        tabState = TabState.CharacterTab;
                    }
                    break;
                case (TabState.QuestLogTab):
                    questTab.Update(gameTime);
                    if (inventoryButton.IsClicked())
                    {
                        tabState = TabState.InventoryTab;
                    }
                    if (characterButton.IsClicked())
                    {
                        tabState = TabState.CharacterTab;
                    }
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (tabState)
            {
                case (TabState.CharacterTab):
                    characterTab.Draw(spriteBatch);
                    break;
                case (TabState.InventoryTab):
                    inventoryTab.Draw(spriteBatch);
                    break;
                case (TabState.QuestLogTab):
                    questTab.Draw(spriteBatch);
                    break;
            }
        }
    }
}
