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
        //Enemy ska röra sig i ett mönster. Man ska gå in i combat när Player går inom en viss radius från Enemy.
        
        Map map;
        Random rand;

        protected Rectangle enemyRec;

        public Enemy(Texture2D texture, Vector2 position/*, Rectangle sprRec, Rectangle objRec*/) : base(texture, position/*, sprRec, objRec*/)
        {
            this.enemyRec = new Rectangle((int)position.X, (int)position.Y, texture.Width / 4, texture.Height);
            rand = new Random();
        }

        public void SetMap(Map map)
        {
            this.map = map;
        }

        //private void ChangeDirection(Vector2 dir)
        //{
        //    direction = dir;
        //    //ändringar 
        //    Vector2 newDestination = pos + direction * 50.0f;
        //    if (!game.GetTileAtPosition(newDestination).Wall)
        //    {
        //        destination = newDestination;
        //        moving = true;
        //    }
        //}

        public void Update(GameTime gameTime)
        {
            enemyRec = new Rectangle((int)position.X, (int)position.Y, texture.Width / 4, texture.Height);

            //int randX = rand.Next(1, 4);
            //int randY = rand.Next(1, 4);

        }

    }
}
