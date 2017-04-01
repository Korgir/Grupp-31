using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;

namespace Grupp_31_SystemUtveckling
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum GameState { Menus = 0, World = 1, Combat = 2 };

        GameState currentGameState;
        List<Character> char1;// Safe to remove. Only for testing purpose
        List<Character> char2;// Safe to remove. Only for testing purpose
        Combat combat;// Safe to remove. Only for testing purpose
        List<string> strings = new List<string>();
        FileReader fileReader;
        Map map;
        string fileName;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }
        
        protected override void Initialize()
        {
            currentGameState = GameState.Combat;

            char1 = new List<Character>();// Safe to remove. Only for testing purpose
            char2 = new List<Character>();// Safe to remove. Only for testing purpose

            base.Initialize();
            char1.Add(new Character(Archive.textureDictionary["warriorCombat"], new Vector2(500, 500), 
                true, "Warrior", 100, 4, 4, 6, 15, 10, 100, 5, 70)); // Safe to remove. Only for testing purpose
            char2.Add(new Character(Archive.textureDictionary["owlbearCombat"], new Vector2(1420, 400),
                false, "Owlbear", 100, 3, 5, 3, 12, 10, 100, 5, 80)); // Safe to remove. Only for testing purpose
            char2.Add(new Character(Archive.textureDictionary["owlbearCombat"], new Vector2(1470, 600),
                false, "Owlbear", 100, 3, 5, 3, 12, 10, 100, 5, 80)); // Safe to remove. Only for testing purpose
            combat = new Combat(char1, char2); // Safe to remove. Only for testing purpose
            fileReader = new FileReader(this);
            fileName = "map";
            map = fileReader.ReadMapFile(fileName);
        }

        protected override void LoadContent()
        {
            Archive.Initialize(Content);

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            if (KeyMouseReader.KeyPressed(Keys.Escape))
            {
                this.Exit();
            }

            switch (currentGameState)
            {
                case (GameState.Menus):
                    break;

                case (GameState.World):
                    map.Update(gameTime);
                    fileName = map.ZoneSwitch();
                    if (fileName != null)
                    {
                        map = fileReader.ReadMapFile(fileName);
                    }
                    break;

                case (GameState.Combat):
                    combat.Update(gameTime);// Safe to remove. Only for testing purpose
                    break;
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            
            switch (currentGameState)
            {
                case (GameState.Menus):
                    break;

                case (GameState.World):
                    map.Draw(spriteBatch);
                    break;

                case (GameState.Combat):
                    combat.Draw(spriteBatch);// Safe to remove. Only for testing purpose
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
