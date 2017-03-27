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
        Game1 game;
        string fileName;

        public FileReader(Game1 game, Texture2D tileTex )
        {
            this.game = game;
            this.tileTex = tileTex;

        }


        public Map ReadMapFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName + ".txt");
            Player player;
            Map map = new Map();
            while (!sr.EndOfStream)
            {
                strings.Add(sr.ReadLine());
            }
            sr.Close();
            Tile[,] tiles = new Tile[strings[0].Length, strings.Count];
            for (int i = 0; i < tiles.GetLength(0); i++)
            {
                for (int j = 0; j < tiles.GetLength(1); j++)
                {
                    if (strings[j][i] == 'w')
                    {
                        tiles[i, j] = new Tile(tileTex, new Vector2(tileTex.Width * i, tileTex.Height * j), false);
                    }
                   

                    if (strings[j][i] == 'd')
                    {
                        tiles[i, j] = new Tile(tileTex, new Vector2(tileTex.Width * i, tileTex.Height * j), false);
                        int doorPosX = tileTex.Width * i;
                        int doorPosY = tileTex.Height * j;
                        map.setDoorPostX(doorPosX);
                        map.setDoorPosY(doorPosY);
                        
                    }

                    if (strings[j][i] == 'p')
                    {
                        player = new Player(Archive.textureDictionary["PlayerPlaceholder"], new Vector2(tileTex.Width * i, tileTex.Height * j));
                        tiles[i, j] = new Tile(tileTex, new Vector2(tileTex.Width * i, tileTex.Height * j), true);
                        map.setPlayer(player);
                        player.setMap(map);

                    }
                    
                }
            }
            map.SetTiles(tiles);
            return map;
        }


        

        

        
    }
}
