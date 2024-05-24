using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Sprites;

namespace Project1.Levels
{
    internal class Level4 : LevelBase
    {
        public Level4(Texture2D playerTextureLeft,
            Texture2D playerTextureRight,
            Texture2D enemyTextureRight,
            Texture2D enemyTextureLeft,
            Texture2D platformTexture,
            Texture2D coinTexture,
            Texture2D backgroundTexture,
            Texture2D heartTexture,
            Texture2D buttonRestartTexture,
            SpriteFont font)
            : base(playerTextureLeft,
                  playerTextureRight,
                  backgroundTexture,
                  heartTexture,
                  buttonRestartTexture,
                  font)
        {
            AddSprite(new Platform(platformTexture, new Vector2(0, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(300, 350)));
            AddSprite(new Platform(platformTexture, new Vector2(0, 250)));
            AddSprite(new Platform(platformTexture, new Vector2(600, 250)));
            AddSprite(new Platform(platformTexture, new Vector2(600, 450)));
            AddSprite(new Platform(platformTexture, new Vector2(792, 250)));
            AddSprite(new Platform(platformTexture, new Vector2(792, 450)));

            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(360, 310)));

            AddSprite(new Coin(coinTexture, new Vector2(66, 180)));
            AddSprite(new Coin(coinTexture, new Vector2(666, 180)));
            AddSprite(new Coin(coinTexture, new Vector2(666, 380)));
        }
    }
}
