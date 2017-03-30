using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Map
    {
        Player player;
        Tile[,] tiles;
        int doorPosY;
        int doorPosX;

        public Map()
        {

        }

        public string ZoneSwitch()
        {
             if (doorPosX == player.position.X && doorPosY == player.position.Y)
            {
                string fileName = ("map1");
                //Console.WriteLine("zone switch");
                return fileName;
            }

            return null;
        }

        public void setPlayer(Player player)
        {
            this.player = player;
        }

        public void setDoorPosY(int doorPosY)
        {
            this.doorPosY = doorPosY;
        }

        public void setDoorPostX(int doorPosX)
        {
            this.doorPosX = doorPosX;
        }

        public void SetTiles(Tile[,] tiles)
        {
            this.tiles = tiles;
        }

        public void Update(GameTime gameTime    )
        {
            player.Update(gameTime);
        }

        public Tile GetTileAtPosition(Vector2 vec)
        {
            return tiles[(int)vec.X / 50, (int)vec.Y / 50];
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile t in tiles)
            {
                t.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
        }
    }
}
