using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Sprites
{
    internal class Enemy : Sprite
    {
        private int moveSpeed = 2;
        private bool moveRight = true;
        private Vector2 initialPosition;
        private Texture2D textureRight;
        private Texture2D textureLeft;

        public Enemy(Texture2D textureRight, Texture2D textureLeft, Vector2 position) : base(textureRight, position)
        {
            initialPosition = position;
            this.textureRight = textureRight;
            this.textureLeft = textureLeft;
        }

        public override void Update(GameTime gameTime)
        {
            if (moveRight)
            {
                position.X += moveSpeed;
                texture = textureRight;
                if (position.X >= initialPosition.X + 90)
                    moveRight = false;
            }
            else
            {
                position.X -= moveSpeed;
                texture = textureLeft;
                if (position.X <= initialPosition.X - 90)
                    moveRight = true;
            }

            base.Update(gameTime);
        }

        public override void OnCollision(Sprite otherSprite)
        {
            if (otherSprite is Player)
            {
                otherSprite.IsRemoved = true;
            }
        }

        public void Reset()
        {
            position = initialPosition;
            moveRight = true;
            texture = textureRight;
        }
    }
}
