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

        private Texture2D textureLeft; 
        private Texture2D textureRight;
        private bool isMovingLeft;
        private bool isMovingRight;

        private TimeSpan damageDelay = TimeSpan.FromSeconds(1);
        private TimeSpan lastDamageTime = TimeSpan.Zero;
        private Color playerColor = Color.White;

        public Player(Texture2D textureLeft, Texture2D textureRight, Vector2 position, List<Sprite> collisionGroup) : base(textureRight, position)
        {
            this.textureLeft = textureLeft;
            this.textureRight = textureRight;
            this.collisionGroup = collisionGroup;

            Dead = false;
            healthMax = 3;
            health = healthMax;
        }

        public override void Update(GameTime gameTime)
        {
            if (!Dead)
            {
                HandleMovement();
                HandleJumping(gameTime);
                HandleCollision();
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
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D))
            {
                changeX += movementSpeed;
                texture = textureRight;
            }
            if (state.IsKeyDown(Keys.A))
            {
                changeX -= movementSpeed;
                texture = textureLeft;
            }

            position.X += changeX;
            position.X = MathHelper.Clamp(position.X, 0, 810 - texture.Width);
        }

        private void HandleJumping(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            bool isOnPlatform = IsOnPlatform();

            if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.W))
            {
                if (isOnPlatform && !isJumping)
                {
                    isJumping = true;
                    jumpSpeed = 10f;
                }
            }

            if (isJumping)
            {
                position.Y -= jumpSpeed;
                jumpSpeed -= gravity;

                if (jumpSpeed <= 0)
                {
                    isJumping = false;
                    jumpSpeed = 0;
                }
            }
            else if (!isOnPlatform)
            {
                jumpSpeed += gravity; // Применяем гравитацию к скорости падения
                position.Y += jumpSpeed;
            }

            position.Y = MathHelper.Clamp(position.Y, 0, 500 - texture.Height);
        }


        private void HandleCollision()
        {
            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    if (sprite is Platform platform)
                    {
                        if (position.Y + texture.Height <= platform.position.Y + 1)
                        {
                            position.Y = platform.position.Y - texture.Height;
                        }
                        else
                        {
                            position.X -= (float)Math.Sign(position.X - platform.position.X);
                        }
                    }

                    if (sprite is Coin coin && !coin.IsCollected)
                    {
                        coin.Collect();
                    }

                    if (sprite is Enemy)
                    {
                        // Handle enemy collision in HandleDamage method
                    }
                }
            }
        }

        private bool IsOnPlatform()
        {
            foreach (var sprite in collisionGroup)
            {
                if (sprite is Platform platform)
                {
                    Rectangle playerRect = new Rectangle((int)position.X, (int)position.Y + texture.Height, texture.Width, 5);
                    if (playerRect.Intersects(platform.Rect))
                        return true;
                }
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

        public void Reset(Vector2 startPosition)
        {
            position = startPosition;
            health = healthMax;
            Dead = false;
            playerColor = Color.White;
            jumpSpeed = 10f;
            isJumping = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, playerColor);
        }
    }
}
