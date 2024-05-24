using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;

namespace Project1.Sprites
{
    public class ButtonStart
    {
        Texture2D texture;
        Vector2 position;
        Rectangle bounds;

        public event EventHandler Click;

        private bool isVisible = true;

        public bool Visible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public ButtonStart(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            if (bounds.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }
    }
}
