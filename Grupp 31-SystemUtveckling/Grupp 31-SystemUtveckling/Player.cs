using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Player : Entity
    {
        Game1 game;

        public Player(Texture2D tex, Vector2 pos): base(tex, pos, new Rectangle(0, 0, tex.Width / 4, tex.Height), new Rectangle((int)pos.X, (int)pos.Y, tex.Width / 4, tex.Height))
        {
            this.game = game;
        }

        //behöver fixas
        //private void ChangeDirection(Vector2 dir)
        //{

        //    Vector2 newDestination = pos + dir * 50.0f;
        //    check if we cna move in the desired direction, if not, do nothing
        //    if (!game.getTileATPositoon(newDestination).Wall)
        //    {
        //        direction = dir;
        //        destination = newDestination;
        //        moving = true;
        //    }

        //}

        public void Update(GameTime gameTime)
        {
            //if we're not already moving, pick a new direciton and check if 
            //we can move in that direction
            //otherwise, move toward the destination
            if (!moving)
            {
                Console.WriteLine("test");
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    ChangeDirection(new Vector2(-1, 0));
                    rotation = MathHelper.ToRadians(-180);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    ChangeDirection(new Vector2(1, 0));
                    rotation = MathHelper.ToRadians(0);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    ChangeDirection(new Vector2(0, -1));
                    rotation = MathHelper.ToRadians(-90);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    ChangeDirection(new Vector2(0, 1));
                    rotation = MathHelper.ToRadians(-270);
                }
            }
            else
            {
                move(gameTime);

            }
        }
    }
}
