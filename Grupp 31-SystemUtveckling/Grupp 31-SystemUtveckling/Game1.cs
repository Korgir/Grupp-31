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
        Combat combat;
        Map map;
        MapEditor mapEditor;
        string fileName;

        public Game1()
        {
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
            Keybinds.Initialize();

            currentGameState = GameState.Menus;

            startMenu = new StartMenu(Archive.textureDictionary["menuBackground"], Archive.textureDictionary["menuHeader"], 
                Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], this, GraphicsDevice);
            
            combat = new Combat(new List<Character>(), new List<Character>(), -1);

            mapEditor = new MapEditor();
            fileName = "Content\\Maps\\StartMap.txt";
            map = FileReader.ReadMap(fileName);
        }

        protected override void LoadContent()
        {
            Archive.Initialize(Content);
            ItemDatabase.Initialize();
            CombatTeamDatabase.Initialize();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();
            
            if (KeyMouseReader.KeyPressed(Keybinds.binds["toggleFullscreen"]))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            switch (currentGameState)
            {
                case (GameState.Menus):
                    startMenu.Update();

                    if (KeyMouseReader.KeyPressed(Keybinds.binds["back"]))
                    {
                        this.Exit();
                    }
                    break;

                case (GameState.World):
                    map.Update(gameTime);
                    PortalEntity temporaryPortal = map.ZoneSwitch();
                    if (temporaryPortal != null)
                    {
                        fileName = temporaryPortal.zoneName;
                        Player tempPlayer = map.player;
                        TabManager tab = map.tabManager;
                        map = FileReader.ReadMap(fileName);
                        map.player = tempPlayer;
                        map.player.position = temporaryPortal.spawnPosition;
                        map.player.map = map;
                        map.tabManager = tab;
                    }

                    if (map.EngageCombatBool(ref combat) == true)
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
                    if (!combat.active && !combat.fadingOut)
                    {
                        currentGameState = GameState.World;
                        foreach (Quest q in map.tabManager.questTab.questSystem.quests)
                        {
                            foreach (Objective o in q.objectives)
                            {
                                if (o is KillObjective)
                                {
                                    KillObjective oKill = (KillObjective)o;
                                    oKill.CheckTeam(combat.enemyID);
                                }
                            }
                        }
                    }

                    if (KeyMouseReader.KeyPressed(Keybinds.binds["back"]))
                    {
                        this.Exit();
                    }
                    break;

                case (GameState.WorldEditor):
                    mapEditor.Update();

                    if (KeyMouseReader.KeyPressed(Keybinds.binds["back"]))
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

            spriteBatch.Begin(SpriteSortMode.Deferred);
            
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
