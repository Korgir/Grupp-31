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
        public enum GameState { Menus = 0, World = 1, Combat = 2, WorldEditor = 3};

        public GameState currentGameState;
        StartMenu startMenu;
        List<Character> char1;// Safe to remove. Only for testing purpose
        List<Character> char2;// Safe to remove. Only for testing purpose
        Combat combat;// Safe to remove. Only for testing purpose
        List<string> strings = new List<string>();
        FileReader fileReader;
        Map map;
        MapEditor mapEditor;
        string fileName;

        public Game1()
        {
            Console.WriteLine("con");
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }
        
        protected override void Initialize()
        {
            Console.WriteLine("init");
            Archive.Initialize(Content);
            currentGameState = GameState.Combat;

            startMenu = new StartMenu(Archive.textureDictionary["menuBackground"], Archive.textureDictionary["menuHeader"], 
                Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], this, GraphicsDevice);
            char1 = new List<Character>(); // Safe to remove. Only for testing purpose
            char2 = new List<Character>(); // Safe to remove. Only for testing purpose
            mapEditor = new MapEditor();
            base.Initialize();
            char1.Add(new Character(Archive.textureDictionary["warriorCombat"], Archive.textureDictionary["warriorCombatOutline"], 
                Vector2.Zero, true, "Warrior", 100, 4, 4, 6, 15, 10, 100, 5, 70)); // Safe to remove. Only for testing purpose
            for (int i = 3; i > 0; i--)
            {
                char2.Add(new Character(Archive.textureDictionary["owlbearCombat"], Archive.textureDictionary["owlbearCombatOutline"],
                    Vector2.Zero, false, "Owlbear", 100, 3, 5, 3, 12, 10, 100, 5, 80)); // Safe to remove. Only for testing purpose
            }
            combat = new Combat(char1, char2); // Safe to remove. Only for testing purpose
            fileReader = new FileReader(this);
            fileName = "map";
            map = fileReader.ReadMapFile(fileName);
        }

        protected override void LoadContent()
        {
            Console.WriteLine("load");
            

            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            if (KeyMouseReader.KeyPressed(Keys.Escape))
            {
                this.Exit();
            }
            if (KeyMouseReader.KeyPressed(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            switch (currentGameState)
            {
                case (GameState.Menus):
                    startMenu.Update();
                    break;

                case (GameState.World):
                    map.Update(gameTime);
                    fileName = map.ZoneSwitch();
                    if (fileName != null)
                    {
                        map = fileReader.ReadMapFile(fileName);                     
                    }

                    if (fileReader.EngageCombatBool() == true)
                    {
                        currentGameState = GameState.Combat;
                    }
                    break;

                case (GameState.Combat):
                    combat.Update(gameTime);// Safe to remove. Only for testing purpose
                    break;

                case (GameState.WorldEditor):
                    mapEditor.Update();
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
                    startMenu.Draw(spriteBatch);
                    break;

                case (GameState.World):
                    map.Draw(spriteBatch);
                    break;

                case (GameState.Combat):
                    combat.Draw(spriteBatch);// Safe to remove. Only for testing purpose
                    break;

                case (GameState.WorldEditor):
                    mapEditor.Draw(spriteBatch);
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
