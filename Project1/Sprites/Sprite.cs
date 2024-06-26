﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Sprites
{
    internal class Sprite
    {
        public bool IsRemoved { get; set; } = false;
        private static readonly float scale = 1f;

        public Texture2D texture;
        public Vector2 position;

        public Rectangle Rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width * (int)scale, texture.Height * (int)scale);
            }
        }

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void OnCollision(Sprite otherSprite)
        {
        }
    }
}
