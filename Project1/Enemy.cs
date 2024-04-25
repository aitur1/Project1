using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Enemy : Sprite
    {
        private int moveSpeed = 2;
        private bool moveRight = true;

        public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            if (moveRight)
            {
                position.X += moveSpeed;
                if (position.X >= 100)
                    moveRight = false;
            }
            else
            {
                position.X -= moveSpeed;
                if (position.X <= 0)
                    moveRight = true;
            }

            base.Update(gameTime);
        }

        public override void OnCollision(Sprite otherSprite)
        {
            if (otherSprite is Player)
            {
                // Игрок исчезает при столкновении с врагом
                otherSprite.IsRemoved = true;
            }
        }
    }
}
