using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Grupp_31_SystemUtveckling
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Character> char1;// Safe to remove. Only for testing purpose
        List<Character> char2;// Safe to remove. Only for testing purpose
        Combat combat;// Safe to remove. Only for testing purpose

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

            char1.Add(new Character(Archive.textureDictionary["warriorCombat"], new Vector2(50, 200), true, "Warrior", 100, 4, 4, 6, 15, 10, 100, 5, 70)); // Safe to remove. Only for testing purpose
            char2.Add(new Character(Archive.textureDictionary["owlbearCombat"], new Vector2(400, 200), false, "Owlbear", 100, 3, 5, 3, 12, 10, 100, 5, 80)); // Safe to remove. Only for testing purpose
            combat = new Combat(char1, char2); // Safe to remove. Only for testing purpose
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Archive.Initialize(Content);
        }
        
        protected override void Update(GameTime gameTime)
        {
            KeyMouseReader.Update();

            combat.Update(gameTime);// Safe to remove. Only for testing purpose

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            combat.Draw(spriteBatch);// Safe to remove. Only for testing purpose

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
