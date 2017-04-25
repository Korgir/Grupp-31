﻿using Microsoft.Xna.Framework;
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
        Tile[,] tileArray;
        List<string> strings = new List<string>();
        Game1 game;
        //string fileName;
        Entity entity;
        Texture2D texPH;
        Vector2 posPH;
        Player player;
        Enemy enemy;

        public FileReader(Game1 game)
        {
            this.game = game;
            entity = new Entity(texPH, posPH);
        }

        //public Map ReadMapFile(string fileName)
        //{
        //    StreamReader streamReader = new StreamReader("Content\\Maps\\" + fileName + ".txt");            
        //    Map map = new Map();
        //    while (!streamReader.EndOfStream)
        //    {
        //        strings.Add(streamReader.ReadLine());
        //    }
        //    streamReader.Close();

        //    tileArray = new Tile[strings[0].Length, strings.Count];
        //    for (int i = 0; i < tileArray.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < tileArray.GetLength(1); j++)
        //        {
        //            if (strings[j][i] == 'w')
        //            {
        //                Texture2D tileTexture = Archive.textureDictionary["grass"];
        //                tileArray[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), false);
        //            }

        //            if (strings[j][i] == 'd')
        //            {
        //                Texture2D tileTexture = Archive.textureDictionary["tileDoor"];
        //                tileArray[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), false);
        //                int doorPosX = tileTexture.Width * i;
        //                int doorPosY = tileTexture.Height * j;
        //                map.SetDoorPostX(doorPosX);
        //                map.SetDoorPosY(doorPosY);
        //            }

        //            if (strings[j][i] == 'p')
        //            {
        //                Texture2D tileTexture = Archive.textureDictionary["grass"];
        //                player = new Player(Archive.textureDictionary["playerPlaceholder"], new Vector2(tileTexture.Width * i, tileTexture.Height * j));
        //                player.team.Add(new Character(Archive.textureDictionary["warriorCombat"], Archive.textureDictionary["warriorCombatOutline"],
        //                    Vector2.Zero, true, "Warrior", 100, 4, 4, 6, 15, 10, 100, 5, 70));
        //                tileArray[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), true);
        //                map.SetPlayer(player);
        //                player.SetMap(map);

        //            }

        //            if (strings[j][i] == 'e')
        //            {
        //                Texture2D tileTexture = Archive.textureDictionary["grass"];
        //                enemy = new Enemy(Archive.textureDictionary["playerPlaceholder"], new Vector2(tileTexture.Width * i, tileTexture.Height * j));
        //                enemy.team.Add(new Character(Archive.textureDictionary["owlbearCombat"], Archive.textureDictionary["owlbearCombatOutline"],
        //                    Vector2.Zero, false, "Owlbear", 100, 3, 5, 3, 12, 10, 100, 5, 80));
        //                tileArray[i, j] = new Tile(tileTexture, new Vector2(tileTexture.Width * i, tileTexture.Height * j), false);
        //                map.SetEnemy(enemy);
        //                enemy.SetMap(map);
        //            }
        //        }
        //    }

        //    map.SetTiles(tileArray);
        //    return map;
        //}

        public static Map ReadMap(string mapname)
        {
            StreamReader sr = new StreamReader(mapname);
            Map map = new Map();
            Tile[,] tileArray = new Tile[46, 26];

            while (!sr.EndOfStream)
            {
                string mapValue = sr.ReadLine();
                string[] stringArray = mapValue.Split(';');

                int xPos = Int32.Parse(stringArray[2]);
                int yPos = Int32.Parse(stringArray[3]);
                Texture2D Tex = Archive.textureDictionary[stringArray[1]];
                bool canWalk = bool.Parse(stringArray[4]);

                switch (stringArray[0])
                {
                    case "tile":
                        tileArray[xPos / 32, yPos / 32] = new Tile(Tex, new Vector2(xPos, yPos), canWalk);
                        break;
                    case "item":

                        break;

                    case "player":
                        tileArray[xPos / 32, yPos / 32] = new Tile(Tex, new Vector2(xPos, yPos), canWalk);
                        
                        map.player = new Player(Archive.textureDictionary["playerPlaceholder"], new Vector2(xPos, yPos));
                        map.player.team.Add(new Character(Archive.textureDictionary["warriorCombat"], Archive.textureDictionary["warriorCombatOutline"],
                            Vector2.Zero, true, "Warrior", 100, 4, 4, 6, 15, 10, 100, 5, 70));
                        //map.SetPlayer(player);
                        map.player.SetMap(map);
                        break;

                    case "enemy":
                        tileArray[xPos / 32 - 1, yPos / 32 - 1] = new Tile(Tex, new Vector2(xPos, yPos), canWalk);
                        Enemy enemy = new Enemy(Archive.textureDictionary["playerPlaceholder"], new Vector2(xPos, yPos));
                        enemy.team.Add(new Character(Archive.textureDictionary["owlbearCombat"], Archive.textureDictionary["owlbearCombatOutline"],
                            Vector2.Zero, false, "Owlbear", 100, 3, 5, 3, 12, 10, 100, 5, 80));
                        //map.SetPlayer(player);
                        map.enemyList.Add(enemy);
                        break;
                }

            }
            sr.Close();
            map.SetTiles(tileArray);
            return map;
        }


    }
}
