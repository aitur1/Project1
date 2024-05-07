using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project1
{
    internal class Level2
    {
        private List<Sprite> sprites;
        public Player player { get; private set; }

        public bool PlayerTouchesRightEdge(GraphicsDevice graphicsDevice)
        {
            return player.position.X + player.texture.Width >= graphicsDevice.Viewport.Width;
        }

        public Level2(Texture2D playerTexture, Texture2D enemyTexture, Texture2D platformTexture)
        {
            sprites = new List<Sprite>();

            sprites.Add(new Sprite(platformTexture, new Vector2(0, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(230, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(460, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(690, 1000)));

            sprites.Add(new Enemy(enemyTexture, new Vector2(100, 960)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(400, 960)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(250, 960)));

            sprites.Add(new Player(playerTexture, new Vector2(500, 840), sprites));
        }

        public void Update(GameTime gameTime)
        {
            foreach (var sprite in sprites)
            {
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }
        }
    }
}
