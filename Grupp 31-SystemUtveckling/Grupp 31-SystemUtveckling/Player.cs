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
        Map map;
        Animation animation;

        public Player(Texture2D tex, Vector2 pos) : 
            base(tex, pos/*, new Rectangle(0, 0, tex.Width / 4, tex.Height), new Rectangle((int)pos.X, (int)pos.Y, tex.Width / 4, tex.Height)*/)
        {
            this.animation = new Animation(tex, 3, 4, 0.25f);
            this.animation.AddAnimationLoop("walk_down", new Point(0, 0), new Point(2, 0));
            this.animation.AddAnimationLoop("walk_right", new Point(0, 1), new Point(2, 1));
            this.animation.AddAnimationLoop("walk_left", new Point(0, 2), new Point(2, 2));
            this.animation.AddAnimationLoop("walk_up", new Point(0, 3), new Point(2, 3));
            this.animation.ChangeAnimationLoop("walk_down");
        }

        //behöver fixas
        private void ChangeDirection(Vector2 dir)
        {
            Vector2 newDestination = position + dir * Archive.tileSize;
            //check if we cna move in the desired direction, if not, do nothing
            if (map.GetTileAtPosition(newDestination) != null)
            {
                if (!map.GetTileAtPosition(newDestination).Wall)
                {
                    direction = dir;
                    destination = newDestination;
                    moving = true;
                }
            }
        }

        public void SetMap(Map map)
        {
            this.map = map;
        }

        public void Update(GameTime gameTime)
        {
            //if we're not already moving, pick a new direciton and check if 
            //we can move in that direction
            //otherwise, move toward the destination
            if (!moving)
            {
                Console.WriteLine("test");
                if (KeyMouseReader.KeyDown(Keys.Left))
                {
                    this.animation.ChangeAnimationLoop("walk_left");
                    ChangeDirection(new Vector2(-1, 0));
                    rotation = MathHelper.ToRadians(-180);
                }
                if (KeyMouseReader.KeyDown(Keys.Right))
                {
                    this.animation.ChangeAnimationLoop("walk_right");
                    ChangeDirection(new Vector2(1, 0));
                    rotation = MathHelper.ToRadians(0);
                }
                if (KeyMouseReader.KeyDown(Keys.Up))
                {
                    this.animation.ChangeAnimationLoop("walk_up");
                    ChangeDirection(new Vector2(0, -1));
                    rotation = MathHelper.ToRadians(-90);
                }
                if (KeyMouseReader.KeyDown(Keys.Down))
                {
                    this.animation.ChangeAnimationLoop("walk_down");
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

        public override void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, this.position);
        }
    }
}
