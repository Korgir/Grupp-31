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

        Vector2 Tpos;
        Vector2 Wpos;
        Vector2 Spos;

        public MapEditor()
        {
            selectedTileType = 0;
            tileArray = new Tile[46, 26];
            TRec = new Rectangle(1512, 50, 100, 100);
            WRec = new Rectangle(1512, 250, 100, 100);
            SRec = new Rectangle(1512, 450, 100, 100);
            Tpos = new Vector2(1512, 50);
            Wpos = new Vector2(1512, 250);
            Spos = new Vector2(1512, 450);

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
                                tileArray[i, j] = new Tile(Archive.textureDictionary["tileDoor"], new Vector2(i * 32, j * 32), false);
                            if (selectedTileType == 1)
                                tileArray[i, j] = new Tile(Archive.textureDictionary["tile"], new Vector2(i * 32, j * 32), true);
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
            for (int i = 0; i < tileArray.GetLength(0); i++)
            {
                //antal element i andra dimensionen
                for (int j = 0; j < tileArray.GetLength(1); j++)
                    tileArray[i, j].Draw(spriteBatch);
            }

        }
    }
}

