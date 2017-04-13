using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Grupp_31_SystemUtveckling
{
    class MapEditor
    {
        Tile[,] tileArray;
        int selectedTileType;

        Rectangle TRec;
        Rectangle WRec;
        Rectangle SRec;
        Rectangle WalkTile1Rec;
        Rectangle WalkTile2Rec;

        Vector2 Tpos;
        Vector2 Wpos;
        Vector2 Spos;
        Vector2 WalkTile1pos;
        Vector2 WalkTile2pos;

        Texture2D WalkTileTex;
        Texture2D WallTileTex;

        public MapEditor()
        {
            selectedTileType = 0;
            tileArray = new Tile[46, 26];
            TRec = new Rectangle(1512, 50, 100, 100);
            WRec = new Rectangle(1512, 250, 100, 100);
            SRec = new Rectangle(1512, 450, 100, 100);
            WalkTile1Rec = new Rectangle(32, 864, 32, 32);
            WalkTile2Rec = new Rectangle(32, 928, 32, 32);
            Tpos = new Vector2(1512, 50);
            Wpos = new Vector2(1512, 250);
            Spos = new Vector2(1512, 450);
            WalkTile1pos = new Vector2(32, 864);
            WalkTile2pos = new Vector2(32, 928);
            WalkTileTex = Archive.textureDictionary["tile"];
            WallTileTex = Archive.textureDictionary["tileDoor"];

            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                //antal element i andra dimensionen
                for (int j = 0; j < tileArray.GetLength(1); j++)
                { tileArray[i, j] = new Tile(Archive.textureDictionary["EditorTile"], new Vector2(i * 32, j * 32), true); }
            }
        }

        public void SaveMap()
        {
            string path = "MapRPG.txt";


            using (StreamWriter sw = File.CreateText(path))
            {
                for (int i = 0; i < tileArray.GetLength(0); i++)
                {
                    //antal element i andra dimensionen
                    for (int j = 0; j < tileArray.GetLength(1); j++)
                    {
                        //wall är enbart true atm måste fixas!
                        sw.WriteLine("tile;" + tileArray[i, j].texture + ";" + tileArray[i, j].position.X + ";" + tileArray[i, j].position.Y + ";true");
                    }

                }

            }

        }

        public void Update()
        {
            
            Rectangle keyMouseRec = new Rectangle(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y, 5, 5);
            Vector2 mousePos = new Vector2(KeyMouseReader.mouseState.X, KeyMouseReader.mouseState.Y);

            if (KeyMouseReader.LeftClick() && keyMouseRec.Intersects(TRec))
            {
                selectedTileType = 1;
            }

            if (KeyMouseReader.LeftClick() && keyMouseRec.Intersects(WRec))
            {
                selectedTileType = 0;
            }

            if (KeyMouseReader.LeftClick() && keyMouseRec.Intersects(SRec))
            {
                SaveMap();
            }

            if(KeyMouseReader.LeftClick() && keyMouseRec.Intersects(WalkTile1Rec))
            {
                WalkTileTex = Archive.textureDictionary["EditorTile"];
            }

            if (KeyMouseReader.LeftClick() && keyMouseRec.Intersects(WalkTile2Rec))
            {
                WalkTileTex = Archive.textureDictionary["tile"];
            }

            if (KeyMouseReader.LeftClick())
            {
                int XValue = (int)(mousePos.X / 32f);
                int YValue = (int)(mousePos.Y / 32f);

                for (int i = 0; i < tileArray.GetLength(0); i++)
                {

                    for (int j = 0; j < tileArray.GetLength(1); j++)
                    {
                        if (i == XValue && j == YValue)
                        {
                            if (selectedTileType == 0)
                                tileArray[i, j] = new Tile(WallTileTex, new Vector2(i * 32, j * 32), true);
                            if (selectedTileType == 1)
                                tileArray[i, j] = new Tile(WalkTileTex, new Vector2(i * 32, j * 32), false);
                        }
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Archive.textureDictionary["WalkTilePlaceholder"], Tpos, Color.White);
            spriteBatch.Draw(Archive.textureDictionary["WallTIlePlaceholder"], Wpos, Color.White);
            spriteBatch.Draw(Archive.textureDictionary["SavePlaceholder"], Spos, Color.White);
            spriteBatch.Draw(Archive.textureDictionary["EditorTile"], WalkTile1pos, Color.White);
            spriteBatch.Draw(Archive.textureDictionary["tile"], WalkTile2pos, Color.White);
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                //antal element i andra dimensionen
                for (int j = 0; j < tileArray.GetLength(1); j++)
                    tileArray[i, j].Draw(spriteBatch);
            }

        }

        public void TileKeyBinds()
        {

        }
    }
}

