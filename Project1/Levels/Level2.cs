using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Sprites;

namespace Project1.Levels
{
    internal class Level2 : LevelBase
    {
        public Level2(Texture2D playerTextureLeft, 
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

            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(300, 410)));
            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(600, 410)));

            AddSprite(new Coin(coinTexture, new Vector2(100, 380)));
            AddSprite(new Coin(coinTexture, new Vector2(400, 380)));
            AddSprite(new Coin(coinTexture, new Vector2(700, 380)));
        }
    }
}

