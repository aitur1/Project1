using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project1.Levels
{
    internal class Level1
    {
        private List<Sprite> sprites;
        public Player player { get; private set; }
        private int coinsCollected = 0;

        public bool PlayerTouchesRightEdge(GraphicsDevice graphicsDevice)
        {
            if (player != null)
            {
                return player.position.X + player.texture.Width >= graphicsDevice.Viewport.Width;
            }
            return false;
        }
        public int GetCoinsCollected()
        {
            return coinsCollected;
        }


        public Level1(Texture2D playerTexture, Texture2D enemyTexture, Texture2D platformTexture, Texture2D coinTexture)
        {
            sprites = new List<Sprite>();

            // Create platform sprites
            sprites.Add(new Sprite(platformTexture, new Vector2(0, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(230, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(460, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(690, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(890, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(1090, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(1290, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(1490, 1000)));
            sprites.Add(new Sprite(platformTexture, new Vector2(1690, 1000)));

            // Create enemy sprites
            sprites.Add(new Enemy(enemyTexture, new Vector2(100, 960)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(400, 960)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(250, 960)));

            // Create player sprite
            sprites.Add(new Player(playerTexture, new Vector2(500, 840), sprites));

            sprites.Add(new Coin(coinTexture, new Vector2(500, 930)));

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
