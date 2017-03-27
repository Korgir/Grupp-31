﻿using Microsoft.Xna.Framework;
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
        List<Character> char1;// Safe to remove. Only for testing purpose
        List<Character> char2;// Safe to remove. Only for testing purpose
        Combat combat;// Safe to remove. Only for testing purpose
        //Tile[,] tiles;
        List<string> strings = new List<string>();
        Texture2D tileTex;
        FileReader fileReader;
        Map map;
        String fileName;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            char1 = new List<Character>();// Safe to remove. Only for testing purpose
            char2 = new List<Character>();// Safe to remove. Only for testing purpose

            base.Initialize();
            tileTex = Archive.textureDictionary["Tile"];
            char1.Add(new Character(Archive.textureDictionary["warriorCombat"], new Vector2(50, 200), true, 100, 3, 5, 10, 10, 10, 100, 5, 100)); // Safe to remove. Only for testing purpose
            char2.Add(new Character(Archive.textureDictionary["owlbearCombat"], new Vector2(400, 200), false, 100, 3, 5, 10, 10, 10, 100, 5, 100)); // Safe to remove. Only for testing purpose
            combat = new Combat(char1, char2); // Safe to remove. Only for testing purpose
            fileReader = new FileReader(this, tileTex);
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

            map.Update(gameTime);            
            fileName = map.ZoneSwitch();
            if(fileName != null)
            {
                map = fileReader.ReadMapFile(fileName);
            }

            combat.Update(gameTime);// Safe to remove. Only for testing purpose

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            map.Draw(spriteBatch);

            map.Draw(spriteBatch);

            //combat.Draw(spriteBatch);// Safe to remove. Only for testing purpose

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}