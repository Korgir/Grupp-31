using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        Game1 game;

        Random rand;
        
        protected Rectangle enemyRec;

        public Enemy(Texture2D tex, Vector2 pos, Rectangle sprRec, Rectangle objRec) : base(tex, pos, sprRec, objRec)
        {
            this.enemyRec = new Rectangle((int)pos.X, (int)pos.Y, tex.Width / 4, tex.Height);
            rand = new Random();
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
            enemyRec = new Rectangle((int)pos.X, (int)pos.Y, tex.Width / 4, tex.Height);

            int randX = rand.Next(1, 4);
            int randY = rand.Next(1, 4);

        }

        ////Komma på nåt bra namn. Ska inte vara här.
        //public void Engage()
        //{
        //    if (enemyRec.X - playerRec.X == 0))
        //    {
        //        Console.WriteLine("Combat");
        //    }
        //}
    }
}
