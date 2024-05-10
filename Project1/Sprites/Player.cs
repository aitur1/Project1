using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Sprites;
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
        public int health;
        public int healthMax;
        public bool Dead;

        private bool canTakeDamage = true;
        private TimeSpan damageDelay = TimeSpan.FromSeconds(1);
        private TimeSpan lastDamageTime = TimeSpan.Zero;
        private Color playerColor = Color.White;

        public Player(Texture2D texture, Vector2 position, List<Sprite> collisionGroup) : base(texture, position)
        {
            this.collisionGroup = collisionGroup;

            Dead = false;
            healthMax = 3;
            health = healthMax;
        }

        public override void Update(GameTime gameTime)
        {
            if (!Dead)
            {
                base.Update(gameTime);

                HandleMovement();
                HandleCollision();
                HandleJumping();
                HandleDamage(gameTime);
            }

            if (gameTime.TotalGameTime - lastDamageTime > damageDelay)
            {
                playerColor = Color.White;
            }
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

            if (!isJumping && (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W)) && isOnPlatform)
            {
                isJumping = true;
                jumpSpeed = 10f;
            }

            if (isJumping)
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
            else if (!isOnPlatform)
            {
                position.Y += gravity;
            }
        }

        private bool IsOnPlatform()
        {
            foreach (var sprite in collisionGroup)
            {
                if (sprite.Rect.Intersects(Rect) && sprite is Platform)
                    return true;
            }
            return false;
        }

        private void HandleDamage(GameTime gameTime)
        {
            if (lastDamageTime == TimeSpan.Zero || (gameTime.TotalGameTime - lastDamageTime) > damageDelay)
            {
                foreach (var sprite in collisionGroup)
                {
                    if (sprite != this && sprite is Enemy && sprite.Rect.Intersects(Rect))
                    {
                        playerColor = Color.Red;
                        GetHit(1);
                        lastDamageTime = gameTime.TotalGameTime;
                        return;
                    }
                }
            }
        }

        private void GetHit(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Dead = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, playerColor);
        }
    }
}
