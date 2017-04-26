using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    class Entity
    {
        public Texture2D texture;
        public Vector2 position;
        protected float rotation;
        protected Vector2 destination;
        protected Vector2 direction;
        protected float speed = 100.0f;
        protected bool moving = false;

        public Animation animation;
        protected Rectangle objectRectangle;

        public List<Character> team;

        public Entity(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            objectRectangle = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            animation = new Animation(texture, 3, 4, 0.25f, false, false);
            animation.AddAnimationLoop("walk_down", new Point(0, 0), new Point(2, 0));
            animation.AddAnimationLoop("walk_right", new Point(0, 1), new Point(2, 1));
            animation.AddAnimationLoop("walk_left", new Point(0, 2), new Point(2, 2));
            animation.AddAnimationLoop("walk_up", new Point(0, 3), new Point(2, 3));
            animation.ChangeAnimationLoop("walk_down");

            this.team = new List<Character>();
        }

        public void Move(GameTime gameTime)
        {
            position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            objectRectangle.X = (int)position.X;
            objectRectangle.Y = (int)position.Y;
            if (Vector2.Distance(position, destination) < 2)
            {
                position = destination;
                objectRectangle.X = (int)position.X;
                objectRectangle.Y = (int)position.Y;
                moving = false;
            }
        }

        public void ChangePos(Vector2 newPos)
        {
            position = newPos;
            moving = false;
            objectRectangle.X = (int)position.X;
            objectRectangle.Y = (int)position.Y;
        }

        public bool IsTeamAlive()
        {
            int aliveCharactersCount = team.Count;
            foreach (Character c in team)
            {
                if (!c.alive)
                {
                    aliveCharactersCount--;
                }
            }
            if (aliveCharactersCount > 0)
            {
                return true;
            }
            return false;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            animation.Draw(spriteBatch, position);
        }
    }
}
