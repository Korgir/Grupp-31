using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class FileReader
    {
        Tile[,] tiles;
        List<string> strings = new List<string>();
        Texture2D tileTex;
        Player player;
        Game1 game;
        int playerPosX;
        int playerPosY;
        int doorPosX;
        int doorPosY;
        string fileName;

        public FileReader(Game1 game, Player player, Texture2D tileTex, string fileName)
        {
            this.game = game;
            this.player = player;
            this.tileTex = tileTex;
            this.fileName = fileName;

        }


        public void ReadMapFile()
        {
            StreamReader sr = new StreamReader(fileName + ".txt");
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
                        tiles[i, j] = new Tile(tileTex, new Vector2(tileTex.Width * i, tileTex.Height * j), false);
                    }

                    if (strings[j][i] == 'p')
                    {
                        //player = new Player(Archive.textureDictionary["warriorCombat"], new Vector2(tileTex.Width * i, tileTex.Height * j), game);
                        tiles[i, j] = new Tile(tileTex, new Vector2(tileTex.Width * i, tileTex.Height * j), true);
                        playerPosX = tileTex.Width * i;
                        playerPosY = tileTex.Height * j;
                    }

                    if (strings[j][i] == 'd')
                    {
                        tiles[i, j] = new Tile(tileTex, new Vector2(tileTex.Width * i, tileTex.Height * j), false);
                        doorPosX = tileTex.Width * i;
                        doorPosY = tileTex.Height * j;
                    }
                }
            }
        }

        public void ZoneSwitch()
        {
            if(doorPosX == player.pos.X & doorPosY == player.pos.Y)
            {
                //fileName = ("map2");
                Console.WriteLine("zone switch");
            }
        }
            

        public int getPlayerPosX()
        {
            return playerPosX;
        }

        public int getPlayerPosY()
        {
            return playerPosY;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile t in tiles)
            {
                t.Draw(spriteBatch);
            }
        }

        public Tile GetTileAtPosition(Vector2 vec)
        {
            return tiles[(int)vec.X / 50, (int)vec.Y / 50];
        }
    }
}
