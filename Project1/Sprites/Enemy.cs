using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project1.Sprites
{
    internal class Enemy : Sprite
    {
        private int moveSpeed = 2;
        private bool moveRight = true;
        private Vector2 initialPosition;

        public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
        {
            initialPosition = position;
        }

        public override void Update(GameTime gameTime)
        {
            if (moveRight)
            {
                position.X += moveSpeed;
                if (position.X >= initialPosition.X + 100)
                    moveRight = false;
            }
            else
            {
                position.X -= moveSpeed;
                if (position.X <= initialPosition.X - 100)
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
    }
}
