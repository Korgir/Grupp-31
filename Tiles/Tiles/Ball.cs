﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Tiles
{
    class Ball : GameObject
    {
        Game1 game;
        Vector2 destination;
        Vector2 direction;
        float speed = 100.0f;
        bool moving = false;

        public Ball(Texture2D texture, Vector2 position, Game1 game) : base(texture, position)
        {
            this.game = game;
        }

        private void ChangeDirection(Vector2 dir)
        {
            direction = dir;
            Vector2 newDestination = position + direction * 50.0f;

            if (!game.GetTileAtPosition(newDestination).Wall)
            {
                destination = newDestination;
                moving = true;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!moving)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    ChangeDirection(new Vector2(-1, 0));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    ChangeDirection(new Vector2(1, 0));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    ChangeDirection(new Vector2(0, -1));
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    ChangeDirection(new Vector2(0, 1));
                }
            }
            else
            {
                position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Vector2.Distance(position, destination) < 1)
                {
                    position = destination;
                    moving = false;
                }
            }
        }


    }
}
