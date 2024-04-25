using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    internal class Player : Sprite
    {
        List<Sprite> collisionGroup;

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

            float changeY = 0;
            changeY += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                changeY -= 10;
            position.Y += changeY;

            foreach (var sprite in collisionGroup)
            {
                if (sprite != this && sprite.Rect.Intersects(Rect))
                {
                    position.Y -= changeY;
                }
            }
        }
    }
}
