using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Sprites;
using System;

namespace Project1.Levels
{
    internal class WinMenu
    {
        private Texture2D backgroundTexture;
        protected SpriteFont font;

        public WinMenu(Texture2D backgroundTexture, SpriteFont font)
        {
            this.backgroundTexture = backgroundTexture;
            this.font = font;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 800, 500), Color.White);
            spriteBatch.DrawString(font, "Jumping Cat", new Vector2(280, 70), Color.Yellow);
            spriteBatch.DrawString(font, "поздравляем!", new Vector2(270, 110), Color.Yellow);
            spriteBatch.DrawString(font, "вы прошли все уровни", new Vector2(180, 140), Color.Yellow);
        }
    }
}

