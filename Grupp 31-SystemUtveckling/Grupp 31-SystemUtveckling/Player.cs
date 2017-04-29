using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Player : Entity
    {
        public Map map;

        public Player(Texture2D texture, Vector2 position) : 
            base(texture, position)
        {
        }
        
        private void ChangeDirection(Vector2 direction)
        {
            Vector2 newDestination = position + direction * Archive.tileSize;
            if (map.GetTileAtPosition(newDestination) != null)
            {
                if (!map.GetTileAtPosition(newDestination).Wall)
                {
                    this.direction = direction;
                    destination = newDestination;
                    moving = true;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!moving)
            {
                Console.WriteLine("test");
                if (KeyMouseReader.KeyDown(Keybinds.binds["moveLeft"]))
                {
                    animation.ChangeAnimationLoop("walk_left");
                    ChangeDirection(new Vector2(-1, 0));
                    rotation = MathHelper.ToRadians(-180);
                }
                if (KeyMouseReader.KeyDown(Keybinds.binds["moveRight"]))
                {
                    animation.ChangeAnimationLoop("walk_right");
                    ChangeDirection(new Vector2(1, 0));
                    rotation = MathHelper.ToRadians(0);
                }
                if (KeyMouseReader.KeyDown(Keybinds.binds["moveUp"]))
                {
                    animation.ChangeAnimationLoop("walk_up");
                    ChangeDirection(new Vector2(0, -1));
                    rotation = MathHelper.ToRadians(-90);
                }
                if (KeyMouseReader.KeyDown(Keybinds.binds["moveDown"]))
                {
                    animation.ChangeAnimationLoop("walk_down");
                    ChangeDirection(new Vector2(0, 1));
                    rotation = MathHelper.ToRadians(-270);
                }
            }
            else
            {
                animation.Update(gameTime);
                Move(gameTime);
            }
        }
    }
}
