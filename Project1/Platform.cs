using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    internal class Platform : Sprite
    {
        public Platform(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public override void Update(GameTime gameTime)
        {
            // Добавьте код обновления платформы, если это необходимо
        }
    }
}
