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

        private void ChangeDirection(Vector2 dir)
        {

            Vector2 newDestination = pos + dir * 50.0f;
            //check if we cna move in the desired direction, if not, do nothing
            //if (!game.getTileATPositoon(newDestination).Wall)
            //{
            //    direction = dir;
            //    destination = newDestination;
            //    moving = true;
            //}

        }
    }
}
