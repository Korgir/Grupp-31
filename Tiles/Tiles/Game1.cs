using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.IO;

namespace Tiles
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D wallTileTex;
        Texture2D floorTileTex;
        Texture2D ballTex;
        Texture2D playerTexture;
        Tile[,] tiles;
        Ball ball;
        List<string> strings = new List<string>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            IsMouseVisible = true;
            wallTileTex = Content.Load<Texture2D>("walltile");
            floorTileTex = Content.Load<Texture2D>("floortile");
            ballTex = Content.Load<Texture2D>("ball");
            playerTexture = Content.Load<Texture2D>("CharacterSpriteSheet");
            

            StreamReader sr = new StreamReader("map.txt");
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();
            tiles = new Tile[strings[0].Length, strings.Count];
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (strings[j][i] == 'w')
                    {
                        tiles[i, j] = new Tile(wallTileTex, new Vector2(wallTileTex.Width * i, wallTileTex.Height * j), true);
                    }
                    if (strings[j][i] == '-')
                    {
                        tiles[i, j] = new Tile(floorTileTex, new Vector2(floorTileTex.Width * i, floorTileTex.Height * j), false);
                    }
                    else if (strings[j][i] == 'b')
                    {
                        tiles[i, j] = new Tile(floorTileTex, new Vector2(floorTileTex.Width * i, floorTileTex.Height * j), false);
                        ball = new Ball(playerTexture, new Vector2(floorTileTex.Width * i, floorTileTex.Height * j), this);
                    }
                }
            }
        }


        public Tile GetTileAtPosition(Vector2 vec)
        {
            return tiles[(int)vec.X / 50, (int)vec.Y / 50];
        }


        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            ball.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            foreach (Tile t in tiles)
            {
                t.Draw(spriteBatch);
            }
            spriteBatch.Draw(playerTexture, new Vector2(150, 150), new Rectangle(32, 0, 32, 32), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
