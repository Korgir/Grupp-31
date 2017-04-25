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
        public Player player;
        public Tile[,] tiles;
        int doorPosY;
        int doorPosX;
        public List<Enemy> enemyList;

        public Map()
        {
            enemyList = new List<Enemy>();
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

        public void SetDoorPosY(int doorPosY)
        {
            this.doorPosY = doorPosY;
        }

        public void SetDoorPostX(int doorPosX)
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

        public bool EngageCombatBool(ref Combat combat)
        {
            foreach (Enemy e in enemyList)
            {
                if (EngageCombat(player, e) && e.IsTeamAlive())
                {
                    combat = new Combat(player.team, e.team);
                    return true;
                }
            }
            return false;
        }

        public bool EngageCombat(Player player, Enemy enemy)
        {
            int distanceX = (int)(enemy.position.X - (int)player.position.X) / Archive.tileSize;
            int distanceY = (int)(enemy.position.Y - (int)player.position.Y) / Archive.tileSize;
            if (distanceX <= 2 && distanceX >= -2 && distanceY <= 2 && distanceY >= -2)
            {
                return true;
            }
            return false;
        }

        public Tile GetTileAtPosition(Vector2 vec)
        {
            int indexPositionX = ((int)vec.X) / Archive.tileSize;
            int indexPositionY = ((int)vec.Y) / Archive.tileSize;

            if (indexPositionX >= 0 && indexPositionX < tiles.GetLength(0))
            {
                if (indexPositionY >= 0 && indexPositionY < tiles.GetLength(1))
                {
                    return tiles[indexPositionX, indexPositionY];
                }
            }

            return null;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile t in tiles)
            {
                t.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
            foreach (Enemy e in enemyList)
            {
                e.Draw(spriteBatch);
            }

            spriteBatch.Draw(Archive.textureDictionary["uiWorld"], Vector2.Zero, Color.White); // Placeholder
        }
    }
}
