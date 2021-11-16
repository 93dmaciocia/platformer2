using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer2.src
{
    public class Animation
    {

        Texture2D spriteSheet;
        int frames;
        int rows = 0;
        int counter = 0;
        float timeSinceLastFrame = 0;

        public Animation(Texture2D spriteSheet, float width=32, float height=32)
        {
            this.spriteSheet = spriteSheet;
            frames = (int)(spriteSheet.Width / width);
            Console.WriteLine(frames);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, GameTime gameTime, float milliSecondsFrame=500)
        {
            if (counter < frames)
            {
                var rect = new Rectangle(32 * counter, rows, 32, 32);
                spriteBatch.Draw(spriteSheet, position, rect, Color.White);
                timeSinceLastFrame += (float)(gameTime.ElapsedGameTime.TotalMilliseconds);

                if(timeSinceLastFrame > milliSecondsFrame)
                {
                    timeSinceLastFrame -= milliSecondsFrame;
                    counter++;

                    if( counter == frames)
                    {
                        counter = 0;
                    }
                }
            }
        }
    }
}
