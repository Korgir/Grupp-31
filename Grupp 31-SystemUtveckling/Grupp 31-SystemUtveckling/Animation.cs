using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_31_SystemUtveckling
{
    struct AnimationLoop
    {
        public Point startFrame;
        public Point endFrame;

        public AnimationLoop(Point startFrame, Point endFrame)
        {
            this.startFrame = startFrame;
            this.endFrame = endFrame;
        }
    }
    class Animation
    {
        protected Texture2D texture;
        protected int horizontalFrames;
        protected int verticalFrames;
        protected int currentHorizontalFrame;
        protected int currentVerticalFrame;
        protected float timePerFrameSeconds;
        protected float currentTimeSeconds;

        protected string playingAnimation;
        Dictionary<string, AnimationLoop> animationLoops;

        public Animation(Texture2D texture, int horizontalFrames, int verticalFrames, float timePerFrameSeconds)
        {
            this.texture = texture;
            this.horizontalFrames = horizontalFrames;
            this.verticalFrames = verticalFrames;
            this.currentHorizontalFrame = 0;
            this.currentVerticalFrame = 0;
            this.timePerFrameSeconds = timePerFrameSeconds;
            this.currentTimeSeconds = 0;
            this.playingAnimation = "";

            animationLoops = new Dictionary<string, AnimationLoop>();
        }

        public void ChangeAnimationLoop(string name)
        {
            if (playingAnimation != name)
            {
                playingAnimation = name;
                currentHorizontalFrame = animationLoops[playingAnimation].startFrame.X;
                currentVerticalFrame = animationLoops[playingAnimation].endFrame.Y;
            }
        }

        public void AddAnimationLoop(string name, Point startFrame, Point endFrame)
        {
            if (endFrame.Y < startFrame.Y ||
                endFrame.Y == startFrame.Y && endFrame.X < startFrame.X)
            {
                endFrame = startFrame;
            }
            animationLoops.Add(name, new AnimationLoop(startFrame, endFrame));
        }

        public void Update(GameTime gameTime)
        {
            if (playingAnimation != null)
            {
                currentTimeSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (currentTimeSeconds >= timePerFrameSeconds)
                {
                    currentTimeSeconds %= timePerFrameSeconds;
                    currentHorizontalFrame++;
                    if (currentHorizontalFrame > horizontalFrames)
                    {
                        currentHorizontalFrame = 0;
                        currentVerticalFrame++;
                    }
                    if (currentVerticalFrame > verticalFrames)
                    {
                        currentHorizontalFrame = 0;
                        currentVerticalFrame = 0;
                    }
                }

                if (currentVerticalFrame > animationLoops[playingAnimation].endFrame.Y ||
                    (currentHorizontalFrame > animationLoops[playingAnimation].endFrame.X && 
                    currentVerticalFrame == animationLoops[playingAnimation].endFrame.Y))
                {
                    currentHorizontalFrame = animationLoops[playingAnimation].startFrame.X;
                    currentVerticalFrame = animationLoops[playingAnimation].startFrame.Y;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int frameWidth = texture.Width / horizontalFrames;
            int frameHeight = texture.Height / verticalFrames;
            Vector2 origin = Vector2.Zero; //new Vector2(frameWidth / 2, frameHeight / 2);
            Rectangle frame = new Rectangle(currentHorizontalFrame * frameWidth, 
                currentVerticalFrame * frameHeight, frameWidth, frameHeight);
            spriteBatch.Draw(texture, position, frame, Color.White, 0.0f, 
                origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
