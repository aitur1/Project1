using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Sprites;
using System.Collections.Generic;

namespace Project1.Levels
{
    internal abstract class LevelBase
    {
        protected List<Sprite> sprites;
        protected Texture2D backgroundTexture;
        protected Texture2D heartTexture;
        protected SpriteFont font;


        public Player player { get; protected set; }
        private int playerLives;
        private int coinsCollected = 0;

        private ButtonRestart restartButton;
        private MouseState previousMouseState;

        public LevelBase(Texture2D textureLeft, Texture2D textureRight, Texture2D backgroundTexture, Texture2D heartTexture, Texture2D buttonRestartTexture, SpriteFont font)
        {
            this.backgroundTexture = backgroundTexture;
            this.heartTexture = heartTexture;
            this.font = font;
            sprites = new List<Sprite>();

            player = new Player(textureLeft, textureRight, new Vector2(0, 380), sprites);
            sprites.Add(player);

            Vector2 buttonPosition = new Vector2(350, 120);
            restartButton = new ButtonRestart(buttonRestartTexture, buttonPosition);
        }

        public bool PlayerTouchesRightEdge(GraphicsDevice graphicsDevice)
        {
            return player.position.X + player.texture.Width >= graphicsDevice.Viewport.Width;
        }

        public int GetCoinsCollected()
        {
            return coinsCollected;
        }

        protected void AddSprite(Sprite sprite)
        {
            sprites.Add(sprite);
        }

        public void Update(GameTime gameTime)
        {
            MouseState currentMouseState = Mouse.GetState();

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
            else
            {
                if (restartButton.IsClicked(currentMouseState, previousMouseState))
                {
                    RestartLevel();
                }
            }

            previousMouseState = currentMouseState;
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

            if (player.Dead)
            {
                restartButton.Draw(spriteBatch);
            }

            spriteBatch.DrawString(font, $"MOHET: {coinsCollected}", new Vector2(10, 70), Color.Yellow);
        }

        private void RestartLevel()
        {
            player.Reset(new Vector2(0, 380));
            foreach (var sprite in sprites)
            {
                if (sprite is Coin coin)
                {
                    coin.Reset();
                }
                else if (sprite is Enemy enemy)
                {
                    enemy.Reset();
                }
            }
            playerLives = player.healthMax;
            coinsCollected = 0;
        }
    }
}
