using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Project1.Views
{
    public class MainMenu
    {
        private readonly Texture2D backgroundTexture;
        private readonly Texture2D buttonTexture;
        private readonly Vector2 buttonPosition;
        private readonly Rectangle buttonRectangle;

        public event EventHandler StartGameClicked;

        public MainMenu(Texture2D backgroundTexture, Texture2D buttonTexture)
        {
            this.backgroundTexture = backgroundTexture;
            this.buttonTexture = buttonTexture;
            buttonPosition = new Vector2(400, 300);
            buttonRectangle = new Rectangle((int)buttonPosition.X, (int)buttonPosition.Y, buttonTexture.Width, buttonTexture.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed &&
                buttonRectangle.Contains(Mouse.GetState().Position))
            {
                StartGameClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(buttonTexture, buttonPosition, Color.White);
        }
    }
}

