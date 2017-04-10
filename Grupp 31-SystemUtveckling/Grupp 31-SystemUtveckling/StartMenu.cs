using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class StartMenu
    {
        protected Texture2D backgroundTexture;
        protected Texture2D headerTexture;
        protected Texture2D buttonTexture;
        protected Vector2 headerPosition;
        protected SpriteFont font;
        protected List<Button> buttonList;
        protected Game1 game;
        protected int buttonWidth;
        protected int buttonHeight;

        public StartMenu(Texture2D backgroundTexture, Texture2D headerTexture, Texture2D buttonTexture, 
            SpriteFont font, Game1 game, GraphicsDevice graphicsDevice)
        {
            this.backgroundTexture = backgroundTexture;
            this.headerTexture = headerTexture;
            this.buttonTexture = buttonTexture;
            this.font = font;
            this.game = game;
            buttonWidth = 350;
            buttonHeight = 75;
            headerPosition = new Vector2(graphicsDevice.Viewport.Width / 2 - (headerTexture.Width / 2), 300);
            buttonList = new List<Button>();
            buttonList.Add(new Button(new Rectangle(graphicsDevice.Viewport.Width / 2 - (buttonWidth / 2), 350, 
                buttonWidth, buttonHeight), buttonTexture, font, "Play"));
            buttonList.Add(new Button(new Rectangle(graphicsDevice.Viewport.Width / 2 - (buttonWidth / 2), 450,
                buttonWidth, buttonHeight), buttonTexture, font, "Editor"));
            buttonList.Add(new Button(new Rectangle(graphicsDevice.Viewport.Width / 2 - (buttonWidth / 2), 550,
                buttonWidth, buttonHeight), buttonTexture, font, "Quit"));
        }

        public void Update()
        {
            if (buttonList[0].IsClicked())
            {
                game.currentGameState = Game1.GameState.World;
            }
            if (buttonList[1].IsClicked())
            {
                game.currentGameState = Game1.GameState.WorldEditor;
            }
            if (buttonList[2].IsClicked())
            {
                game.Exit();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
            spriteBatch.Draw(headerTexture, headerPosition, Color.White);
            foreach(Button b in buttonList)
            {
                b.Draw(spriteBatch);
            }
        }
    }
}
