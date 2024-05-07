using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Project1
{
    internal class MainMenu
    {
        private Button startButton;

        public event EventHandler StartGameClicked;

        public MainMenu(Texture2D buttonTexture)
        {
            startButton = new Button(buttonTexture, new Vector2(100, 100));
            startButton.Click += StartButton_Click;
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
            startButton.Draw(spriteBatch);
        }
    }
}
