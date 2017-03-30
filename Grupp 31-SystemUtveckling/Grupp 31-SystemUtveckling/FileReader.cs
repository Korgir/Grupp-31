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
        Game1 game;
        string fileName;

        public FileReader(Game1 game)
        {
            this.game = game;
        }

        public Map ReadMapFile(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName + ".txt");
            Player player;
            Map map = new Map();
            while (!streamReader.EndOfStream)
            {
                strings.Add(streamReader.ReadLine());
            }
            streamReader.Close();

            tiles = new Tile[strings[0].Length, strings.Count];
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (strings[j][i] == 'w')
                    {
                        Texture2D tileTexture = Archive.textureDictionary["tile"];
                        tiles[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), false);
                    }

                    if (strings[j][i] == 'd')
                    {
                        Texture2D tileTexture = Archive.textureDictionary["tileDoor"];
                        tiles[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), false);
                        int doorPosX = tileTexture.Width * i;
                        int doorPosY = tileTexture.Height * j;
                        map.setDoorPostX(doorPosX);
                        map.setDoorPosY(doorPosY);
                    }

                    if (strings[j][i] == 'p')
                    {
                        Texture2D tileTexture = Archive.textureDictionary["tile"];
                        player = new Player(Archive.textureDictionary["playerPlaceholder"], new Vector2(tileTexture.Width * i, tileTexture.Height * j));
                        tiles[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), true);
                        map.setPlayer(player);
                        player.SetMap(map);

                    }
                }
            }

            map.SetTiles(tiles);
            return map;
        }
    }
}
