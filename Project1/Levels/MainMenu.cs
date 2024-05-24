using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Sprites;
using System;

namespace Project1.Levels
{
    internal class MainMenu
    {
        private Texture2D backgroundTexture;
        private ButtonStart startButton;
        protected SpriteFont font;

        public event EventHandler StartGameClicked;

        public MainMenu(Texture2D backgroundTexture, Texture2D buttonTexture, SpriteFont font)
        {
            this.backgroundTexture = backgroundTexture;
            startButton = new ButtonStart(buttonTexture, new Vector2(350, 120));
            startButton.Click += StartButton_Click;
            this.font = font;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartGameClicked?.Invoke(this, EventArgs.Empty);
        }

        public void Update(GameTime gameTime)
        {
            startButton.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0,0, 800, 500), Color.White);
            startButton.Draw(spriteBatch);
            spriteBatch.DrawString(font, "Jumping Cat", new Vector2(280, 70), Color.Yellow);
        }
    }
}

