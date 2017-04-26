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
    static class FileReader
    {
        public static Map ReadMap(string mapname)
        {
            List<string> strings = new List<string>();
            StreamReader streamReader = new StreamReader(mapname);
            Map map = new Map();
            Tile[,] mapGrid = new Tile[46, 26];

            while (!streamReader.EndOfStream)
            {
                string mapValue = streamReader.ReadLine();
                string[] stringArray = mapValue.Split(';');

                int xPosition = Int32.Parse(stringArray[2]);
                int yPosition = Int32.Parse(stringArray[3]);
                Texture2D texture = Archive.textureDictionary[stringArray[1]];

                switch (stringArray[0])
                {
                    case "tile":
                        bool isWallTile = bool.Parse(stringArray[4]);
                        mapGrid[xPosition / 32, yPosition / 32] = new Tile(texture, new Vector2(xPosition, yPosition), isWallTile);
                        break;
                    case "item":

                        break;

                    case "player":
                        map.player = new Player(texture, new Vector2(xPosition, yPosition));
                        map.player.team.Add(new Character(Archive.textureDictionary["warriorCombat"], Archive.textureDictionary["warriorCombatOutline"],
                            Vector2.Zero, true, "Warrior", 100, 4, 4, 6, 15, 10, 100, 5, 70));
                        map.player.map = map;
                        break;

                    case "enemy":
                        Enemy enemy = new Enemy(texture, new Vector2(xPosition, yPosition));
                        // Add enemy team based on stringArray[4] value ex. (stringArray[4] == "goblins")
                        for (int i = 0; i < 5; i++)
                        {
                            enemy.team.Add(new Character(Archive.textureDictionary["goblinCombat"], Archive.textureDictionary["goblinCombatOutline"],
                            Vector2.Zero, false, "Goblin", 30, 3, 2, 3, 5, 10, 100, 5, 50));
                        }
                        map.enemyList.Add(enemy);
                        break;
                }
            }
            streamReader.Close();
            map.SetTiles(mapGrid);
            return map;
        }

        public static void WriteMap(string mapname, Tile[,] tileArray, Entity[,] entityArray)
        {
            using (StreamWriter sw = File.CreateText(mapname))
            {
                for (int i = 0; i < tileArray.GetLength(0); i++)
                {
                    for (int j = 0; j < tileArray.GetLength(1); j++)
                    {
                        var textureArchiveName = Archive.textureDictionary.FirstOrDefault(x => x.Value == tileArray[i, j].texture).Key;
                        sw.WriteLine("tile;" + textureArchiveName + ";" + tileArray[i, j].position.X + ";" + tileArray[i, j].position.Y + ";" + tileArray[i, j].Wall);
                    }
                }
                for (int i = 0; i < entityArray.GetLength(0); i++)
                {
                    for (int j = 0; j < entityArray.GetLength(1); j++)
                    {
                        if (entityArray[i, j] != null)
                        {
                            var textureArchiveName = Archive.textureDictionary.FirstOrDefault(x => x.Value == entityArray[i, j].texture).Key;
                            if (textureArchiveName == "playerPlaceholder")
                            {
                                sw.WriteLine("player;" + textureArchiveName + ";" + entityArray[i, j].position.X + ";" + entityArray[i, j].position.Y);
                            }
                            else
                            {
                                sw.WriteLine("enemy;" + textureArchiveName + ";" + entityArray[i, j].position.X + ";" + entityArray[i, j].position.Y);
                            }
                        }
                    }
                }
            }
        }
    }
}
