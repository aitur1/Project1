using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Project1
{
    internal class Player : Sprite
    {
        private List<Sprite> collisionGroup;
        private bool isJumping = false;
        private float jumpSpeed = 10f;
        private float gravity = 0.5f;

        public Player(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
        {
            this.collisionGroup = collisionGroup;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float changeX = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                changeX += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                changeX -= 5;
            position.X += changeX;

            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.X -= changeX;
                }
            }

            if (!isJumping && (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W)))
            {
                isJumping = true;
                jumpSpeed = 10f;
            }

            if (isJumping || !IsOnPlatform())
            {
                position.Y -= jumpSpeed;
                jumpSpeed -= gravity;

                foreach (var sprite in collisionGroup)
                {
                    if (sprite != this && sprite.Rect.Intersects(Rect))
                    {
                        position.Y += jumpSpeed;
                        isJumping = false;
                        jumpSpeed = 0;
                        break;
                    }
                }
            }
            else
            {
                isJumping = false;
                jumpSpeed = 0;
            }


            foreach (var sprite in collisionGroup)
            {
                if (sprite is Coin coin && coin != null && !coin.IsCollected && Rect.Intersects(coin.Rect))
                {
                    coin.Collect();
                }
            }
        }

        private bool IsOnPlatform()
        {
            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect) && sprite is Sprite && sprite != this)
                    return true;
            }
            return false;
        }
    }
}
