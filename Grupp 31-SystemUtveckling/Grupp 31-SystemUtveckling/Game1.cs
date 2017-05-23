using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
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
                Archive.textureDictionary["button"], Archive.fontDictionary["buttonFont"], this, GraphicsDevice);
            
            combat = new Combat(new List<Character>(), new List<Character>(), -1);

            mapEditor = new MapEditor();
            fileName = "Content\\Maps\\x1y5_StartMap.txt";
            map = FileReader.ReadMap(fileName);

            MediaPlayer.Stop();
            MediaPlayer.IsRepeating = true;
        }

        protected override void LoadContent()
        {
            Archive.Initialize(Content);
            ItemDatabase.Initialize();
            DialogDictionary.Initialize();
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

                    string previousZoneName = map.zoneName;
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

                        if (map.zoneName != previousZoneName)
                        {
                            MediaPlayer.Play(Archive.songDictionary[map.zoneName]);
                        }
                    }

                    if (map.EngageCombatBool(ref combat) == true)
                    {
                        currentGameState = GameState.Combat;
                    }

                    if (KeyMouseReader.KeyPressed(Keys.Escape))
                    {
                        currentGameState = GameState.Menus;
                        MediaPlayer.Stop();
                    }
                    break;

                case (GameState.Combat):
                    combat.Update(gameTime);
                    if (!combat.active && !combat.fadingOut)
                    {
                        MediaPlayer.Play(Archive.songDictionary[map.zoneName]);
                        currentGameState = GameState.World;
                        foreach (Quest q in map.tabManager.questTab.questSystem.quests)
                        {
                            foreach (Objective o in q.objectives)
                            {
                                if (o is KillObjective)
                                {
                                    KillObjective oKill = (KillObjective)o;
                                    oKill.CompareTeam(combat.enemyID);
                                }
                            }
                        }

                        if (combat.winnerTeam == 2)
                        {
                            Initialize();
                        }
                        else
                        {
                            map.player.team.characters[0].Heal((int)(map.player.team.characters[0].maxHealth * 0.2f));
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
