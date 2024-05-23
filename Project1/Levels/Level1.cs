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
            AddSprite(new Platform(platformTexture, new Vector2(0, 441)));
            AddSprite(new Platform(platformTexture, new Vector2(240, 441)));
            AddSprite(new Platform(platformTexture, new Vector2(480, 441)));
            AddSprite(new Platform(platformTexture, new Vector2(720, 441)));

            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(300, 400)));
            AddSprite(new Enemy(enemyTextureRight, enemyTextureLeft, new Vector2(600, 400)));

            AddSprite(new Coin(coinTexture, new Vector2(100, 370)));
            AddSprite(new Coin(coinTexture, new Vector2(400, 370)));
            AddSprite(new Coin(coinTexture, new Vector2(700, 370)));
        }
    }
}

