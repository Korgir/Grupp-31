using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Grupp_31_SystemUtveckling
{
    class MapEditor
    {
        Tile[,] tileArray;
        int selectedTileType;

        List<Button> buttonList;
        List<Tile> floorTiles;
        List<Tile> wallTiles;

        int tileSize;
        Vector2 tileStartPosition;
        Vector2 tileGridOffset;
        Texture2D selectedTexture;

        bool showGrid;

        public MapEditor()
        {
            selectedTileType = 0;
            tileArray = new Tile[46, 26];
            tileSize = 32;
            tileStartPosition = new Vector2(32, 944);
            tileGridOffset = new Vector2(32, 32);
            buttonList = new List<Button>();
            buttonList.Add(new Button(new Rectangle(1512, 50, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Floor"));
            buttonList.Add(new Button(new Rectangle(1512, 100, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Wall"));
            buttonList.Add(new Button(new Rectangle(1512, 150, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Entity"));
            buttonList.Add(new Button(new Rectangle(1512, 200, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Item"));
            buttonList.Add(new Button(new Rectangle(1662, 50, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Save map"));
            buttonList.Add(new Button(new Rectangle(1662, 100, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Load map"));
            buttonList.Add(new Button(new Rectangle(1512, 300, 256, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Toggle grid"));


            floorTiles = new List<Tile>();
            AddFloorTile(Archive.textureDictionary["grass"]);
            AddFloorTile(Archive.textureDictionary["road"]);
            AddFloorTile(Archive.textureDictionary["plank"]);
            AddFloorTile(Archive.textureDictionary["dungeonFloor1"]);
            AddFloorTile(Archive.textureDictionary["dungeonFloor2"]);
            AddFloorTile(Archive.textureDictionary["dungeonFloor3"]);
            AddFloorTile(Archive.textureDictionary["dungeonFloor4"]);
            AddFloorTile(Archive.textureDictionary["dungeonFloor5"]);
            AddFloorTile(Archive.textureDictionary["dungeonFloor6"]);
            wallTiles = new List<Tile>();
            AddWallTile(Archive.textureDictionary["dungeonWall1"]);
            AddWallTile(Archive.textureDictionary["dungeonWall2"]);
            AddWallTile(Archive.textureDictionary["dungeonWall3"]);
            AddWallTile(Archive.textureDictionary["dungeonWall4"]);
            AddWallTile(Archive.textureDictionary["dungeonWall5"]);
            AddWallTile(Archive.textureDictionary["dungeonWall6"]);
            selectedTexture = floorTiles[0].texture;

            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    tileArray[i, j] = new Tile(floorTiles[0].texture, new Vector2(i * tileSize + tileGridOffset.X, j * tileSize + tileGridOffset.Y), false);
                }
            }

            showGrid = true;
        }

        public void AddFloorTile(Texture2D tileTexture)
        {
            Vector2 position = tileStartPosition + new Vector2(40, 0) * floorTiles.Count();
            floorTiles.Add(new Tile(tileTexture, position, false));
        }

        public void AddWallTile(Texture2D tileTexture)
        {
            Vector2 position = tileStartPosition + new Vector2(40, 0) * wallTiles.Count();
            wallTiles.Add(new Tile(tileTexture, position, false));
        }

        public void SaveMap(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < tileArray.GetLength(0); i++)
                {
                    //antal element i andra dimensionen
                    for (int j = 0; j < tileArray.GetLength(1); j++)
                    {
                        //wall är enbart true atm måste fixas!
                        sw.WriteLine("tile;" + tileArray[i, j].texture + ";" + tileArray[i, j].position.X + ";" + tileArray[i, j].position.Y + ";" + tileArray[i, j].Wall);
                    }
                }
            }
        }

        public void LoadMap(string path)
        {
        }

        public void Update()
        {
            if (buttonList[0].IsClicked())
            {
                selectedTileType = 0;
                selectedTexture = floorTiles[0].texture;
            }
            if (buttonList[1].IsClicked())
            {
                selectedTileType = 1;
                selectedTexture = wallTiles[0].texture;
            }
            if (buttonList[2].IsClicked())
            {
                System.Windows.Forms.MessageBox.Show("Not implemented.");
            }
            if (buttonList[3].IsClicked())
            {
                System.Windows.Forms.MessageBox.Show("Not implemented.");
            }
            if (buttonList[4].IsClicked())
            {
                System.Windows.Forms.SaveFileDialog fileDialog = new System.Windows.Forms.SaveFileDialog();
                fileDialog.Filter = "Text Files|*.txt";
                fileDialog.RestoreDirectory = true;
                fileDialog.Title = "Select a level";
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SaveMap(fileDialog.FileName);
                }
            }

            if (buttonList[5].IsClicked())
            {
                System.Windows.Forms.OpenFileDialog fileDialog = new System.Windows.Forms.OpenFileDialog();
                fileDialog.Filter = "Text Files|*.txt";
                fileDialog.Title = "Select a level";
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LoadMap(fileDialog.FileName);
                }
            }

            if (buttonList[6].IsClicked())
            {
                showGrid = !showGrid;
            }

            if (selectedTileType == 0)
            {
                foreach (Tile t in floorTiles)
                {
                    Rectangle tileHitbox = new Rectangle((int)t.position.X, (int)t.position.Y, t.texture.Width, t.texture.Height);
                    if (KeyMouseReader.LeftClick() && tileHitbox.Contains(KeyMouseReader.mousePosition))
                    {
                        selectedTexture = t.texture;
                    }
                }
            }
            if (selectedTileType == 1)
            {
                foreach (Tile t in wallTiles)
                {
                    Rectangle tileHitbox = new Rectangle((int)t.position.X, (int)t.position.Y, t.texture.Width, t.texture.Height);
                    if (KeyMouseReader.LeftClick() && tileHitbox.Contains(KeyMouseReader.mousePosition))
                    {
                        selectedTexture = t.texture;
                    }
                }
            }

            if (KeyMouseReader.mouseState.LeftButton == ButtonState.Pressed)
            {
                int XValue = (int)((KeyMouseReader.mousePosition.X - tileGridOffset.X) / tileSize);
                int YValue = (int)((KeyMouseReader.mousePosition.Y - tileGridOffset.Y) / tileSize);

                for (int i = 0; i < tileArray.GetLength(0); i++)
                {
                    for (int j = 0; j < tileArray.GetLength(1); j++)
                    {
                        if (i == XValue && j == YValue)
                        {
                            if (selectedTileType == 0)
                            {
                                tileArray[i, j] = new Tile(selectedTexture, new Vector2(i * tileSize + tileGridOffset.X, j * tileSize + tileGridOffset.Y), false);
                            }
                            if (selectedTileType == 1)
                            {
                                tileArray[i, j] = new Tile(selectedTexture, new Vector2(i * tileSize + tileGridOffset.X, j * tileSize + tileGridOffset.Y), true);
                            }
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonList)
            {
                b.Draw(spriteBatch);
            }
            if (selectedTileType == 0)
            {
                foreach (Tile t in floorTiles)
                {
                    t.Draw(spriteBatch);
                }
            }
            if (selectedTileType == 1)
            {
                foreach (Tile t in wallTiles)
                {
                    t.Draw(spriteBatch);
                }
            }
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                for (int j = 0; j < tileArray.GetLength(1); j++)
                {
                    tileArray[i, j].Draw(spriteBatch);
                }
            }
            DrawGrid(spriteBatch);
            spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "Selected tile:", new Vector2(32, 864), Color.White);
            spriteBatch.Draw(selectedTexture, new Vector2(32, 880), Color.White);
        }

        protected void DrawGrid(SpriteBatch spriteBatch)
        {
            if (showGrid)
            {
                for (int x = 0; x <= tileArray.GetLength(0); x++)
                {
                    spriteBatch.Draw(Archive.textureDictionary["whitePixel"], 
                        new Rectangle(x * tileSize + (int)tileGridOffset.X, (int)tileGridOffset.Y, 1, tileArray.GetLength(1) * tileSize), Color.Black);
                }
                for (int y = 0; y <= tileArray.GetLength(1); y++)
                {
                    spriteBatch.Draw(Archive.textureDictionary["whitePixel"], 
                        new Rectangle((int)tileGridOffset.X, y * tileSize + (int)tileGridOffset.Y, tileArray.GetLength(0) * tileSize, 1), Color.Black);
                }
            }
        }

        public void TileKeyBinds()
        {

        }
    }
}

