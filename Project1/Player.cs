using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Project1
{
    internal class Player : Sprite
    {
        private readonly List<Sprite> collisionGroup;
        private bool isJumping;
        private float jumpSpeed = 10f;
        private const float gravity = 0.5f;
        private const int movementSpeed = 5;

        public Player(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
        {
            this.collisionGroup = collisionGroup;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            HandleMovement();
            HandleCollision();
            HandleJumping();
        }

        private void HandleMovement()
        {
            float changeX = 0;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                changeX += movementSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                changeX -= movementSpeed;
            position.X += changeX;
        }

        private void HandleCollision()
        {
            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.X -= (float)Math.Sign(position.X - sprite.position.X);
                }

                if (sprite != this && sprite is Coin coin && coin != null && !coin.IsCollected && Rect.Intersects(coin.Rect))
                {
                    coin.Collect();
                }
            }
        }

        private void HandleJumping()
        {
            bool isOnPlatform = IsOnPlatform();

            if (!isJumping && (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W)))
            {
                isJumping = true;
                jumpSpeed = 10f;
            }

            if (isJumping || !isOnPlatform)
            {
                position.Y -= jumpSpeed;
                jumpSpeed -= gravity;

                foreach (var sprite in collisionGroup)
                {
                    if (sprite != this && sprite is Coin coin && coin != null && !coin.IsCollected && Rect.Intersects(coin.Rect))
                    {
                        coin.Collect();
                    }

                    if (sprite != this && sprite is Platform platform && platform != null && Rect.Intersects(platform.Rect))
                    {
                        position.Y = platform.position.Y - texture.Height;
                        isJumping = false;
                        jumpSpeed = 0;
                    }
                }
            }
            else
            {
                isJumping = false;
                jumpSpeed = 0;
            }
        }

        private bool IsOnPlatform()
        {
            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect) && sprite is Platform)
                    return true;
            }
            return false;
        }
    }
}

