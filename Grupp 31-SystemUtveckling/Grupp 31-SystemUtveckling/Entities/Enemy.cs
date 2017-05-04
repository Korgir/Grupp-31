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
    class Enemy : Entity
    {
        protected Rectangle enemyRec;

        public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
        {
            this.enemyRec = new Rectangle((int)position.X, (int)position.Y, texture.Width / 4, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            enemyRec = new Rectangle((int)position.X, (int)position.Y, texture.Width / 4, texture.Height);

            //int randX = rand.Next(1, 4);
            //int randY = rand.Next(1, 4);
        }
    }
}
