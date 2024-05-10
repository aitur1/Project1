using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Sprites;
using System.Collections.Generic;

namespace Project1.Levels
{
    internal class Level1
    {
        private List<Sprite> sprites;
        private Texture2D backgroundTexture;
        private Texture2D heartTexture;

        public Player player { get; private set; }
        private int playerLives;
        private int coinsCollected = 0;
        Game1 game;

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


        public Level1(Texture2D playerTexture, Texture2D enemyTexture, Texture2D platformTexture, Texture2D coinTexture, Texture2D backgroundTexture, Texture2D heartTexture)
        {
            this.backgroundTexture = backgroundTexture;
            this.heartTexture = heartTexture;
            sprites = new List<Sprite>();

            player = new Player(playerTexture, new Vector2(0, 380), sprites);

            sprites.Add(new Platform(platformTexture, new Vector2(0, 441)));
            sprites.Add(new Platform(platformTexture, new Vector2(230, 441)));
            sprites.Add(new Platform(platformTexture, new Vector2(460, 441)));
            sprites.Add(new Platform(platformTexture, new Vector2(690, 441)));


            sprites.Add(new Enemy(enemyTexture, new Vector2(500, 400)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(600, 400)));
            sprites.Add(new Enemy(enemyTexture, new Vector2(700, 400)));
            sprites.Add(new Coin(coinTexture, new Vector2(100, 370)));
            sprites.Add(new Coin(coinTexture, new Vector2(400, 370)));
            sprites.Add(new Coin(coinTexture, new Vector2(700, 370)));

            sprites.Add(player);
        }



        public void Update(GameTime gameTime)
        {
            if (!player.Dead)
            {
                var spritesToRemove = new List<Sprite>();

                foreach (var sprite in sprites)
                {
                    if (sprite is Coin coin && coin.IsCollected)
                    {
                        spritesToRemove.Add(coin);
                        coinsCollected++;
                    }
                    sprite.Update(gameTime);
                }

                foreach (var spriteToRemove in spritesToRemove)
                {
                    sprites.Remove(spriteToRemove);
                }

                playerLives = player.health;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, 800, 638), Color.White);
            foreach (var sprite in sprites)
            {
                sprite.Draw(spriteBatch);
            }

            for (int i = 0; i < playerLives; i++)
            {
                spriteBatch.Draw(heartTexture, new Vector2(10 + i * (heartTexture.Width + 5), 10), Color.White);
            }
        }
    }
}
