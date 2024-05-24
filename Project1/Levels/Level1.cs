using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Sprites;

namespace Project1.Levels
{
    internal class Level1 : LevelBase
    {
        public Level1(Texture2D playerTextureLeft,
            Texture2D playerTextureRight,
            Texture2D enemyTextureRight,
            Texture2D enemyTextureLeft,
            Texture2D platformTexture,
            Texture2D coinTexture,
            Texture2D backgroundTexture,
            Texture2D heartTexture,
            Texture2D buttonStartTexture,
            SpriteFont font)
            : base(playerTextureLeft,
                  playerTextureRight,
                  backgroundTexture,
                  heartTexture,
                  buttonStartTexture,
                  font)
        {
            AddSprite(new Platform(platformTexture, new Vector2(0, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(192, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(384, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(576, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(768, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(100, 350)));
            AddSprite(new Platform(platformTexture, new Vector2(320, 250)));
            AddSprite(new Platform(platformTexture, new Vector2(540, 350)));

            AddSprite(new Coin(coinTexture, new Vector2(160, 280)));
            AddSprite(new Coin(coinTexture, new Vector2(380, 180)));
            AddSprite(new Coin(coinTexture, new Vector2(600, 280)));
        }
    }
}