using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platformer2.src
{
    public enum currentAnimation
    {
        Idle,
        Run

    }
    public abstract class Entity
    {
        public Vector2 position;
        public Rectangle hitBox;

       

        public abstract void Update();
        
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
