using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1
{
    internal class ButtonRestart
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle bounds;

        public ButtonRestart(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public bool IsClicked(MouseState mouseState, MouseState previousMouseState)
        {
            return bounds.Contains(mouseState.Position) && mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
