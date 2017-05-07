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
        public List<Entity> entityList;
        public TabManager tabManager;

        public Map()
        {
            entityList = new List<Entity>();
            tabManager = new TabManager(this);
        }

        public PortalEntity ZoneSwitch()
        {
            foreach (Entity e in entityList)
            {
                if (e is PortalEntity)
                {
                    PortalEntity portal = (PortalEntity)e;
                    if (portal.position == player.position)
                    {
                        return portal;
                    }
                }
            }

            return null;
        }

        public void SetTiles(Tile[,] tiles)
        {
            this.tiles = tiles;
        }

        public void Update(GameTime gameTime)
        {
            tabManager.Update(gameTime);
            player.Update(gameTime);

            foreach (Entity e in entityList)
            {
                if (e is FriendlyEntity)
                {
                    FriendlyEntity npc = (FriendlyEntity)e;
                    if (npc.CanTalk(player))
                    {
                        npc.dialog.Update();
                    }
                    else
                    {
                        npc.dialog.StopTalking();
                    }
                }
            }

            for (int i = entityList.Count() -1; i >= 0; i--)
            {
                if (entityList[i] is ItemEntity)
                {
                    ItemEntity itemEntity = (ItemEntity)entityList[i];
                    if (player.PickUpItem(itemEntity))
                    {
                        entityList.RemoveAt(i);
                    }
                }
            }
        }

        public bool EngageCombatBool(ref Combat combat)
        {
            foreach (Entity e in entityList)
            {
                if (e is Enemy)
                {
                    Enemy enemy = (Enemy)e;
                    if (EngageCombat(player, enemy) && e.IsTeamAlive())
                    {
                        combat = new Combat(player.team.characters, e.team.characters);
                        return true;
                    }
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
            foreach (Entity e in entityList)
            {
                e.Draw(spriteBatch);
            }

            spriteBatch.Draw(Archive.textureDictionary["uiWorld"], Vector2.Zero, Color.White);
            tabManager.Draw(spriteBatch);

            foreach (Entity e in entityList)
            {
                if (e is FriendlyEntity)
                {
                    FriendlyEntity npc = (FriendlyEntity)e;
                    if (npc.CanTalk(player))
                    {
                        npc.dialog.Draw(spriteBatch, new Vector2(703, 957));
                    }
                }
            }
        }
    }
}
