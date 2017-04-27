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
        protected Tile[,] tileArray;
        protected Entity[,] entityArray;
        protected int selectedTileType;

        protected List<Button> buttonList;
        protected List<Tile> floorTiles;
        protected List<Tile> wallTiles;
        protected List<Entity> entities;

        protected int tileSize;
        protected Vector2 tileStartPosition;
        protected Vector2 tileGridOffset;

        protected Tile selectedTile;
        protected Entity selectedEntity;

        protected bool showGrid;

        public MapEditor()
        {
            selectedTileType = 0;
            tileArray = new Tile[46, 26];
            entityArray = new Entity[46, 26];
            tileSize = 32;
            tileStartPosition = new Vector2(32, 944);
            tileGridOffset = new Vector2(0, 0);

            #region Buttons
            buttonList = new List<Button>();
            buttonList.Add(new Button(new Rectangle(1512, 50, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Floor"));
            buttonList.Add(new Button(new Rectangle(1512, 100, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Wall"));
            buttonList.Add(new Button(new Rectangle(1512, 150, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Entity"));
            buttonList.Add(new Button(new Rectangle(1512, 200, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Item"));
            buttonList.Add(new Button(new Rectangle(1662, 50, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Save map"));
            buttonList.Add(new Button(new Rectangle(1662, 100, 100, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Load map"));
            buttonList.Add(new Button(new Rectangle(1512, 300, 256, 50), Archive.textureDictionary["button"], Archive.fontDictionary["defaultFont"], "Toggle grid"));
            #endregion

            #region Floor Tiles
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
            #endregion

            #region Wall Tiles
            wallTiles = new List<Tile>();
            AddWallTile(Archive.textureDictionary["dungeonWall1"]);
            AddWallTile(Archive.textureDictionary["dungeonWall2"]);
            AddWallTile(Archive.textureDictionary["dungeonWall3"]);
            AddWallTile(Archive.textureDictionary["dungeonWall4"]);
            AddWallTile(Archive.textureDictionary["dungeonWall5"]);
            AddWallTile(Archive.textureDictionary["dungeonWall6"]);
            AddWallTile(Archive.textureDictionary["treeUpLeft"]);
            AddWallTile(Archive.textureDictionary["treeUpRight"]);
            AddWallTile(Archive.textureDictionary["treeDownLeft"]);
            AddWallTile(Archive.textureDictionary["treeDownRight"]);
            AddWallTile(Archive.textureDictionary["smallTree"]);
            #endregion

            selectedTile = floorTiles[0];

            entities = new List<Entity>();
            AddPlayer(Archive.textureDictionary["playerPlaceholder"]);
            AddEnemy(Archive.textureDictionary["goblinEntity"]);
            AddFriendly(Archive.textureDictionary["playerPlaceholder"]);

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

        public void AddPlayer(Texture2D tileTexture)
        {
            Vector2 position = tileStartPosition + new Vector2(40, 0) * entities.Count();
            entities.Add(new Player(tileTexture, position));
        }

        public void AddEnemy(Texture2D tileTexture)
        {
            Vector2 position = tileStartPosition + new Vector2(40, 0) * entities.Count();
            entities.Add(new Enemy(tileTexture, position));
        }

        public void AddFriendly(Texture2D tileTexture)
        {
            Vector2 position = tileStartPosition + new Vector2(40, 0) * entities.Count();
            entities.Add(new FriendlyEntity(tileTexture, position, Archive.dialogDictionary["testDialog"]));
        }

        public void LoadMap(string path)
        {
            Map loadedMap = FileReader.ReadMap(path);
            tileArray = loadedMap.tiles;
            entityArray = new Entity[46,26];

            foreach (Entity e in loadedMap.entityList)
            {
                int XValue = (int)(e.position.X / tileSize);
                int YValue = (int)(e.position.Y / tileSize);

                if (e is Enemy)
                {
                    entityArray[XValue, YValue] = new Enemy(e.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y));
                }
                else if (e is FriendlyEntity)
                {
                    FriendlyEntity f = (FriendlyEntity)e;
                    entityArray[XValue, YValue] = new FriendlyEntity(e.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y),
                        f.dialog);
                }
            }

            if (loadedMap.player != null)
            {
                int XValue = (int)(loadedMap.player.position.X / tileSize);
                int YValue = (int)(loadedMap.player.position.Y / tileSize);
                entityArray[XValue, YValue] = new Entity(loadedMap.player.animation.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y));
            }
            
        }

        // Update() är för stor, pls fix
        public void Update()
        {
            if (buttonList[0].IsClicked())
            {
                selectedTileType = 0;
                selectedTile = floorTiles[0];
                selectedEntity = null;
            }
            if (buttonList[1].IsClicked())
            {
                selectedTileType = 1;
                selectedTile = wallTiles[0];
                selectedEntity = null;
            }
            if (buttonList[2].IsClicked())
            {
                selectedTileType = 2;
                selectedTile = null;
                selectedEntity = entities[0];
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
                    FileReader.WriteMap(fileDialog.FileName, tileArray, entityArray);
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

            TilePicker();

            PlaceTile();
        }

        protected void TilePicker()
        {
            if (selectedTileType == 0)
            {
                foreach (Tile t in floorTiles)
                {
                    Rectangle tileHitbox = new Rectangle((int)t.position.X, (int)t.position.Y, t.texture.Width, t.texture.Height);
                    if (KeyMouseReader.LeftClick() && tileHitbox.Contains(KeyMouseReader.mousePosition))
                    {
                        selectedTile = t;
                        selectedEntity = null;
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
                        selectedTile = t;
                        selectedEntity = null;
                    }
                }
            }
            if (selectedTileType == 2)
            {
                foreach (Entity e in entities)
                {
                    Rectangle tileHitbox = new Rectangle((int)e.position.X, (int)e.position.Y, e.texture.Width, e.texture.Height);
                    if (KeyMouseReader.LeftClick() && tileHitbox.Contains(KeyMouseReader.mousePosition))
                    {
                        selectedTile = null;
                        selectedEntity = e;
                    }
                }
            }
        }

        protected void PlaceTile()
        {
            int XValue = (int)((KeyMouseReader.mousePosition.X - tileGridOffset.X) / tileSize);
            int YValue = (int)((KeyMouseReader.mousePosition.Y - tileGridOffset.Y) / tileSize);

            if (KeyMouseReader.mouseState.LeftButton == ButtonState.Pressed)
            {
                if (selectedTileType == 0 || selectedTileType == 1)
                {
                    if ((XValue >= 0 && XValue < entityArray.GetLength(0)) &&
                        (YValue >= 0 && YValue < entityArray.GetLength(1)))
                    {
                        if (selectedTileType == 0)
                        {
                            tileArray[XValue, YValue] = new Tile(selectedTile.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y), false);
                        }
                        if (selectedTileType == 1)
                        {
                            tileArray[XValue, YValue] = new Tile(selectedTile.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y), true);
                        }
                    }
                }
                else if (selectedTileType == 2)
                {
                    if ((XValue >= 0 && XValue < entityArray.GetLength(0)) &&
                        (YValue >= 0 && YValue < entityArray.GetLength(1)))
                    {
                        if (selectedEntity is Player)
                        {
                            entityArray[XValue, YValue] = new Player(selectedEntity.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y));
                        }
                        else if (selectedEntity is Enemy)
                        {
                            entityArray[XValue, YValue] = new Enemy(selectedEntity.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y));
                        }
                        else if (selectedEntity is FriendlyEntity)
                        {
                            entityArray[XValue, YValue] = new FriendlyEntity(selectedEntity.texture, new Vector2(XValue * tileSize + tileGridOffset.X, YValue * tileSize + tileGridOffset.Y),
                                Archive.dialogDictionary["testDialog"]);
                        }
                    }
                }
            }
            else if (KeyMouseReader.mouseState.RightButton == ButtonState.Pressed)
            {
                if (selectedTileType == 2)
                {
                    if ((XValue >= 0 && XValue < entityArray.GetLength(0)) &&
                        (YValue >= 0 && YValue < entityArray.GetLength(1)))
                    {
                        entityArray[XValue, YValue] = null;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawButtons(spriteBatch);
            DrawSelectedTileSet(spriteBatch);
            foreach (Tile t in tileArray)
            {
                t.Draw(spriteBatch);
            }
            foreach (Entity e in entityArray)
            {
                if (e != null)
                {
                    e.Draw(spriteBatch);
                }
            }
            DrawGrid(spriteBatch);
            spriteBatch.DrawString(Archive.fontDictionary["defaultFont"], "Selected tile:", new Vector2(32, 864), Color.White);
            if (selectedTile != null)
            {
                spriteBatch.Draw(selectedTile.texture, new Vector2(32, 880), Color.White);
            }
            if (selectedEntity != null)
            {
                selectedEntity.animation.Draw(spriteBatch, new Vector2(32, 880));
            }
        }

        protected void DrawButtons(SpriteBatch spriteBatch)
        {
            foreach (Button b in buttonList)
            {
                b.Draw(spriteBatch);
            }
        }

        protected void DrawSelectedTileSet(SpriteBatch spriteBatch)
        {
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
            if (selectedTileType == 2)
            {
                foreach (Entity e in entities)
                {
                    e.Draw(spriteBatch);
                }
            }
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
    }
}

