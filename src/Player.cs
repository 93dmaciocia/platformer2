using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Platformer2.src
{
    public class Player : Entity
    {
        
        public Vector2 Velocity;

        public float playerSpeed = 2;
        public float fallSpeed = 0;

        public Animation[] playerAnimation;
        public currentAnimation playerAnimationController;

        public Player(Texture2D idleSprite, Texture2D runSprite)
        {
            playerAnimation = new Animation[2];

            position = new Vector2();
            Velocity = new Vector2();

            playerAnimation[0] = new Animation(idleSprite);
            playerAnimation[1] = new Animation(runSprite);
            hitBox = new Rectangle((int)position.X, (int)position.Y, 32, 32);
            
        }

        public override void Update()
        {
            KeyboardState keyboard = Keyboard.GetState();

            playerAnimationController = currentAnimation.Idle;
            //Velocity.Y += fallSpeed;
            if (keyboard.IsKeyDown(Keys.A))
            {
                Velocity.X -= playerSpeed;
                playerAnimationController = currentAnimation.Run;
            }
            if(keyboard.IsKeyDown(Keys.D))
            {
                Velocity.X += playerSpeed;
                playerAnimationController = currentAnimation.Run;

            }
            position = Velocity;
            hitBox.X = (int)position.X;
            hitBox.Y = (int)position.Y;
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch(playerAnimationController)
            {
                case currentAnimation.Idle:
                    playerAnimation[0].Draw(spriteBatch, position, gameTime, 300);

                    break;
                case currentAnimation.Run:
                    playerAnimation[1].Draw(spriteBatch, position, gameTime, 100);
                    break;
            }
            //spriteBatch.Draw(spriteSheet, position, Color.White);
        }
    }
}
