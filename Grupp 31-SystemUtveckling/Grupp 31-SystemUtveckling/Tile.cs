using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Grupp_31_SystemUtveckling
{
    public class Tile : GameObject
    {
        protected bool wall;

        public bool Wall
        {
            get { return wall; }
        }

        public Tile(Texture2D texture, Vector2 position, bool wall) : base(texture, position)
        {
            this.wall = wall;

        }
    }
}
