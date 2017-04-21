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
        //List<Character> char1;// Safe to remove. Only for testing purpose
        //List<Character> char2;// Safe to remove. Only for testing purpose
        Combat combat;
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
            base.Initialize();
            Console.WriteLine("init");
            
            currentGameState = GameState.Menus;

            startMenu = new StartMenu(Archive.textureDictionary["menuBackground"], Archive.textureDictionary["menuHeader"], 
                Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], this, GraphicsDevice);

            combat = new Combat(new List<Character>(), new List<Character>());

            mapEditor = new MapEditor();
            fileReader = new FileReader(this);
            fileName = "map";
            map = fileReader.ReadMapFile(fileName);
        }

        protected override void LoadContent()
        {
            Console.WriteLine("load");
            Archive.Initialize(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            
            if (KeyMouseReader.KeyPressed(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            switch (currentGameState)
            {
                case (GameState.Menus):
                    startMenu.Update();

                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        this.Exit();
                    }
                    break;

                case (GameState.World):
                    map.Update(gameTime);
                    fileName = map.ZoneSwitch();
                    if (fileName != null)
                    {
                        map = fileReader.ReadMapFile(fileName);                     
                    }

                    if (fileReader.EngageCombatBool(ref combat) == true)
                    {
                        currentGameState = GameState.Combat;
                    }

                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        currentGameState = GameState.Menus;
                    }
                    break;

                case (GameState.Combat):
                    combat.Update(gameTime);
                    if (!combat.active)
                    {
                        currentGameState = GameState.World;
                    }

                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        this.Exit();
                    }
                    break;

                case (GameState.WorldEditor):
                    mapEditor.Update();

                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        currentGameState = GameState.Menus;
                    }
                    break;
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

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
                    combat.Draw(spriteBatch);
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
